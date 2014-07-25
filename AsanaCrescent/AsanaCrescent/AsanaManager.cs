﻿using System;
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
        private Dictionary<long, AsanaTask> TaskDictionary;
        private Dictionary<AsanaTask, AsanaProject> TaskProjectDictionary;
        private string CurrentWorkspaceName;
        private CheckBox ProjectAllCheckBox;
        private CheckBox TaskAllCheckBox;
        private ArrayList ColumnNames;
        private ExcelMaster excel;
        private ArrayList tags;
        private ArrayList selectedProjects;
        private Object lock1;
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
            TaskDictionary = new Dictionary<long,AsanaTask>();
            TaskProjectDictionary = new Dictionary<AsanaTask,AsanaProject>();
            ProjectAllCheckBox = new CheckBox();
            TaskAllCheckBox = new CheckBox();
            ColumnNames = new ArrayList();
            selectedProjects = new ArrayList();
            excel = new ExcelMaster();
            tags = new ArrayList();
            lock1 = new Object();
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
                yLoc += 25;                         // TODO: Adjust to 50 after demo
            else 
                yLoc += 25;
            test.Size = new System.Drawing.Size(80, 17);
            test.TabIndex = 1;
            test.UseVisualStyleBackColor = true;
            if (o is AsanaTask)
            {
                test.Text = ((AsanaTask)o).Name;
                test.Name = "" + ((AsanaTask)o).ID;
                TaskCheckBoxes.Add(test);
                test.CheckedChanged += new System.EventHandler(this.TaskCheckBox_CheckChanged);
            }
            else if (o is AsanaProject)
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
            yLoc = 0;
            //Add a checkbox to select All

            TaskAllCheckBox.AutoSize = true;
            TaskAllCheckBox.Location = new System.Drawing.Point(3, 5 + yLoc);
            TaskAllCheckBox.Checked = false;
            yLoc += 20;
            TaskAllCheckBox.Size = new System.Drawing.Size(80, 17);
            TaskAllCheckBox.TabIndex = 1;
            TaskAllCheckBox.UseVisualStyleBackColor = true;
            TaskAllCheckBox.Text = "All";
            TaskAllCheckBox.CheckedChanged += new System.EventHandler(this.TaskAllCheckBox_CheckChanged);

            if (crescent.TaskPanel.InvokeRequired)
            {
                crescent.TaskPanel.Invoke(new Action(() => { crescent.TaskPanel.Controls.Add(TaskAllCheckBox); }));
            }
            else
            {
                crescent.TaskPanel.Controls.Add(TaskAllCheckBox);
            }
            // Add tasks based on selected projects
            crescent.TaskLoadingLabel.Text = "Loading Tasks...";
            int worksheetNum = 0;
            foreach(CheckBox project in ProjectCheckBoxes)
            {
                if(project.Checked == true)
                {
                    // Add "Task" and "Project" columns
                    AsanaProject lastProject = null;
                    AsanaProject curProject = ProjectDictionary[project.Text];
                    lock (lock1)
                    {
                        asana.GetTasksInAProject(curProject, o =>
                        {
                            ColumnNames.Clear();
                            ColumnNames.Add("Task");
                            ColumnNames.Add("Project");
                            ColumnNames.Add("Added To Project");
                            ColumnNames.Add("Due");
                            ColumnNames.Add("Completed");
                            ColumnNames.Add("Assignee");
                            ColumnNames.Add("Tags");
                            foreach (AsanaTask task in o)
                            {
                                if (!task.Name.EndsWith(":"))
                                {
                                    if (!TaskDictionary.ContainsKey(task.ID)) // prevent duplicate keys
                                    {
                                        TaskProjectDictionary.Add(task, ProjectDictionary[project.Text]);
                                        TaskDictionary.Add(task.ID, task);
                                        tasks.Add(task);
                                    }
                                }
                                else
                                {
                                    bool flag = false;
                                    foreach (string name in ColumnNames)
                                    {
                                        if (name == task.Name.Substring(0, task.Name.Length - 1))
                                            flag = true;
                                    }
                                    if (!flag)
                                    {
                                        ColumnNames.Add(task.Name.Substring(0, task.Name.Length - 1));
                                    }
                                }
                            }
                            if (lastProject != curProject)
                                worksheetNum++;
                            excel.SetColumns((string[])ColumnNames.ToArray(typeof(string)), worksheetNum);
                            foreach (AsanaTask task in tasks)
                            {
                                this.AddCheckbox(task, crescent.TaskPanel);
                            }
                        });
                    }
                }

            }

            if (crescent.TaskBackButton.InvokeRequired)
            {
                crescent.TaskBackButton.Invoke(new Action(() =>
                { crescent.TaskBackButton.Enabled = true; }));
            }
            else
                crescent.TaskBackButton.Enabled = true;
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
            asana.GetTagsInWorkspace(WorkspaceDictionary[this.CurrentWorkspaceName], o =>
            {
                foreach (AsanaTag tag in o)
                    tags.Add(tag.Name);

            }).Wait();
            crescent.ChooseProjectPanel.Visible = true;
        }

        public void ProjectBackButton_Click(object sender, EventArgs e)
        {
            crescent.ChooseProjectPanel.Visible = false;
            tags.Clear();
            ClearProjects();
        }
        public void ProjectNextButton_Click(object sender, EventArgs e)
        {
            selectedProjects.Clear();
            foreach (CheckBox project in ProjectCheckBoxes)
            {
                if (project.Checked)
                {
                    selectedProjects.Add(ProjectDictionary[project.Text]);
                }
            }
            excel.SetWorksheets(selectedProjects);
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
            ArrayList Stories = new ArrayList();
            foreach (CheckBox task in TaskCheckBoxes)
                {
                
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
                }

                excel.SaveAndClose();
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
                    task.Checked = true;
                }
                return;
            }

            foreach (CheckBox task in TaskCheckBoxes)
            {
                task.Checked = false;
            }

        }
    }
}