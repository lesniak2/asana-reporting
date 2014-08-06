using System;
using System.Collections.Generic;
using System.Collections;
using System.Windows.Forms;
using System.Threading;
using System.ComponentModel;
using AsanaNet;
namespace AsanaCrescent
{
    enum AsanaManager
    {
        PopulateWorkspaces,
        PopulateProjects,
        PopulateTasks,
        Cancelled
    };

    public partial class Crescent : Form
    {
        public Crescent()
        {
            InitializeComponent();
            asana = null;

            tasks = new ArrayList();
            projects = new ArrayList();
            workspaces = new ArrayList();

            TaskCheckBoxes = new ArrayList();
            ProjectCheckBoxes = new ArrayList();
            WorkspaceCheckBoxes = new ArrayList();
            TaskConnectionEnded = new ArrayList();

            TaskDictionary = new Dictionary<long, AsanaTask>();
            ProjectDictionary = new Dictionary<string, AsanaProject>();
            WorkspaceDictionary = new Dictionary<string, AsanaWorkspace>();
            TaskProjectDictionary = new Dictionary<AsanaTask, AsanaProject>();
            ProjectTabDictionary = new Dictionary<AsanaProject, int>();
            ProjectExcelDictionary = new Dictionary<string, ProjectInExcel>();

            ProjectAllCheckBox = new CheckBox();
            TaskAllCheckBox = new ArrayList();
            selectedProjects = new ArrayList();

            TaskYLoc = new ArrayList();
            tags = new ArrayList();

            this.APIKeyButton.Click += new System.EventHandler(this.APIKeyButton_Click);
            this.WorkspaceBackButton.Click += new System.EventHandler(this.WorkspaceBackButton_Click);
            this.WorkspaceNextButton.Click += new System.EventHandler(this.WorkspaceNextButton_Click);
            this.ProjectBackButton.Click += new System.EventHandler(this.ProjectBackButton_Click);
            this.ProjectNextButton.Click += new System.EventHandler(this.ProjectNextButton_Click);
            this.TaskBackButton.Click += new System.EventHandler(this.TaskBackButton_Click);
            this.GenerateButton.Click += new System.EventHandler(this.GenerateButton_Click);
            this.GenerateCancelButton.Click += new System.EventHandler(this.GenerateCancelButton_Click);
            this.KeyPress += new KeyPressEventHandler(this.Crescent_KeyPressed);

            GeneralWorker = new BackgroundWorker();
            GeneralWorker.WorkerReportsProgress = false;
            GeneralWorker.WorkerSupportsCancellation = true;
            GeneralWorker.DoWork += new DoWorkEventHandler(bw_DoWork);
            GeneralWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);

