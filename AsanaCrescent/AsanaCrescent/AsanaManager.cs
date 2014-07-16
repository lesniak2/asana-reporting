using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using AsanaNet;
using System.Windows.Forms;
using System.Threading;
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
        private Dictionary<string, AsanaWorkspace> WorkspaceDictionary;
        private Dictionary<string, AsanaProject> ProjectDictionary;
        private Dictionary<string, AsanaTask> TaskDictionary;
        private Dictionary<AsanaTask, AsanaProject> TaskProjectDictionary;
        private string CurrentWorkspaceName;
        public AsanaManager(Crescent c, Asana a)
        {
            crescent = c;
            asana = a;

            workspaces = new ArrayList();
            WorkspaceCheckBoxes = new ArrayList();
            ProjectCheckBoxes = new ArrayList();
            TaskCheckBoxes = new ArrayList();
            projects = new ArrayList();
            tasks = new ArrayList();
            WorkspaceDictionary = new Dictionary<string, AsanaWorkspace>();
            ProjectDictionary = new Dictionary<string,AsanaProject>();
            TaskDictionary = new Dictionary<string,AsanaTask>();
            TaskProjectDictionary = new Dictionary<AsanaTask,AsanaProject>();


            crescent.WorkspaceNextButton.Click += new System.EventHandler(this.WorkspaceNextButton_Click);
            crescent.ProjectBackButton.Click += new System.EventHandler(this.ProjectBackButton_Click);
            crescent.ProjectNextButton.Click += new System.EventHandler(this.ProjectNextButton_Click);
            crescent.TaskBackButton.Click += new System.EventHandler(this.TaskBackButton_Click);
            crescent.GenerateButton.Click += new System.EventHandler(this.GenerateButton_Click);
            crescent.TaskPanel.ControlAdded += new System.Windows.Forms.ControlEventHandler(TaskPanel_ControlAdded);

        }

        private void AddCheckbox(AsanaObject o, Panel panel)
        {
            CheckBox test = new CheckBox();
            test.AutoSize = true;
            test.Location = new System.Drawing.Point(6, 5 + yLoc);
            if (o is AsanaTask)
                yLoc += 50;
            else 
                yLoc += 25;
            test.Size = new System.Drawing.Size(80, 17);
            test.TabIndex = 1;
            test.UseVisualStyleBackColor = true;
            if (o is AsanaTask)
            {
                test.Text = ((AsanaTask)o).Name;
                TaskCheckBoxes.Add(test);
                test.CheckedChanged += new System.EventHandler(this.TaskCheckBox_CheckChanged);
            }
            else if (o is AsanaProject)
            {
                test.Text = ((AsanaProject)o).Name;
                test.CheckedChanged += new System.EventHandler(this.ProjectCheckBox_CheckChanged);
                ProjectCheckBoxes.Add(test);
            }
            else if (o is AsanaWorkspace)
            {
                test.Text = ((AsanaWorkspace)o).Name;
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
        public void PopulateWorkspaces()
        {
            yLoc = 0;
            asana.GetWorkspaces(o =>
            {
                foreach (AsanaWorkspace workspace in o)
                {
                    workspaces.Add(workspace);
                    WorkspaceDictionary.Add(workspace.Name, workspace);
                    this.AddCheckbox(workspace, crescent.WorkspacePanel);
                }
            });
        }

        public void PopulateProjects()
        {
            crescent.ProjectLoadingLabel.Text = "Loading projects...";
            yLoc = 0;

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
            yLoc = 0; 
            crescent.TaskLoadingLabel.Text = "Loading Tasks...";
            foreach(CheckBox project in ProjectCheckBoxes)
            {
                if(project.Checked == true)
                {
                    asana.GetTasksInAProject(ProjectDictionary[project.Text], o =>
                    {
                        foreach (AsanaTask task in o)
                        {
                            TaskProjectDictionary.Add(task, ProjectDictionary[project.Text]);
                            TaskDictionary.Add(task.Name, task);
                            tasks.Add(task);
                        }
                        foreach (AsanaTask task in o)
                        {
                            this.AddCheckbox(task, crescent.TaskPanel);
                        } 
                        
                        if (crescent.TaskBackButton.InvokeRequired)
                        {
                            crescent.TaskBackButton.Invoke(new Action(() =>
                            { crescent.TaskBackButton.Enabled = true; }));
                        }
                        else
                            crescent.TaskBackButton.Enabled = true;
                    });
                }

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
            PopulateProjects();
            crescent.ChooseProjectPanel.Visible = true;
        }

        public void ProjectBackButton_Click(object sender, EventArgs e)
        {
            crescent.ChooseProjectPanel.Visible = false;
            ClearProjects();
        }
        public void ProjectNextButton_Click(object sender, EventArgs e)
        {
            PopulateTasks();
            crescent.ChooseTaskPanel.Visible = true;
        }
        public void TaskBackButton_Click(object sender, EventArgs e)
        {
            crescent.ChooseTaskPanel.Visible = false;
            ClearTasks();
        }

        public void GenerateButton_Click(object sender, EventArgs e)
        {
            string msg = "Output: Debug\\stories.txt";

                foreach (CheckBox task in TaskCheckBoxes)
                {
                    if (task.Checked)
                    {
                        asana.GetStoriesInTask(TaskDictionary[task.Text], o =>
                            {
                                foreach (AsanaStory story in o)
                                {
                                    try
                                    {
                                        System.IO.File.AppendAllText("stories.txt", story.Text + story.Type + "\r\n");
                                    }
                                    catch (System.IO.IOException k){}
                                }
                                    
                            });
                    }
                }
            MessageBox.Show(msg);
        }

        private void TaskPanel_ControlAdded(object sender, EventArgs e)
        {
            if (crescent.TaskPanel.Controls.Count == tasks.Count)
            {
                crescent.TaskLoadingLabel.Text = "Done";
            }
        }
        private void ClearProjects()
        {
            projects.Clear();
            ProjectDictionary.Clear();
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
            TaskDictionary.Clear();
            crescent.TaskPanel.Controls.Clear();
            crescent.TaskPanel.Controls.Add(crescent.ProjectLoadingLabel);
            crescent.TaskLoadingLabel.Visible = true;
            crescent.TaskBackButton.Enabled = false;

        }
        private void AddTagPanelToCheckBox(CheckBox checkbox)
        {
        }
    }
}