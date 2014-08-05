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
    enum AsanaManager
    {
        PopulateWorkspaces,
        PopulateProjects,
        PopulateTasks
    };

    public partial class Crescent : Form
    {
        private int yLoc = 0;
        private ArrayList workspaces;
        private int bw_state;
        private ArrayList projects;
        private ArrayList tasks;
        private ArrayList WorkspaceCheckBoxes;
        private ArrayList ProjectCheckBoxes;
        private ArrayList TaskCheckBoxes;
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
        private BackgroundWorker ReportGenerator;
        private BackgroundWorker GeneralWorker;

        public Crescent()
        {
            InitializeComponent();
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
            ProjectDictionary = new Dictionary<string, AsanaProject>();
            TaskDictionary = new Dictionary<long, AsanaTask>();
            TaskProjectDictionary = new Dictionary<AsanaTask, AsanaProject>();
            ProjectTabDictionary = new Dictionary<AsanaProject, int>();
            ProjectExcelDictionary = new Dictionary<string, ProjectInExcel>();
            ProjectAllCheckBox = new CheckBox();
            TaskAllCheckBox = new ArrayList();
            selectedProjects = new ArrayList();
            TaskYLoc = new ArrayList();
            tags = new ArrayList();
            lock1 = new Object();
            this.WorkspaceNextButton.Click += new System.EventHandler(this.WorkspaceNextButton_Click);
            this.ProjectBackButton.Click += new System.EventHandler(this.ProjectBackButton_Click);
            this.ProjectNextButton.Click += new System.EventHandler(this.ProjectNextButton_Click);
            this.TaskBackButton.Click += new System.EventHandler(this.TaskBackButton_Click);
            this.GenerateButton.Click += new System.EventHandler(this.GenerateButton_Click);
            this.GenerateCancelButton.Click += new System.EventHandler(this.GenerateCancelButton_Click);
            this.APIKeyButton.Click += new System.EventHandler(this.APIKeyButton_Click);
            this.WorkspaceBackButton.Click += new System.EventHandler(this.WorkspaceBackButton_Click);
            this.KeyPress += new KeyPressEventHandler(this.Crescent_KeyPressed);

            GeneralWorker = new BackgroundWorker();
            GeneralWorker.WorkerReportsProgress = false;
            GeneralWorker.WorkerSupportsCancellation = false;
            GeneralWorker.DoWork += new DoWorkEventHandler(bw_DoWork);
            GeneralWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);

            ReportGenerator = new BackgroundWorker();
            ReportGenerator.WorkerReportsProgress = true;
            ReportGenerator.WorkerSupportsCancellation = true;
            ReportGenerator.DoWork += new DoWorkEventHandler(bw_GenerateReport);
            ReportGenerator.ProgressChanged += new ProgressChangedEventHandler(bw_GenerateReportProgressChanged);
            ReportGenerator.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_GenerateReportRunWorkerCompleted);

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
         //   test.UseVisualStyleBackColor = true;
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
            panel.Invoke(new Action(() => { panel.Controls.Add(test); }));
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
                this.tabControl.Invoke(new Action(() => { this.tabControl.TabPages[TabIndex].Controls.Add(test); }));
            }
        }
        public void bw_PopulateWorkspaces()
        {
            yLoc = 0;
            this.WorkspaceLoadingLabel.Invoke(new Action(() => { 
                this.WorkspaceLoadingLabel.Text = "Loading workspaces..."; 
            }));
            asana.GetWorkspaces(o =>
            {
                foreach (AsanaWorkspace workspace in o)
                {
                    workspaces.Add(workspace);
                    WorkspaceDictionary.Add(workspace.Name, workspace);
                    this.AddCheckbox(workspace, this.WorkspacePanel);
                }
            }).Wait();
        }

        private void WorkspaceBackButton_Click(object sender, EventArgs e)
        {
            this.WorkspacePanel.Controls.Clear();
            this.ChooseWorkspacePanel.Visible = false;
            this.asanacrescentLogo.Visible = true;
            this.AuthenticationPanel.Focus();
            tags.Clear();
            workspaces.Clear();
            WorkspaceDictionary.Clear();
        }

        private void APIKeyButton_Click(object sender, EventArgs e)
        {
            this.asanacrescentLogo.Visible = false;
            this.SetAsanaConnection(this.APIKeyBox.Text);
            this.ChooseWorkspacePanel.Visible = true;
            this.ChooseWorkspacePanel.Focus();
            GeneralWorker.RunWorkerAsync(AsanaManager.PopulateWorkspaces);
        }

        public void GetWorkspaceTags()
        {
            asana.GetTagsInWorkspace(WorkspaceDictionary[this.CurrentWorkspaceName], o =>
            {
                foreach (AsanaTag tag in o)
                    tags.Add(tag.Name);

            }).Wait();
        }

        public void bw_PopulateProjects()
        {
            this.Invoke(new Action(() =>
            {

                this.ProjectLoadingLabel.Text = "Loading projects...";
                yLoc = 0;

                //Add a checkbox to select All

                ProjectAllCheckBox.AutoSize = true;
                ProjectAllCheckBox.Location = new System.Drawing.Point(3, 5 + yLoc);
                yLoc += 20;
                ProjectAllCheckBox.Size = new System.Drawing.Size(80, 17);
                ProjectAllCheckBox.Cursor = System.Windows.Forms.Cursors.Hand;
                ProjectAllCheckBox.TabIndex = 1;
                ProjectAllCheckBox.UseVisualStyleBackColor = true;
                ProjectAllCheckBox.Text = "All";
                ProjectAllCheckBox.CheckedChanged += new System.EventHandler(this.ProjectAllCheckBox_CheckChanged);
                this.ProjectPanel.Invoke(new Action(() => { this.ProjectPanel.Controls.Add(ProjectAllCheckBox); }));

            }));
                // get projects from Asana
                asana.GetProjectsInWorkspace(WorkspaceDictionary[this.CurrentWorkspaceName], o =>
                {
                    foreach (AsanaProject project in o)
                    {
                        projects.Add(project);
                        ProjectDictionary.Add(project.Name, project);
                        this.AddCheckbox(project, this.ProjectPanel);
                    }
                }).Wait();


        }

        public void bw_PopulateTasks()
        {
            this.Invoke(new Action(() =>
            {
                this.TaskLoadingLabel.Text = "Loading tasks...";
                TaskYLoc.Clear();
            }));
            foreach (AsanaProject project in selectedProjects)
                TaskConnectionEnded.Add(false);
            //Add a checkbox to select All
            foreach (AsanaProject project in selectedProjects)
            {
                CheckBox all = new CheckBox();
                all.AutoSize = true;
                all.Location = new System.Drawing.Point(3, 5);
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

                this.tabControl.Invoke(new Action(() =>
                {   this.tabControl.TabPages.Add(tab); }));
                
            }
            // Add tasks based on selected projects
            int j = 0;
            foreach (AsanaProject project in selectedProjects)
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
                                this.tabControl.Invoke(new Action(() =>
                                {
                                    TabControl tc = this.tabControl;
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
                }).Wait();

            }

        }

        private void ProjectCheckBox_CheckChanged(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Checked)
            {
                this.ProjectNextButton.Enabled = true;
                return;
            }
            else
            {
                foreach (CheckBox project in ProjectCheckBoxes)
                {
                    if (project.Checked)
                    {
                        this.ProjectNextButton.Enabled = true;
                        return;
                    }
                }
            }
            this.ProjectNextButton.Enabled = false;
        }

        private void TaskCheckBox_CheckChanged(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Checked)
            {
                this.GenerateButton.Enabled = true;
                return;
            }
            else
            {
                foreach (CheckBox task in TaskCheckBoxes)
                {
                    if (task.Checked)
                    {
                        this.GenerateButton.Enabled = true;
                        return;
                    }
                }
            }
            this.GenerateButton.Enabled = false;
        }

        private void WorkspaceCheckBox_CheckChanged(object sender, EventArgs e)
        {
            this.WorkspaceNextButton.Enabled = false;
            if (((CheckBox)sender).Checked == true)
            {
                this.WorkspaceNextButton.Enabled = true;
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
                        this.WorkspaceNextButton.Enabled = true;
                    }
                }
            }
        }

        public void WorkspaceNextButton_Click(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.ClientSize = new System.Drawing.Size(396, 455);
            this.ChooseProjectPanel.Visible = true;
            this.ChooseProjectPanel.Focus();
            GeneralWorker.RunWorkerAsync(AsanaManager.PopulateProjects);
        }

        public void ProjectBackButton_Click(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(396, 298);
            ProjectAllCheckBox.Checked = false;
            this.ChooseProjectPanel.Visible = false;
            this.ChooseWorkspacePanel.Focus();
            tags.Clear();
            ClearProjects();
        }
        public void ProjectNextButton_Click(object sender, EventArgs e)
        {

            Application.EnableVisualStyles();
            selectedProjects.Clear();
            ProjectExcelDictionary.Clear();

            foreach (CheckBox project in ProjectCheckBoxes)
            {
                if (project.Checked)
                {
                    selectedProjects.Add(ProjectDictionary[project.Text]);
                }
            }
            this.ChooseTaskPanel.Visible = true;
            this.ChooseTaskPanel.Focus();
            this.FindForm().WindowState = FormWindowState.Maximized;
            this.tabControl.Visible = true;
            
            GeneralWorker.RunWorkerAsync(AsanaManager.PopulateTasks);
        }
        public void TaskBackButton_Click(object sender, EventArgs e)
        {

            // wait for asana connections to end
            for (int i = 0; i < TaskConnectionEnded.Count; i++)
            {
                if ((bool)TaskConnectionEnded[i] == false)
                {
                    i = 0;
                    Thread.Sleep(10);
                    break;
                }
            }

            this.tabControl.TabPages.Clear();
            this.tabControl.Controls.Clear();
            this.ChooseTaskPanel.Visible = false;
            this.ChooseProjectPanel.Focus();
            ClearTasks();
            this.FindForm().WindowState = FormWindowState.Normal;
        }

        public void GenerateButton_Click(object sender, EventArgs e)
        {
            this.GenerateButton.Visible = false;
            this.GenerateCancelButton.Visible = true;
            this.TaskBackButton.Enabled = false;

            this.progressBar1.Visible = true;
            ReportGenerator.RunWorkerAsync();
        }
        private void ClearProjects()
        {
            projects.Clear();
            ProjectDictionary.Clear();
            ProjectCheckBoxes.Clear();
            this.ProjectPanel.Controls.Clear();
            this.ProjectNextButton.Enabled = false;
        }

        private void ClearTasks()
        {
            tasks.Clear();
            TaskProjectDictionary.Clear();
            TaskCheckBoxes.Clear();
            TaskDictionary.Clear();
            this.tabControl.TabPages.Clear();
            this.tabControl.Controls.Clear();
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
                    if (((CheckBox)sender).Name ==
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
            lock (lock1)
            {
                bw_state = (int)e.Argument;
            }
            switch ((int)e.Argument)
            {
                case (int)AsanaManager.PopulateWorkspaces :
                    this.bw_PopulateWorkspaces();
                    break;
                case (int)AsanaManager.PopulateProjects :
                    this.bw_PopulateProjects();
                    break;
                case (int)AsanaManager.PopulateTasks :
                    this.bw_PopulateTasks();
                    break;
                default: 
                    return;
            }

        }
        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            switch (bw_state)
            {
                case (int)AsanaManager.PopulateWorkspaces:
                    this.WorkspaceLoadingLabel.Invoke(new Action(() =>
                        {   this.WorkspaceLoadingLabel.Text = "Done"; }));
                    break;

                case (int)AsanaManager.PopulateProjects:
                    this.ProjectLoadingLabel.Invoke(new Action(() =>
                        { this.ProjectLoadingLabel.Text = "Done"; }));
                    break;

                case (int)AsanaManager.PopulateTasks:
                    this.TaskLoadingLabel.Invoke(new Action(() =>
                        { this.TaskLoadingLabel.Text = "Done"; }));
                    break;
            }

        }

        private void bw_GenerateReport(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            excel = new ExcelMaster();
            excel.SetWorksheets(selectedProjects);

            this.GetWorkspaceTags();
            foreach (AsanaProject project in selectedProjects)
            {
                string col = project.Name;
                col = col.Replace(":", "");
                col = col.Replace("/", " ");
                col = col.Replace("\\", " ");
                excel.SetColumns((string[])ProjectExcelDictionary[project.Name].Columns.ToArray(typeof(string)), col);
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
                worker.ReportProgress((int)(i * 100.0 / total));
            }
            excel.MakeWorksheetsTables();
        }
        private void bw_GenerateReportProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.progressBar1.Value = e.ProgressPercentage;
        }
        private void bw_GenerateReportRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if ((e.Cancelled == true))
            {
                excel.CloseWithoutSaving();
            }
            else
            {
                excel.SaveAndClose();
            }
            Crescent.CancelTaskPopulating = false;
            this.progressBar1.Visible = false;
            this.progressBar1.Value = 0;
            this.GenerateButton.Visible = true;
            this.GenerateCancelButton.Visible = false;
            this.TaskBackButton.Enabled = true;
        }

        private void GenerateCancelButton_Click(object sender, EventArgs e)
        {
            Crescent.CancelTaskPopulating = true;
            if (ReportGenerator.WorkerSupportsCancellation)
            {
                ReportGenerator.CancelAsync();
            }
        }
        private void Crescent_KeyPressed(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                e.Handled = true;
        }
    }
}