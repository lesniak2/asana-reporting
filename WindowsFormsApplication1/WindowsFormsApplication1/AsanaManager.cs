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
            if (o is AsanaTask)
            {
                test.Text = ((AsanaTask)o).Name;
                TaskCheckBoxes.Add(test);
            }
            else if (o is AsanaProject)
            {
                test.Text = ((AsanaProject)o).Name;
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
            }).Wait();
            crescent.WorkspaceNextButton.Click += new System.EventHandler(this.WorkspaceNextButton_Click);
            crescent.ChooseProjectBackButton.Click += new System.EventHandler(this.ProjectBackButton_Click);
            crescent.WorkspacePanel.Refresh();
        }

        public void PopulateProjects()
        {
            yLoc = 0;
            try
            {
                Thread t = new Thread(() =>
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
                                    { crescent.ProjectLoadingLabel.Text = "Nothing here..."; }));
                            }
                            else 
                                crescent.ProjectLoadingLabel.Text = "Nothing here...";
                        }
                        else
                        {
                            if (crescent.ProjectLoadingLabel.InvokeRequired)
                            {
                                crescent.ProjectLoadingLabel.Invoke(new Action(() =>
                                { crescent.ProjectLoadingLabel.Visible = false; }));
                            }
                            else
                                crescent.ProjectLoadingLabel.Visible = false;
                        }
                    })
                );
                t.Start();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }

        public void PopulateTasks()
        {

        }

        private void WorkspaceCheckBox_CheckChanged(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Checked == true)
            {
                this.CurrentWorkspaceName = ((CheckBox)sender).Text;
                foreach (CheckBox checkbox in WorkspaceCheckBoxes)
                {
                    if (checkbox != sender)
                    {
                        checkbox.Checked = false;
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

        private void ClearProjects()
        {
            projects.Clear();
            ProjectDictionary.Clear();
            crescent.ProjectPanel.Controls.Clear();
            // 
            // ProjectLoadingLabel
            // 
            crescent.ProjectPanel.Controls.Add(crescent.ProjectLoadingLabel);
            crescent.ProjectLoadingLabel.Visible = true;
            
        }
    }
}
