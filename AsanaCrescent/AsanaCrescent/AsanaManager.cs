using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using AsanaNet;
using System.Windows.Forms;
using System.Threading;
using System.ComponentModel;
namespace AsanaCrescent
{
    public class AsanaManager
    {
        private int yLoc = 0;
        private ArrayList workspaces;
        private ArrayList projects;
        private ArrayList tasks;
        private ArrayList WorkspaceCheckBoxes;
        private ArrayList ProjectCheckBoxes;
        private ArrayList TaskCheckBoxes;
        private Crescent crescent;
        private Asana asana;
        public static bool CancelTaskPopulating;
        private ArrayList TaskConnectionEnded;
        private ExcelMaster excel;
        private Dictionary<string, AsanaWorkspace> WorkspaceDictionary;
        private Dictionary<string, AsanaProject> ProjectDictionary;
        private Dictionary<long, AsanaTask> TaskDictionary;
        private Dictionary<AsanaTask, AsanaProject> TaskProjectDictionary;
        private Dictionary<AsanaProject, int> ProjectTabDictionary;
        private Dictionary<string, ProjectInExcel> ProjectExcelDictionary;
        private string CurrentWorkspaceName;
        private CheckBox ProjectAllCheckBox;
        private ArrayList TaskAllCheckBox;
        private ArrayList tags;
        private ArrayList selectedProjects;
        private Object lock1;
        private ArrayList TaskYLoc;
        private BackgroundWorker b;
        public AsanaManager(Crescent c)
        {
            crescent = c;
            asana = null;
            CancelTaskPopulating = false;
            workspaces = new ArrayList();
            WorkspaceCheckBoxes = new ArrayList();
            ProjectCheckBoxes = new ArrayList();
            TaskCheckBoxes = new ArrayList();
            projects = new ArrayList();
            tasks = new ArrayList();
            TaskConnectionEnded = new ArrayList();
            WorkspaceDictionary = new Dictionary<string, AsanaWorkspace>();
            ProjectDictionary = new Dictionary<string,AsanaProject>();
            TaskDictionary = new Dictionary<long,AsanaTask>();
            TaskProjectDictionary = new Dictionary<AsanaTask,AsanaProject>();
            ProjectTabDictionary = new Dictionary<AsanaProject, int>();
            ProjectExcelDictionary = new Dictionary<string, ProjectInExcel>();
            ProjectAllCheckBox = new CheckBox();
            TaskAllCheckBox = new ArrayList();
            selectedProjects = new ArrayList();
            TaskYLoc = new ArrayList();
            tags = new ArrayList();
            lock1 = new Object();
            crescent.WorkspaceNextButton.Click += new System.EventHandler(this.WorkspaceNextButton_Click);
            crescent.ProjectBackButton.Click += new System.EventHandler(this.ProjectBackButton_Click);
            crescent.ProjectNextButton.Click += new System.EventHandler(this.ProjectNextButton_Click);
            crescent.TaskBackButton.Click += new System.EventHandler(this.TaskBackButton_Click);
            crescent.GenerateButton.Click += new System.EventHandler(this.GenerateButton_Click);
            crescent.tabControl.VisibleChanged += new System.EventHandler(TabControl_VisibleChanged);
            crescent.GenerateCancelButton.Click += new System.EventHandler(this.GenerateCancelButton_Click);
            crescent.APIKeyButton.Click += new System.EventHandler(this.APIKeyButton_Click);
            crescent.WorkspaceBackButton.Click += new System.EventHandler(this.WorkspaceBackButton_Click);
            b = new BackgroundWorker();
            b.WorkerReportsProgress = true;
            b.WorkerSupportsCancellation = true;
            b.DoWork += new DoWorkEventHandler(bw_DoWork);
            b.ProgressChanged += new ProgressChangedEventHandler(bw_ProgressChanged);
            b.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);

        }

