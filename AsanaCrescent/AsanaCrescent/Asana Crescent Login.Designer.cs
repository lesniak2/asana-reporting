namespace AsanaCrescent
{
    partial class Crescent
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Crescent));
            this.APIKeyButton = new AsanaCrescent.AsanaButton();
            this.APIKeyLabel = new System.Windows.Forms.Label();
            this.APIKeyBox = new System.Windows.Forms.TextBox();
            this.AuthenticationPanel = new System.Windows.Forms.Panel();
            this.asanacrescentLogo = new System.Windows.Forms.PictureBox();
            this.ChooseWorkspacePanel = new System.Windows.Forms.Panel();
            this.ChooseProjectPanel = new System.Windows.Forms.Panel();
            this.ChooseTaskPanel = new System.Windows.Forms.Panel();
            this.GenerateCancelButton = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.TaskLoadingLabel = new System.Windows.Forms.Label();
            this.GenerateButton = new System.Windows.Forms.Button();
            this.TaskBackButton = new System.Windows.Forms.Button();
            this.TaskGroupBox = new System.Windows.Forms.GroupBox();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.TaskLabel = new System.Windows.Forms.Label();
            this.ProjectGroupBox = new System.Windows.Forms.GroupBox();
            this.ProjectPanel = new System.Windows.Forms.Panel();
            this.NothingHereProjectLabel = new System.Windows.Forms.Label();
            this.ProjectNextButton = new System.Windows.Forms.Button();
            this.ProjectBackButton = new System.Windows.Forms.Button();
            this.ProjectLabel = new System.Windows.Forms.Label();
            this.ProjectLoadingLabel = new System.Windows.Forms.Label();
            this.WorkspacesGroupBox = new System.Windows.Forms.GroupBox();
            this.WorkspacePanel = new System.Windows.Forms.Panel();
            this.WorkspaceLabel = new System.Windows.Forms.Label();
            this.WorkspaceBackButton = new System.Windows.Forms.Button();
            this.WorkspaceNextButton = new System.Windows.Forms.Button();
            this.AuthenticationPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.asanacrescentLogo)).BeginInit();
            this.ChooseWorkspacePanel.SuspendLayout();
            this.ChooseProjectPanel.SuspendLayout();
            this.ChooseTaskPanel.SuspendLayout();
            this.TaskGroupBox.SuspendLayout();
            this.ProjectGroupBox.SuspendLayout();
            this.ProjectPanel.SuspendLayout();
            this.WorkspacesGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // APIKeyButton
            // 
            this.APIKeyButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.APIKeyButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(141)))), ((int)(((byte)(214)))));
            this.APIKeyButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(96)))), ((int)(((byte)(161)))));
            this.APIKeyButton.FlatAppearance.BorderSize = 0;
            this.APIKeyButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(167)))), ((int)(((byte)(225)))));
            this.APIKeyButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(169)))), ((int)(((byte)(227)))));
            this.APIKeyButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.APIKeyButton.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.APIKeyButton.ForeColor = System.Drawing.Color.White;
            this.APIKeyButton.Location = new System.Drawing.Point(247, 131);
            this.APIKeyButton.Name = "APIKeyButton";
            this.APIKeyButton.Size = new System.Drawing.Size(60, 27);
            this.APIKeyButton.TabIndex = 2;
            this.APIKeyButton.Text = "Go";
            this.APIKeyButton.UseVisualStyleBackColor = false;
            this.APIKeyButton.Click += new System.EventHandler(this.APIKeyButton_Click);
            // 
            // APIKeyLabel
            // 
            this.APIKeyLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.APIKeyLabel.AutoSize = true;
            this.APIKeyLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.APIKeyLabel.Location = new System.Drawing.Point(33, 92);
            this.APIKeyLabel.Name = "APIKeyLabel";
            this.APIKeyLabel.Size = new System.Drawing.Size(65, 21);
            this.APIKeyLabel.TabIndex = 2;
            this.APIKeyLabel.Text = "API Key:";
            // 
            // APIKeyBox
            // 
            this.APIKeyBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.APIKeyBox.Location = new System.Drawing.Point(98, 95);
            this.APIKeyBox.Name = "APIKeyBox";
            this.APIKeyBox.Size = new System.Drawing.Size(240, 20);
            this.APIKeyBox.TabIndex = 0;
            this.APIKeyBox.TextChanged += new System.EventHandler(this.LoginUsernameBox_TextChanged);
            // 
            // AuthenticationPanel
            // 
            this.AuthenticationPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(228)))), ((int)(((byte)(234)))));
            this.AuthenticationPanel.Controls.Add(this.asanacrescentLogo);
            this.AuthenticationPanel.Controls.Add(this.ChooseWorkspacePanel);
            this.AuthenticationPanel.Controls.Add(this.APIKeyBox);
            this.AuthenticationPanel.Controls.Add(this.APIKeyButton);
            this.AuthenticationPanel.Controls.Add(this.APIKeyLabel);
            this.AuthenticationPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AuthenticationPanel.Location = new System.Drawing.Point(0, 0);
            this.AuthenticationPanel.Name = "AuthenticationPanel";
            this.AuthenticationPanel.Size = new System.Drawing.Size(396, 258);
            this.AuthenticationPanel.TabIndex = 2;
            // 
            // asanacrescentLogo
            // 
            this.asanacrescentLogo.Image = ((System.Drawing.Image)(resources.GetObject("asanacrescentLogo.Image")));
            this.asanacrescentLogo.Location = new System.Drawing.Point(29, 12);
            this.asanacrescentLogo.Name = "asanacrescentLogo";
            this.asanacrescentLogo.Size = new System.Drawing.Size(355, 50);
            this.asanacrescentLogo.TabIndex = 6;
            this.asanacrescentLogo.TabStop = false;
            this.asanacrescentLogo.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // ChooseWorkspacePanel
            // 
            this.ChooseWorkspacePanel.Controls.Add(this.ChooseProjectPanel);
            this.ChooseWorkspacePanel.Controls.Add(this.WorkspacesGroupBox);
            this.ChooseWorkspacePanel.Controls.Add(this.WorkspaceLabel);
            this.ChooseWorkspacePanel.Controls.Add(this.WorkspaceBackButton);
            this.ChooseWorkspacePanel.Controls.Add(this.WorkspaceNextButton);
            this.ChooseWorkspacePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ChooseWorkspacePanel.Location = new System.Drawing.Point(0, 0);
            this.ChooseWorkspacePanel.Name = "ChooseWorkspacePanel";
            this.ChooseWorkspacePanel.Size = new System.Drawing.Size(396, 258);
            this.ChooseWorkspacePanel.TabIndex = 5;
            this.ChooseWorkspacePanel.Visible = false;
            // 
            // ChooseProjectPanel
            // 
            this.ChooseProjectPanel.Controls.Add(this.ChooseTaskPanel);
            this.ChooseProjectPanel.Controls.Add(this.ProjectGroupBox);
            this.ChooseProjectPanel.Controls.Add(this.ProjectNextButton);
            this.ChooseProjectPanel.Controls.Add(this.ProjectBackButton);
            this.ChooseProjectPanel.Controls.Add(this.ProjectLabel);
            this.ChooseProjectPanel.Controls.Add(this.ProjectLoadingLabel);
            this.ChooseProjectPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ChooseProjectPanel.Location = new System.Drawing.Point(0, 0);
            this.ChooseProjectPanel.Name = "ChooseProjectPanel";
            this.ChooseProjectPanel.Size = new System.Drawing.Size(396, 258);
            this.ChooseProjectPanel.TabIndex = 5;
            this.ChooseProjectPanel.Visible = false;
            this.ChooseProjectPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.ChooseProjectPanel_Paint);
            // 
            // ChooseTaskPanel
            // 
            this.ChooseTaskPanel.Controls.Add(this.GenerateCancelButton);
            this.ChooseTaskPanel.Controls.Add(this.progressBar1);
            this.ChooseTaskPanel.Controls.Add(this.TaskLoadingLabel);
            this.ChooseTaskPanel.Controls.Add(this.GenerateButton);
            this.ChooseTaskPanel.Controls.Add(this.TaskBackButton);
            this.ChooseTaskPanel.Controls.Add(this.TaskGroupBox);
            this.ChooseTaskPanel.Controls.Add(this.TaskLabel);
            this.ChooseTaskPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ChooseTaskPanel.Location = new System.Drawing.Point(0, 0);
            this.ChooseTaskPanel.Name = "ChooseTaskPanel";
            this.ChooseTaskPanel.Size = new System.Drawing.Size(396, 258);
            this.ChooseTaskPanel.TabIndex = 29;
            this.ChooseTaskPanel.Visible = false;
            this.ChooseTaskPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.ChooseTaskPanel_Paint);
            // 
            // GenerateCancelButton
            // 
            this.GenerateCancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.GenerateCancelButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(141)))), ((int)(((byte)(214)))));
            this.GenerateCancelButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(96)))), ((int)(((byte)(161)))));
            this.GenerateCancelButton.FlatAppearance.BorderSize = 0;
            this.GenerateCancelButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(167)))), ((int)(((byte)(225)))));
            this.GenerateCancelButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(169)))), ((int)(((byte)(227)))));
            this.GenerateCancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GenerateCancelButton.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GenerateCancelButton.ForeColor = System.Drawing.Color.White;
            this.GenerateCancelButton.Location = new System.Drawing.Point(226, 202);
            this.GenerateCancelButton.Name = "GenerateCancelButton";
            this.GenerateCancelButton.Size = new System.Drawing.Size(141, 23);
            this.GenerateCancelButton.TabIndex = 5;
            this.GenerateCancelButton.Text = "Cancel";
            this.GenerateCancelButton.UseVisualStyleBackColor = false;
            this.GenerateCancelButton.Visible = false;
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.progressBar1.Location = new System.Drawing.Point(6, 231);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(105, 23);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 4;
            this.progressBar1.Visible = false;
            // 
            // TaskLoadingLabel
            // 
            this.TaskLoadingLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TaskLoadingLabel.AutoSize = true;
            this.TaskLoadingLabel.Location = new System.Drawing.Point(3, 234);
            this.TaskLoadingLabel.Name = "TaskLoadingLabel";
            this.TaskLoadingLabel.Size = new System.Drawing.Size(86, 13);
            this.TaskLoadingLabel.TabIndex = 0;
            this.TaskLoadingLabel.Text = "Loading Tasks...";
            // 
            // GenerateButton
            // 
            this.GenerateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.GenerateButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(141)))), ((int)(((byte)(214)))));
            this.GenerateButton.Enabled = false;
            this.GenerateButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(96)))), ((int)(((byte)(161)))));
            this.GenerateButton.FlatAppearance.BorderSize = 0;
            this.GenerateButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(167)))), ((int)(((byte)(225)))));
            this.GenerateButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(169)))), ((int)(((byte)(227)))));
            this.GenerateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GenerateButton.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GenerateButton.ForeColor = System.Drawing.Color.White;
            this.GenerateButton.Location = new System.Drawing.Point(226, 202);
            this.GenerateButton.Name = "GenerateButton";
            this.GenerateButton.Size = new System.Drawing.Size(138, 23);
            this.GenerateButton.TabIndex = 3;
            this.GenerateButton.Text = "Generate Report";
            this.GenerateButton.UseVisualStyleBackColor = false;
            // 
            // TaskBackButton
            // 
            this.TaskBackButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TaskBackButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(141)))), ((int)(((byte)(214)))));
            this.TaskBackButton.Enabled = false;
            this.TaskBackButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(96)))), ((int)(((byte)(161)))));
            this.TaskBackButton.FlatAppearance.BorderSize = 0;
            this.TaskBackButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(167)))), ((int)(((byte)(225)))));
            this.TaskBackButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(169)))), ((int)(((byte)(227)))));
            this.TaskBackButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TaskBackButton.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TaskBackButton.ForeColor = System.Drawing.Color.White;
            this.TaskBackButton.Location = new System.Drawing.Point(36, 202);
            this.TaskBackButton.Name = "TaskBackButton";
            this.TaskBackButton.Size = new System.Drawing.Size(75, 23);
            this.TaskBackButton.TabIndex = 2;
            this.TaskBackButton.Text = "Back";
            this.TaskBackButton.UseVisualStyleBackColor = false;
            // 
            // TaskGroupBox
            // 
            this.TaskGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TaskGroupBox.Controls.Add(this.tabControl);
            this.TaskGroupBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TaskGroupBox.Location = new System.Drawing.Point(33, 38);
            this.TaskGroupBox.Name = "TaskGroupBox";
            this.TaskGroupBox.Size = new System.Drawing.Size(334, 147);
            this.TaskGroupBox.TabIndex = 1;
            this.TaskGroupBox.TabStop = false;
            this.TaskGroupBox.Text = "Tasks";
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Location = new System.Drawing.Point(6, 16);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(325, 128);
            this.tabControl.TabIndex = 0;
            this.tabControl.Visible = false;
            // 
            // TaskLabel
            // 
            this.TaskLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.TaskLabel.AutoSize = true;
            this.TaskLabel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TaskLabel.Location = new System.Drawing.Point(103, 14);
            this.TaskLabel.Name = "TaskLabel";
            this.TaskLabel.Size = new System.Drawing.Size(197, 25);
            this.TaskLabel.TabIndex = 0;
            this.TaskLabel.Text = "Select Report Task(s)";
            this.TaskLabel.Click += new System.EventHandler(this.TaskLabel_Click);
            // 
            // ProjectGroupBox
            // 
            this.ProjectGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ProjectGroupBox.Controls.Add(this.ProjectPanel);
            this.ProjectGroupBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProjectGroupBox.Location = new System.Drawing.Point(33, 38);
            this.ProjectGroupBox.Name = "ProjectGroupBox";
            this.ProjectGroupBox.Size = new System.Drawing.Size(334, 147);
            this.ProjectGroupBox.TabIndex = 28;
            this.ProjectGroupBox.TabStop = false;
            this.ProjectGroupBox.Text = "Projects";
            this.ProjectGroupBox.Enter += new System.EventHandler(this.ProjectGroupBox_Enter);
            // 
            // ProjectPanel
            // 
            this.ProjectPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ProjectPanel.AutoScroll = true;
            this.ProjectPanel.Controls.Add(this.NothingHereProjectLabel);
            this.ProjectPanel.Location = new System.Drawing.Point(6, 17);
            this.ProjectPanel.Name = "ProjectPanel";
            this.ProjectPanel.Size = new System.Drawing.Size(322, 127);
            this.ProjectPanel.TabIndex = 0;
            this.ProjectPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.ProjectPanel_Paint);
            // 
            // NothingHereProjectLabel
            // 
            this.NothingHereProjectLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NothingHereProjectLabel.Location = new System.Drawing.Point(110, 54);
            this.NothingHereProjectLabel.Name = "NothingHereProjectLabel";
            this.NothingHereProjectLabel.Size = new System.Drawing.Size(151, 24);
            this.NothingHereProjectLabel.TabIndex = 0;
            this.NothingHereProjectLabel.Text = "Nothing here...";
            this.NothingHereProjectLabel.Visible = false;
            // 
            // ProjectNextButton
            // 
            this.ProjectNextButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ProjectNextButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(141)))), ((int)(((byte)(214)))));
            this.ProjectNextButton.Enabled = false;
            this.ProjectNextButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(96)))), ((int)(((byte)(161)))));
            this.ProjectNextButton.FlatAppearance.BorderSize = 0;
            this.ProjectNextButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(167)))), ((int)(((byte)(225)))));
            this.ProjectNextButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(169)))), ((int)(((byte)(227)))));
            this.ProjectNextButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ProjectNextButton.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProjectNextButton.ForeColor = System.Drawing.Color.White;
            this.ProjectNextButton.Location = new System.Drawing.Point(289, 202);
            this.ProjectNextButton.Name = "ProjectNextButton";
            this.ProjectNextButton.Size = new System.Drawing.Size(75, 23);
            this.ProjectNextButton.TabIndex = 27;
            this.ProjectNextButton.Text = "Next";
            this.ProjectNextButton.UseVisualStyleBackColor = false;
            // 
            // ProjectBackButton
            // 
            this.ProjectBackButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ProjectBackButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(141)))), ((int)(((byte)(214)))));
            this.ProjectBackButton.Enabled = false;
            this.ProjectBackButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(96)))), ((int)(((byte)(161)))));
            this.ProjectBackButton.FlatAppearance.BorderSize = 0;
            this.ProjectBackButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(167)))), ((int)(((byte)(225)))));
            this.ProjectBackButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(169)))), ((int)(((byte)(227)))));
            this.ProjectBackButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ProjectBackButton.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProjectBackButton.ForeColor = System.Drawing.Color.White;
            this.ProjectBackButton.Location = new System.Drawing.Point(36, 202);
            this.ProjectBackButton.Name = "ProjectBackButton";
            this.ProjectBackButton.Size = new System.Drawing.Size(75, 23);
            this.ProjectBackButton.TabIndex = 26;
            this.ProjectBackButton.Text = "Back";
            this.ProjectBackButton.UseVisualStyleBackColor = false;
            // 
            // ProjectLabel
            // 
            this.ProjectLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.ProjectLabel.AutoSize = true;
            this.ProjectLabel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProjectLabel.Location = new System.Drawing.Point(117, 14);
            this.ProjectLabel.Name = "ProjectLabel";
            this.ProjectLabel.Size = new System.Drawing.Size(154, 25);
            this.ProjectLabel.TabIndex = 24;
            this.ProjectLabel.Text = "Select Project(s)";
            // 
            // ProjectLoadingLabel
            // 
            this.ProjectLoadingLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ProjectLoadingLabel.AutoSize = true;
            this.ProjectLoadingLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProjectLoadingLabel.Location = new System.Drawing.Point(3, 234);
            this.ProjectLoadingLabel.Name = "ProjectLoadingLabel";
            this.ProjectLoadingLabel.Size = new System.Drawing.Size(107, 15);
            this.ProjectLoadingLabel.TabIndex = 0;
            this.ProjectLoadingLabel.Text = "Loading Projects....";
            // 
            // WorkspacesGroupBox
            // 
            this.WorkspacesGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.WorkspacesGroupBox.Controls.Add(this.WorkspacePanel);
            this.WorkspacesGroupBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WorkspacesGroupBox.Location = new System.Drawing.Point(33, 38);
            this.WorkspacesGroupBox.Name = "WorkspacesGroupBox";
            this.WorkspacesGroupBox.Size = new System.Drawing.Size(334, 147);
            this.WorkspacesGroupBox.TabIndex = 8;
            this.WorkspacesGroupBox.TabStop = false;
            this.WorkspacesGroupBox.Text = "Workspaces";
            // 
            // WorkspacePanel
            // 
            this.WorkspacePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.WorkspacePanel.Location = new System.Drawing.Point(3, 17);
            this.WorkspacePanel.Name = "WorkspacePanel";
            this.WorkspacePanel.Size = new System.Drawing.Size(328, 124);
            this.WorkspacePanel.TabIndex = 0;
            // 
            // WorkspaceLabel
            // 
            this.WorkspaceLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.WorkspaceLabel.AutoSize = true;
            this.WorkspaceLabel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WorkspaceLabel.Location = new System.Drawing.Point(117, 10);
            this.WorkspaceLabel.Name = "WorkspaceLabel";
            this.WorkspaceLabel.Size = new System.Drawing.Size(183, 25);
            this.WorkspaceLabel.TabIndex = 3;
            this.WorkspaceLabel.Text = "Select a Workspace";
            // 
            // WorkspaceBackButton
            // 
            this.WorkspaceBackButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.WorkspaceBackButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(141)))), ((int)(((byte)(214)))));
            this.WorkspaceBackButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(96)))), ((int)(((byte)(161)))));
            this.WorkspaceBackButton.FlatAppearance.BorderSize = 0;
            this.WorkspaceBackButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(167)))), ((int)(((byte)(225)))));
            this.WorkspaceBackButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(169)))), ((int)(((byte)(227)))));
            this.WorkspaceBackButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.WorkspaceBackButton.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WorkspaceBackButton.ForeColor = System.Drawing.Color.White;
            this.WorkspaceBackButton.Location = new System.Drawing.Point(36, 202);
            this.WorkspaceBackButton.Name = "WorkspaceBackButton";
            this.WorkspaceBackButton.Size = new System.Drawing.Size(75, 23);
            this.WorkspaceBackButton.TabIndex = 7;
            this.WorkspaceBackButton.Text = "Back";
            this.WorkspaceBackButton.UseVisualStyleBackColor = false;
            this.WorkspaceBackButton.Click += new System.EventHandler(this.WorkspaceBackButton_Click);
            // 
            // WorkspaceNextButton
            // 
            this.WorkspaceNextButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.WorkspaceNextButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(141)))), ((int)(((byte)(214)))));
            this.WorkspaceNextButton.Enabled = false;
            this.WorkspaceNextButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(96)))), ((int)(((byte)(161)))));
            this.WorkspaceNextButton.FlatAppearance.BorderSize = 0;
            this.WorkspaceNextButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(167)))), ((int)(((byte)(225)))));
            this.WorkspaceNextButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(169)))), ((int)(((byte)(227)))));
            this.WorkspaceNextButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.WorkspaceNextButton.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WorkspaceNextButton.ForeColor = System.Drawing.Color.White;
            this.WorkspaceNextButton.Location = new System.Drawing.Point(289, 202);
            this.WorkspaceNextButton.Name = "WorkspaceNextButton";
            this.WorkspaceNextButton.Size = new System.Drawing.Size(75, 23);
            this.WorkspaceNextButton.TabIndex = 9;
            this.WorkspaceNextButton.Text = "Next";
            this.WorkspaceNextButton.UseVisualStyleBackColor = false;
            // 
            // Crescent
            // 
            this.AcceptButton = this.APIKeyButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(226)))), ((int)(((byte)(233)))));
            this.ClientSize = new System.Drawing.Size(396, 258);
            this.Controls.Add(this.AuthenticationPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Crescent";
            this.Text = "Crescent";
            this.AuthenticationPanel.ResumeLayout(false);
            this.AuthenticationPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.asanacrescentLogo)).EndInit();
            this.ChooseWorkspacePanel.ResumeLayout(false);
            this.ChooseWorkspacePanel.PerformLayout();
            this.ChooseProjectPanel.ResumeLayout(false);
            this.ChooseProjectPanel.PerformLayout();
            this.ChooseTaskPanel.ResumeLayout(false);
            this.ChooseTaskPanel.PerformLayout();
            this.TaskGroupBox.ResumeLayout(false);
            this.ProjectGroupBox.ResumeLayout(false);
            this.ProjectPanel.ResumeLayout(false);
            this.WorkspacesGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox APIKeyBox;
        private System.Windows.Forms.Label APIKeyLabel;
        private System.Windows.Forms.Panel AuthenticationPanel;
        private System.Windows.Forms.Label WorkspaceLabel;
        private System.Windows.Forms.Panel ChooseWorkspacePanel;
        private System.Windows.Forms.Button WorkspaceBackButton;
        public System.Windows.Forms.Panel ChooseProjectPanel;
        public System.Windows.Forms.Button ProjectNextButton;
        public System.Windows.Forms.Button ProjectBackButton;
        private System.Windows.Forms.Label ProjectLabel;
        private System.Windows.Forms.GroupBox ProjectGroupBox;
        private System.Windows.Forms.GroupBox WorkspacesGroupBox;
        public System.Windows.Forms.Panel WorkspacePanel;
        public System.Windows.Forms.Button WorkspaceNextButton;
        public System.Windows.Forms.Label ProjectLoadingLabel;
        public System.Windows.Forms.Panel ChooseTaskPanel;
        private System.Windows.Forms.Label TaskLabel;
        private System.Windows.Forms.GroupBox TaskGroupBox;
        public System.Windows.Forms.Button GenerateButton;
        public System.Windows.Forms.Button TaskBackButton;
        public System.Windows.Forms.Label TaskLoadingLabel;
        public System.Windows.Forms.TabControl tabControl;
        public System.Windows.Forms.ProgressBar progressBar1;
        public System.Windows.Forms.Button GenerateCancelButton;
        private AsanaButton APIKeyButton;
        public System.Windows.Forms.Panel ProjectPanel;
        public System.Windows.Forms.Label NothingHereProjectLabel;
        private System.Windows.Forms.PictureBox asanacrescentLogo;
    }
}