            ReportGenerator = new BackgroundWorker();
            ReportGenerator.WorkerReportsProgress = true;
            ReportGenerator.WorkerSupportsCancellation = true;
            ReportGenerator.DoWork += new DoWorkEventHandler(bw_GenerateReport);
            ReportGenerator.ProgressChanged += new ProgressChangedEventHandler(bw_GenerateReportProgressChanged);
            ReportGenerator.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_GenerateReportRunWorkerCompleted);

        }
        /// <summary>
        /// Set up the connection with Asana using an APIKey and the AsanaNet Library
        /// </summary>
        /// <param name="APIKey"></param>
        private void SetAsanaConnection(String APIKey)
        {
            asana = null;
            asana = new Asana(APIKey, AuthenticationType.Basic, (s1, s2, s3) => { });
        }
        /// <summary>
        /// Adds a CheckBox to either the WorkspacePanel or the ProjectPanel. Vertical Y location
        /// is kept track by an arraylist.
        /// </summary>
        /// <param name="o"></param>
        /// <param name="panel"></param>
        private void AddCheckbox(AsanaObject o, Panel panel)
        {
            if (GeneralWorker.CancellationPending)
                return;
            CheckBox checkbox = new CheckBox();
            checkbox.AutoSize = true;
            checkbox.Location = new System.Drawing.Point(6, 5 + yLoc);
            yLoc += 25;
            checkbox.Size = new System.Drawing.Size(80, 17);
            checkbox.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            if (o is AsanaProject)
            {
                checkbox.Text = ((AsanaProject)o).Name;
                checkbox.Name = "" + ((AsanaProject)o).ID;
                checkbox.CheckedChanged += new System.EventHandler(this.ProjectCheckBox_CheckChanged);
                ProjectCheckBoxes.Add(checkbox);
            }
            else if (o is AsanaWorkspace)
            {
                checkbox.Text = ((AsanaWorkspace)o).Name;
                checkbox.Name = "" + ((AsanaWorkspace)o).ID;
                checkbox.CheckedChanged += new System.EventHandler(this.WorkspaceCheckBox_CheckChanged);
                WorkspaceCheckBoxes.Add(checkbox);
            }
            panel.Invoke(new Action(() => { panel.Controls.Add(checkbox); }));
        }
        /// <summary>
        /// Adds a CheckBox to a specific tab in the tabcontrol for tasks.
        /// </summary>
        /// <param name="task"></param>
        /// <param name="TabIndex"></param>
        private void AddTabCheckbox(AsanaTask task, int TabIndex)
        {
            if (!GeneralWorker.CancellationPending)
            {
                CheckBox checkbox = new CheckBox();
                checkbox.Text = task.Name;
                checkbox.AutoSize = true;
                checkbox.Name = "" + task.ID;
                checkbox.Location = new System.Drawing.Point(6, (int)TaskYLoc[TabIndex] + 25);
                checkbox.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                TaskYLoc[TabIndex] = (int)TaskYLoc[TabIndex] + 25;
                TaskCheckBoxes.Add(checkbox);
                checkbox.CheckedChanged += new System.EventHandler(this.TaskCheckBox_CheckChanged);
                this.tabControl.Invoke(new Action(() => { this.tabControl.TabPages[TabIndex].Controls.Add(checkbox); }));
            }
        }

        /// <summary>
        /// Gets a list of worskpaces from Asana and displays them in the WorkspacePanel
        /// from which the user can select.
        /// </summary>
        public void bw_PopulateWorkspaces(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            yLoc = 0;
            this.WorkspaceLoadingLabel.Invoke(new Action(() =>
            {
                this.WorkspaceLoadingLabel.Text = "Loading workspaces...";
            }));
            asana.GetWorkspaces(o =>
            {
                foreach (AsanaWorkspace workspace in o)
                {
                    if (worker.CancellationPending)
                        break;
                    workspaces.Add(workspace);
                    WorkspaceDictionary.Add(workspace.Name, workspace);
                    this.AddCheckbox(workspace, this.WorkspacePanel);
                }
            }).Wait();
        }

        /// <summary>
        /// Connects to Asana and populates the Workspaces
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void APIKeyButton_Click(object sender, EventArgs e)
        {
            this.asanacrescentLogo.Visible = false;
            this.SetAsanaConnection(this.APIKeyBox.Text);
            this.ClientSize = new System.Drawing.Size(396, 455);
            this.ChooseWorkspacePanel.Visible = true;
            this.ChooseWorkspacePanel.Focus();
            GeneralWorker.RunWorkerAsync(AsanaManager.PopulateWorkspaces);
        }

        /// <summary>
        /// Cancels the population of workspaces if ongoing
        /// and returns to the authentication screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WorkspaceBackButton_Click(object sender, EventArgs e)
        {
            if (GeneralWorker.IsBusy)
            {
                GeneralWorker.CancelAsync();
                _resetEvent.WaitOne();
            }
            this.WorkspacePanel.Controls.Clear();
            this.WorkspaceCheckBoxes.Clear();
            this.workspaces.Clear();
            this.WorkspaceDictionary.Clear();
            this.ClientSize = new System.Drawing.Size(396, 258);
            this.ChooseWorkspacePanel.Visible = false;
            this.asanacrescentLogo.Visible = true;
            this.WorkspaceNextButton.Enabled = false;
            this.AuthenticationPanel.Focus();
        }

        /// <summary>
        /// Get a list of all the tags within the workspace.
        /// </summary>
        public void GetWorkspaceTags()
        {
            asana.GetTagsInWorkspace(WorkspaceDictionary[this.CurrentWorkspaceName], o =>
            {
                foreach (AsanaTag tag in o)
                    tags.Add(tag.Name);

            }).Wait();
        }

        /// <summary>
        /// Populate the list of projects as checkboxes in the project panel.
        /// </summary>
        public void bw_PopulateProjects(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            this.Invoke(new Action(() =>
            {

                this.ProjectLoadingLabel.Text = "Loading projects...";
                yLoc = 0;

                //Add a checkbox to select All

                ProjectAllCheckBox.AutoSize = true;
                ProjectAllCheckBox.Location = new System.Drawing.Point(0, 3);
                yLoc += 20;
                ProjectAllCheckBox.Size = new System.Drawing.Size(80, 17);
                ProjectAllCheckBox.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
                    if (worker.CancellationPending)
                        break;
                    projects.Add(project);
                    ProjectDictionary.Add(project.Name, project);
                    this.AddCheckbox(project, this.ProjectPanel);
                }
            }).Wait();


        }
        /// <summary>
        /// Populate the list of tasks in each of the projects and place them
        /// in their correct tab in the tabcontrol.
        /// </summary>
        public void bw_PopulateTasks(object sender, DoWorkEventArgs ev)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            this.Invoke(new Action(() =>
            {
                this.TaskLoadingLabel.Text = "Loading tasks...";
                TaskYLoc.Clear();
            }));
            foreach (AsanaProject project in selectedProjects)
                TaskConnectionEnded.Add(false);
            //Add a checkbox to select All for each project
            foreach (AsanaProject project in selectedProjects)
            {
                CheckBox all = new CheckBox();
                all.AutoSize = true;
                all.Location = new System.Drawing.Point(0, 3);
                all.Checked = false;
                all.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                all.Name = project.Name;
                all.Size = new System.Drawing.Size(80, 17);
                all.UseVisualStyleBackColor = true;
                all.Text = "All";
                all.CheckedChanged += new System.EventHandler(this.TaskAllCheckBox_CheckChanged);
                TaskAllCheckBox.Add(all);
                TaskYLoc.Add(3);

                TabPage tab = new TabPage(project.Name);
                tab.Controls.Add(all);
                tab.AutoScroll = true;

                this.tabControl.Invoke(new Action(() =>
                { this.tabControl.TabPages.Add(tab); }));

            }
            // Add tasks based on selected projects
            int j = 0;
            foreach (AsanaProject project in selectedProjects)
            {
                if (worker.CancellationPending)
                {
                    //         for (int i = 0; i < TaskConnectionEnded.Count; i++)
                    //             TaskConnectionEnded[i] = true;
                    break;
                }
                ProjectInExcel excelproj = new ProjectInExcel();
                ProjectExcelDictionary.Add(project.Name, excelproj);
                asana.GetTasksInAProject(project, o =>
                {
                    int tmp = j;

                    foreach (AsanaTask task in o)
                    {
                        if (worker.CancellationPending)
                            break;
                        if (!task.Name.EndsWith(":")) // sections in asana end with ":"
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
                                    // get the correct tab page for the project
                                    for (i = 0; i < tc.TabCount && tc.TabPages[i].Text != project.Name; i++)
                                        ;
                                    if (tc.TabCount > 0)
                                        this.AddTabCheckbox(task, i);
                                }));

                            }
                        }
                        else // add it to the columns and tabs in the tabcontrol
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

                        //       TaskConnectionEnded[tmp] = true;
                    }
                }).Wait();

            }

        }
        /// <summary>
        /// Allows the user to progress to the next screen if at least one project is selected.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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


        /// <summary>
        /// User is allowed to generate reports if everything is done loading
        /// and at least one box is checked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TaskCheckBox_CheckChanged(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Checked && this.TaskLoadingLabel.Text == "Done")
            {
                this.GenerateButton.Enabled = true;
                return;
            }
            else
            {
                foreach (CheckBox task in TaskCheckBoxes)
                {
                    if (task.Checked && this.TaskLoadingLabel.Text == "Done")
                    {
                        this.GenerateButton.Enabled = true;
                        return;
                    }
                }
            }
            this.GenerateButton.Enabled = false;
        }
        /// <summary>
        /// Allows the user to progress to the project screen
        /// if exactly one workspace is selected.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WorkspaceCheckBox_CheckChanged(object sender, EventArgs e)
        {
            this.WorkspaceNextButton.Enabled = false;

            // if the user selects a different workspace (i.e. didnt click the same one twice)
            if (((CheckBox)sender).Checked == true)
            {
                this.WorkspaceNextButton.Enabled = true;
                this.CurrentWorkspaceName = ((CheckBox)sender).Text;
                // set all workspaces other than the one selected to be unchecked
                foreach (CheckBox checkbox in WorkspaceCheckBoxes)
                {
                    if (checkbox != sender)
                    {
                        checkbox.Checked = false;
                    }
                }
                // check if at least one checkbox is selected
                foreach (CheckBox checkbox in WorkspaceCheckBoxes)
                {
                    if (checkbox.Checked == true)
                    {
                        this.WorkspaceNextButton.Enabled = true;
                        return;
                    }
                }
            }
        }
        /// <summary>
        /// Populates and shows the Projects screen.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void WorkspaceNextButton_Click(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.ClientSize = new System.Drawing.Size(396, 455);
            this.ChooseProjectPanel.Visible = true;
            this.ChooseProjectPanel.Focus();
            GeneralWorker.RunWorkerAsync(AsanaManager.PopulateProjects);
        }
        /// <summary>
        /// Cancels the population of projects if ongoing
        /// and return to the workspace screen.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ProjectBackButton_Click(object sender, EventArgs e)
        {
            if (GeneralWorker.IsBusy)
            {
                GeneralWorker.CancelAsync();
                _resetEvent.WaitOne();
            }
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(396, 455);
            ProjectAllCheckBox.Checked = false;
            this.ChooseProjectPanel.Visible = false;
            this.ChooseWorkspacePanel.Focus();
            tags.Clear();
            ClearProjects();
        }
        /// <summary>
        /// Populates and shows the tabcontrol and tasks.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            this.ChooseTaskPanel.Visible = true;
            this.ChooseTaskPanel.Focus();
            this.TaskBackButton.Enabled = true;
            this.FindForm().WindowState = FormWindowState.Maximized;
            this.tabControl.Visible = true;
            GeneralWorker.RunWorkerAsync(AsanaManager.PopulateTasks);

        }
        /// <summary>
        /// Cancels the population of tasks if still ongoing
        /// and returns to the projects screen.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void TaskBackButton_Click(object sender, EventArgs e)
        {
            if (GeneralWorker.IsBusy)
            {
                GeneralWorker.CancelAsync();
                _resetEvent.WaitOne();
            }
            this.ChooseTaskPanel.Visible = false;
            this.GenerateButton.Enabled = false;
            this.ChooseProjectPanel.Focus();
            this.FindForm().WindowState = FormWindowState.Normal;
            this.tabControl.TabPages.Clear();
            this.tabControl.Controls.Clear();
            ClearTasks();
        }
        /// <summary>
        /// Calls the background worker to start generating the report
        /// and sets a cancel button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void GenerateButton_Click(object sender, EventArgs e)
        {
            this.GenerateButton.Visible = false;
            this.GenerateCancelButton.Visible = true;
            this.TaskBackButton.Enabled = false;

            this.progressBar1.Visible = true;
            ReportGenerator.RunWorkerAsync();
        }
        /// <summary>
        /// Resets the state of projects within this instance.
        /// </summary>
        private void ClearProjects()
        {
            projects.Clear();
            ProjectDictionary.Clear();
            ProjectCheckBoxes.Clear();
            this.ProjectPanel.Controls.Clear();
            this.ProjectNextButton.Enabled = false;
        }
        /// <summary>
        /// Resets the state of tasks within this instance.
        /// </summary>
        private void ClearTasks()
        {
            tasks.Clear();
            TaskProjectDictionary.Clear();
            TaskCheckBoxes.Clear();
            TaskDictionary.Clear();
            this.tabControl.TabPages.Clear();
            this.tabControl.Controls.Clear();
        }
        /// <summary>
        /// Handles the "All" checkbox logic for projects. When checked,
        /// check everything. Otherwise uncheck everything.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Handles the "All" checkbox logic for tasks. When checked,
        /// check all tasks within the current project tab. Otherwise,
        /// uncheck all tasks within the current project tab.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// The asynchronous handler for everything but report generation.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            _resetEvent.Reset();
            bw_state = (int)e.Argument;
            switch ((int)e.Argument)
            {
                case (int)AsanaManager.PopulateWorkspaces:
                    this.bw_PopulateWorkspaces(sender, e);
                    break;
                case (int)AsanaManager.PopulateProjects:
                    this.bw_PopulateProjects(sender, e);
                    break;
                case (int)AsanaManager.PopulateTasks:
                    this.bw_PopulateTasks(sender, e);
                    break;
                case (int)AsanaManager.Cancelled:
                    break;
                default:
                    break;
            }
            //unblock any waiting threads
            _resetEvent.Set();

        }
        /// <summary>
        /// Gui logic for the completion of the general worker's
        /// asynchronous calls.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled == true)
                bw_state = (int)AsanaManager.Cancelled;
            BackgroundWorker worker = sender as BackgroundWorker;
            switch (bw_state)
            {
                case (int)AsanaManager.PopulateWorkspaces:
                    this.WorkspaceLoadingLabel.Invoke(new Action(() =>
                        { this.WorkspaceLoadingLabel.Text = "Done"; }));
                    break;

                case (int)AsanaManager.PopulateProjects:
                    this.ProjectLoadingLabel.Invoke(new Action(() =>
                        { this.ProjectLoadingLabel.Text = "Done"; }));
                    break;

                case (int)AsanaManager.PopulateTasks:
                    this.TaskLoadingLabel.Invoke(new Action(() =>
                        {
                            this.TaskLoadingLabel.Text = "Done";
                            this.GenerateButton.Enabled = false;
                            foreach (CheckBox task in TaskCheckBoxes)
                            {
                                if (task.Checked)
                                {
                                    this.GenerateButton.Enabled = true;
                                }
                            }
                        }));
                    break;
                case (int)AsanaManager.Cancelled:
                    break;
                default:
                    break;
            }

        }
        /// <summary>
        /// Generates a report by consolidating the workspaces, projects,
        /// tasks, tags, and stories and exporting them into a formatted Excel
        /// document. Reports are saved in a folder "reports".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bw_GenerateReport(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            this.GetWorkspaceTags();

            //set up excel
            excel = new ExcelMaster();
            excel.SetWorksheets(selectedProjects);

            foreach (AsanaProject project in selectedProjects)
            {
                string col = project.Name;
                // excel doesn't like worksheet names with these characters
                col = col.Replace(":", "");
                col = col.Replace("/", " ");
                col = col.Replace("\\", " ");
                excel.SetColumns((string[])ProjectExcelDictionary[project.Name].Columns.ToArray(typeof(string)), col);
            }

            ArrayList Stories = new ArrayList();
            int i = 0;
            int total = TaskCheckBoxes.Count;
            //throw every selected task in excel, row by row
            //TODO: (someday) Implement adding ranges of multiple rows at once
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
        /// <summary>
        /// Updates the progress bar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bw_GenerateReportProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.progressBar1.Value = e.ProgressPercentage;
        }
        /// <summary>
        /// Closes and saves (or just closes) the excel report,
        /// then resets the buttons in the tasks screen.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            this.progressBar1.Visible = false;
            this.progressBar1.Value = 0;
            this.GenerateButton.Visible = true;
            this.GenerateCancelButton.Visible = false;
            this.TaskBackButton.Enabled = true;
        }
        /// <summary>
        /// Stops the report from generating.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GenerateCancelButton_Click(object sender, EventArgs e)
        {
            if (ReportGenerator.WorkerSupportsCancellation)
            {
                ReportGenerator.CancelAsync();
            }
        }
        /// <summary>
        /// Disables the "Enter" key from doing anything.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Crescent_KeyPressed(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                e.Handled = true;
        }



        private AutoResetEvent _resetEvent = new AutoResetEvent(false);
        private int yLoc = 0;
        private int bw_state;
        private string CurrentWorkspaceName;
        private Asana asana;
        private ExcelMaster excel;
        private ArrayList tasks;
        private ArrayList projects;
        private ArrayList workspaces;
        private ArrayList TaskCheckBoxes;
        private ArrayList ProjectCheckBoxes;
        private ArrayList WorkspaceCheckBoxes;
        private ArrayList TaskConnectionEnded;
        private Dictionary<long, AsanaTask> TaskDictionary;
        private Dictionary<string, AsanaProject> ProjectDictionary;
        private Dictionary<string, AsanaWorkspace> WorkspaceDictionary;
        private Dictionary<AsanaTask, AsanaProject> TaskProjectDictionary;
        private Dictionary<AsanaProject, int> ProjectTabDictionary;
        private Dictionary<string, ProjectInExcel> ProjectExcelDictionary;
        private CheckBox ProjectAllCheckBox;
        private ArrayList TaskAllCheckBox;
        private ArrayList tags;
        private ArrayList selectedProjects;
        private ArrayList TaskYLoc;
        private BackgroundWorker ReportGenerator;
        private BackgroundWorker GeneralWorker;

    }
}