        public void SetAsanaConnection(String APIKey)
        {
            asana = null;
            asana = new Asana(APIKey, AuthenticationType.Basic, (s1, s2, s3) => { });
        }
        private void AddCheckbox(AsanaObject o, Panel panel)
        {
            CheckBox test = new CheckBox();
            test.AutoSize = true;
            test.Location = new System.Drawing.Point(6, 5 + yLoc);
            yLoc += 25;
            test.Size = new System.Drawing.Size(80, 17);
            test.TabIndex = 1;
            test.UseVisualStyleBackColor = true;
            if (o is AsanaProject)
            {
                test.Text = ((AsanaProject)o).Name;
                test.Name = "" + ((AsanaProject)o).ID;
                test.CheckedChanged += new System.EventHandler(this.ProjectCheckBox_CheckChanged);
                ProjectCheckBoxes.Add(test);
            }
            else if (o is AsanaWorkspace)
            {
                test.Text = ((AsanaWorkspace)o).Name;
                test.Name = "" + ((AsanaWorkspace)o).ID;
                test.CheckedChanged += new System.EventHandler(this.WorkspaceCheckBox_CheckChanged);
                WorkspaceCheckBoxes.Add(test);
            }
            if (panel.InvokeRequired)
            {
                panel.Invoke(new Action(() => { panel.Controls.Add(test); }));
            }
            else
            {
                panel.Controls.Add(test);
            }
        }

        private void AddTabCheckbox(AsanaTask task, int TabIndex)
        {
            if (!CancelTaskPopulating)
            {
                CheckBox test = new CheckBox();
                test.Text = task.Name;
                test.AutoSize = true;
                test.Name = "" + task.ID;
                test.Location = new System.Drawing.Point(6, (int)TaskYLoc[TabIndex] + 25);
                TaskYLoc[TabIndex] = (int)TaskYLoc[TabIndex] + 25;
                TaskCheckBoxes.Add(test);
                test.CheckedChanged += new System.EventHandler(this.TaskCheckBox_CheckChanged);
                if (crescent.tabControl.InvokeRequired)
                {
                    crescent.tabControl.Invoke(new Action(() => { crescent.tabControl.TabPages[TabIndex].Controls.Add(test); }));
                }
                else
                {
                    crescent.tabControl.TabPages[TabIndex].Controls.Add(test);
                }
            }
        }
        public void PopulateWorkspaces()
        {
            yLoc = 0;
            crescent.WorkspaceNothingHereLabel.Invoke(new Action(() => { crescent.WorkspaceNothingHereLabel.Visible = false; }));
            asana.GetWorkspaces(o =>
            {
                foreach (AsanaWorkspace workspace in o)
                {
                    workspaces.Add(workspace);
                    WorkspaceDictionary.Add(workspace.Name, workspace);
                    this.AddCheckbox(workspace, crescent.WorkspacePanel);
                }

                if (workspaces.Count == 0)
                    crescent.WorkspaceNothingHereLabel.Invoke(new Action( () => {crescent.WorkspaceNothingHereLabel.Visible = true;}));
            });
        }

        private void WorkspaceBackButton_Click(object sender, EventArgs e)
        {
            crescent.WorkspacePanel.Controls.Clear();
            crescent.WorkspacePanel.Controls.Add(crescent.WorkspaceNothingHereLabel);
            crescent.ChooseWorkspacePanel.Visible = false;
            crescent.asanacrescentLogo.Visible = true;

            workspaces.Clear();
            WorkspaceDictionary.Clear();
        }
        
        private void APIKeyButton_Click(object sender, EventArgs e)
        {
            crescent.asanacrescentLogo.Visible = false;
            this.SetAsanaConnection(crescent.APIKeyBox.Text);
            crescent.ChooseWorkspacePanel.Visible = true;
            this.PopulateWorkspaces();
        }

        public void PopulateProjects()
        {
            crescent.ProjectLoadingLabel.Text = "Loading projects...";
            yLoc = 0;

            //Add a checkbox to select All
            
            ProjectAllCheckBox.AutoSize = true;
            ProjectAllCheckBox.Location = new System.Drawing.Point(3, 5 + yLoc);
            yLoc += 20;
            ProjectAllCheckBox.Size = new System.Drawing.Size(80, 17);
            ProjectAllCheckBox.TabIndex = 1;
            ProjectAllCheckBox.UseVisualStyleBackColor = true;
            ProjectAllCheckBox.Text = "All";
            ProjectAllCheckBox.CheckedChanged += new System.EventHandler(this.ProjectAllCheckBox_CheckChanged);
            if (crescent.ProjectPanel.InvokeRequired)
            {
                crescent.ProjectPanel.Invoke(new Action(() => { crescent.ProjectPanel.Controls.Add(ProjectAllCheckBox); }));
            }
            else
            {
                crescent.ProjectPanel.Controls.Add(ProjectAllCheckBox);
            }

            // get projects from Asana
            asana.GetProjectsInWorkspace(WorkspaceDictionary[this.CurrentWorkspaceName], o =>
            {
                foreach (AsanaProject project in o)
                {
                    projects.Add(project);
                    ProjectDictionary.Add(project.Name, project);
                    this.AddCheckbox(project, crescent.ProjectPanel);
                }
                if (projects.Count == 0)
                {
                    if (crescent.ProjectLoadingLabel.InvokeRequired)
                    {
                        crescent.ProjectLoadingLabel.Invoke(new Action(() =>
                            { crescent.NothingHereProjectLabel.Visible = true; }));
                    }
                    else
                        crescent.NothingHereProjectLabel.Visible = true;
                }


                if (crescent.ProjectLoadingLabel.InvokeRequired)
                {
                    crescent.ProjectLoadingLabel.Invoke(new Action(() =>
                    {
                        crescent.ProjectLoadingLabel.Text = "Done";
                        crescent.ProjectBackButton.Enabled = true;
                    }));
                }
                else
                {
                    crescent.ProjectLoadingLabel.Text = "Done";
                    crescent.ProjectBackButton.Enabled = true;
                }
                
            });

        }

        public void PopulateTasks()
        {
            TaskYLoc.Clear();
            //Add a checkbox to select All
            foreach (AsanaProject project in selectedProjects)
                TaskConnectionEnded.Add(false);
            foreach(AsanaProject project in selectedProjects)
            {
                CheckBox all = new CheckBox();
                all.AutoSize = true;
                all.Location= new System.Drawing.Point(3, 5);
                all.Checked = false;
                all.Name = project.Name;
                all.Size = new System.Drawing.Size(80, 17);
                all.UseVisualStyleBackColor = true;
                all.Text = "All";
                all.CheckedChanged += new System.EventHandler(this.TaskAllCheckBox_CheckChanged);
                TaskAllCheckBox.Add(all);
                TaskYLoc.Add(5);

                TabPage tab = new TabPage(project.Name);
                tab.Controls.Add(all);
                tab.AutoScroll = true;

                if (crescent.tabControl.InvokeRequired)
                {
                    crescent.tabControl.Invoke(new Action(() => { 
                        crescent.tabControl.TabPages.Add(tab);
                    }));
                }
                else
                {
                    crescent.tabControl.TabPages.Add(tab);
                }

            }
            // Add tasks based on selected projects
            crescent.TaskLoadingLabel.Text = "Loading tasks...";
            int j = 0;
            foreach(AsanaProject project in selectedProjects)
            {
                if (CancelTaskPopulating)
                {
                    for (int i = 0; i < TaskConnectionEnded.Count; i++)
                        TaskConnectionEnded[i] = true;
                    break;
                }
                ProjectInExcel excelproj = new ProjectInExcel();
                ProjectExcelDictionary.Add(project.Name, excelproj);
                    // Add "Task" and "Project" columns
                    asana.GetTasksInAProject(project, o =>
                    {
                        int tmp = j;
   
                        foreach (AsanaTask task in o)
                        {
                            if (CancelTaskPopulating)
                                break;
                            if (!task.Name.EndsWith(":"))
                            {
                                if (!TaskDictionary.ContainsKey(task.ID)) // prevent duplicate keys
                                {
                                    TaskProjectDictionary.Add(task, ProjectDictionary[project.Name]);
                                    TaskDictionary.Add(task.ID, task);
                                    tasks.Add(task);
                                    crescent.tabControl.Invoke(new Action(() =>
                                    {
                                        TabControl tc = crescent.tabControl;
                                        int i;
                                        for (i = 0; i < tc.TabCount && tc.TabPages[i].Text != project.Name; i++)
                                            ;
                                        this.AddTabCheckbox(task, i);
                                    }));

                                }
                            }
                            else
                            {
                                bool flag = false;
                                foreach (string name in excelproj.Columns)
                                {
                                    if (name == task.Name.Substring(0, task.Name.Length - 1))
                                        flag = true;
                                }
                                if (!flag)
                                {
                                    excelproj.Columns.Add(task.Name.Substring(0, task.Name.Length - 1));
                                }
                            }

                            TaskConnectionEnded[tmp] = true;
                        }
                   });
                    
             }
            
        }

        private void ProjectCheckBox_CheckChanged(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Checked)
            {
                crescent.ProjectNextButton.Enabled = true;
                return;
            }
            else
            {
                foreach (CheckBox project in ProjectCheckBoxes)
                {
                    if (project.Checked)
                    {
                        crescent.ProjectNextButton.Enabled = true;
                        return;
                    }
                }
            }
            crescent.ProjectNextButton.Enabled = false;
        }

        private void TaskCheckBox_CheckChanged(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Checked)
            {
                crescent.GenerateButton.Enabled = true;
                return;
            }
            else
            {
                foreach (CheckBox task in TaskCheckBoxes)
                {
                    if (task.Checked)
                    {
                        crescent.GenerateButton.Enabled = true;
                        return;
                    }
                }
            }
            crescent.GenerateButton.Enabled = false;
        }

        private void WorkspaceCheckBox_CheckChanged(object sender, EventArgs e)
        {
            crescent.WorkspaceNextButton.Enabled = false;
            if (((CheckBox)sender).Checked == true)
            {
                crescent.WorkspaceNextButton.Enabled = true;
                this.CurrentWorkspaceName = ((CheckBox)sender).Text;
                foreach (CheckBox checkbox in WorkspaceCheckBoxes)
                {
                    if (checkbox != sender)
                    {
                        checkbox.Checked = false;
                    }
                }

                foreach (CheckBox checkbox in WorkspaceCheckBoxes)
                {
                    if (checkbox.Checked == true)
                    {
                        crescent.WorkspaceNextButton.Enabled = true;
                    }
                }
            }
        }

        public void WorkspaceNextButton_Click(object sender, EventArgs e)
        {
            crescent.FormBorderStyle = FormBorderStyle.Sizable;
            crescent.ClientSize = new System.Drawing.Size(396, 450);
            crescent.ChooseProjectPanel.Visible = true;
            PopulateProjects();
            asana.GetTagsInWorkspace(WorkspaceDictionary[this.CurrentWorkspaceName], o =>
            {
                foreach (AsanaTag tag in o)
                    tags.Add(tag.Name);

            });
        }

        public void ProjectBackButton_Click(object sender, EventArgs e)
        {
            crescent.FormBorderStyle = FormBorderStyle.FixedSingle;
            crescent.ClientSize = new System.Drawing.Size(396, 298);
            ProjectAllCheckBox.Checked = false;
            crescent.ChooseProjectPanel.Visible = false;
            tags.Clear();
            ClearProjects();
        }
        public void ProjectNextButton_Click(object sender, EventArgs e)
        {
            selectedProjects.Clear();
            ProjectExcelDictionary.Clear();
   
            foreach (CheckBox project in ProjectCheckBoxes)
            {
                if (project.Checked)
                {
                    selectedProjects.Add(ProjectDictionary[project.Text]);
                }
            }
            crescent.ChooseTaskPanel.Visible = true;
            crescent.FindForm().WindowState = FormWindowState.Maximized;
            crescent.tabControl.Visible = true;
            PopulateTasks();
        }
        public void TaskBackButton_Click(object sender, EventArgs e)
        {
            CancelTaskPopulating = true;

            // wait for asana connections to end
            for (int i = 0; i < TaskConnectionEnded.Count; i++ )
            {
                if ((bool)TaskConnectionEnded[i] == false)
                {
                    i = 0;
                    Thread.Sleep(10);
                    break;
                }
             }

            crescent.tabControl.TabPages.Clear();
            crescent.tabControl.Controls.Clear();
            crescent.ChooseTaskPanel.Visible = false;
            selectedProjects.Clear();
            ClearTasks();
            crescent.FindForm().WindowState = FormWindowState.Normal;
        }

        public void GenerateButton_Click(object sender, EventArgs e)
        {
            crescent.GenerateButton.Visible = false;
            crescent.GenerateCancelButton.Visible = true;
            crescent.TaskBackButton.Enabled = false;

            crescent.progressBar1.Visible = true;
            b.RunWorkerAsync();
        }

        private void TabControl_VisibleChanged(object sender, EventArgs e)
        {
            if ((sender as TabControl).Visible)
                crescent.TaskLoadingLabel.Text = "Done";
            else
                crescent.TaskLoadingLabel.Text = "Loading tasks...";
        }
        private void ClearProjects()
        {
            projects.Clear();
            ProjectDictionary.Clear();
            ProjectCheckBoxes.Clear();
            crescent.ProjectPanel.Controls.Clear();
            crescent.ProjectPanel.Controls.Add(crescent.NothingHereProjectLabel);
            crescent.NothingHereProjectLabel.Visible = false;
            crescent.ProjectBackButton.Enabled = false;
            crescent.ProjectNextButton.Enabled = false;
        }

        private void ClearTasks()
        {
            tasks.Clear();
            TaskProjectDictionary.Clear();
            TaskCheckBoxes.Clear();
            TaskDictionary.Clear();
            crescent.tabControl.TabPages.Clear();
            crescent.tabControl.Controls.Clear();
            crescent.ChooseTaskPanel.Controls.Add(crescent.TaskLoadingLabel);
            crescent.TaskLoadingLabel.Visible = true;
        }
        private void AddTagPanelToCheckBox(CheckBox checkbox)
        {
        }

        private void ProjectAllCheckBox_CheckChanged(object sender, EventArgs e)
        {
            if ((sender as CheckBox).Checked)
            {
                foreach (CheckBox project in ProjectCheckBoxes)
                {
                    project.Checked = true;
                }
                return;
            }

            foreach (CheckBox project in ProjectCheckBoxes)
            {
                project.Checked = false;
            }
        }

        private void TaskAllCheckBox_CheckChanged(object sender, EventArgs e)
        {
            if ((sender as CheckBox).Checked)
            {
                foreach (CheckBox task in TaskCheckBoxes)
                {
                    if(((CheckBox)sender).Name ==
                        TaskProjectDictionary[TaskDictionary[Convert.ToInt64(task.Name)]].Name)
                    {
                        task.Checked = true;
                    }
                }
                return;
            }

            foreach (CheckBox task in TaskCheckBoxes)
            {
                if (((CheckBox)sender).Name ==
                    TaskProjectDictionary[TaskDictionary[Convert.ToInt64(task.Name)]].Name)
                {
                    task.Checked = false;
                }
            }

        }

        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            excel = new ExcelMaster();
            excel.SetWorksheets(selectedProjects);
            foreach(AsanaProject project in selectedProjects)
            {
                string col = project.Name;
                col = col.Replace(":", "");
                col = col.Replace("/", " ");
                col = col.Replace("\\", " ");
                excel.SetColumns((string[]) ProjectExcelDictionary[project.Name].Columns.ToArray(typeof(string)), col); 
            }
            ArrayList Stories = new ArrayList();
            int i = 0;
            int total = TaskCheckBoxes.Count;
            foreach (CheckBox task in TaskCheckBoxes)
            {
                if (worker.CancellationPending)
                {
                    e.Cancel = true;
                    break;
                }
                i++;
                if (task.Checked)
                {
                    AsanaTask t = TaskDictionary[Convert.ToInt64(task.Name)];
                    asana.GetStoriesInTask(t, o =>
                    {
                        foreach (AsanaStory story in o)
                        {
                            Stories.Add(story);
                        }
                    }).Wait();
                    AsanaProject curProject = TaskProjectDictionary[t];
                    string projName = curProject.Name.Replace(":", "");
                    string[] cols = excel.GetColumnNames(projName);
                    string[] data = Parser.ParseStories(Stories, (string[])tags.ToArray(typeof(string)), cols, curProject.Name);
                    data[0] = task.Text;
                    excel.AddRow(data, projName);
                    data = null;
                    Stories.Clear();
                }
                worker.ReportProgress((int) (i*100.0/total));
            }
            excel.MakeWorksheetsTables();
        }
        private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            crescent.progressBar1.Value = e.ProgressPercentage;
        }
        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if ((e.Cancelled == true))
            {
                this.excel.CloseWithoutSaving();
            }
            else
            {
                excel.SaveAndClose();
            }
            crescent.progressBar1.Visible = false;
            crescent.progressBar1.Value = 0;
            crescent.GenerateButton.Visible = true;
            crescent.GenerateCancelButton.Visible = false;
            crescent.TaskBackButton.Visible = true;
        }

        private void GenerateCancelButton_Click(object sender, EventArgs e)
        {
            if (b.WorkerSupportsCancellation)
            {
                b.CancelAsync();
            }
        }
    }
}