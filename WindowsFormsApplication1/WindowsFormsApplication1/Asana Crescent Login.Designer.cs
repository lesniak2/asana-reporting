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
            this.LoginLabel = new System.Windows.Forms.Label();
            this.LoginEnterButton = new System.Windows.Forms.Button();
            this.LoginPasswordBox = new System.Windows.Forms.MaskedTextBox();
            this.LoginPasswordLabel = new System.Windows.Forms.Label();
            this.LoginUsernameLabel = new System.Windows.Forms.Label();
            this.LoginUsernameBox = new System.Windows.Forms.TextBox();
            this.LoginPanel = new System.Windows.Forms.Panel();
            this.ChooseWorkspacePanel = new System.Windows.Forms.Panel();
            this.ChooseProjectPanel = new System.Windows.Forms.Panel();
            this.ProjectGroupBox = new System.Windows.Forms.GroupBox();
            this.ProjectPanel = new System.Windows.Forms.Panel();
            this.ProjectLoadingLabel = new System.Windows.Forms.Label();
            this.ChooseProjectNextButton = new System.Windows.Forms.Button();
            this.ChooseProjectBackButton = new System.Windows.Forms.Button();
            this.ChooseProjectLabel = new System.Windows.Forms.Label();
            this.WorkspacesGroupBox = new System.Windows.Forms.GroupBox();
            this.WorkspacePanel = new System.Windows.Forms.Panel();
            this.WorkspaceLabel = new System.Windows.Forms.Label();
            this.WorkspaceBackButton = new System.Windows.Forms.Button();
            this.WorkspaceNextButton = new System.Windows.Forms.Button();
            this.LoginPanel.SuspendLayout();
            this.ChooseWorkspacePanel.SuspendLayout();
            this.ChooseProjectPanel.SuspendLayout();
            this.ProjectGroupBox.SuspendLayout();
            this.ProjectPanel.SuspendLayout();
            this.WorkspacesGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // LoginLabel
            // 
            this.LoginLabel.AutoSize = true;
            this.LoginLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoginLabel.Location = new System.Drawing.Point(3, 3);
            this.LoginLabel.Name = "LoginLabel";
            this.LoginLabel.Size = new System.Drawing.Size(89, 18);
            this.LoginLabel.TabIndex = 0;
            this.LoginLabel.Text = "Asana Login";
            // 
            // LoginEnterButton
            // 
            this.LoginEnterButton.Location = new System.Drawing.Point(182, 195);
            this.LoginEnterButton.Name = "LoginEnterButton";
            this.LoginEnterButton.Size = new System.Drawing.Size(75, 23);
            this.LoginEnterButton.TabIndex = 2;
            this.LoginEnterButton.Text = "Enter";
            this.LoginEnterButton.UseVisualStyleBackColor = true;
            this.LoginEnterButton.Click += new System.EventHandler(this.loginEnter_Click);
            // 
            // LoginPasswordBox
            // 
            this.LoginPasswordBox.Location = new System.Drawing.Point(11, 141);
            this.LoginPasswordBox.Name = "LoginPasswordBox";
            this.LoginPasswordBox.Size = new System.Drawing.Size(171, 20);
            this.LoginPasswordBox.TabIndex = 4;
            // 
            // LoginPasswordLabel
            // 
            this.LoginPasswordLabel.AutoSize = true;
            this.LoginPasswordLabel.Location = new System.Drawing.Point(8, 125);
            this.LoginPasswordLabel.Name = "LoginPasswordLabel";
            this.LoginPasswordLabel.Size = new System.Drawing.Size(53, 13);
            this.LoginPasswordLabel.TabIndex = 3;
            this.LoginPasswordLabel.Text = "Password";
            // 
            // LoginUsernameLabel
            // 
            this.LoginUsernameLabel.AutoSize = true;
            this.LoginUsernameLabel.Location = new System.Drawing.Point(8, 61);
            this.LoginUsernameLabel.Name = "LoginUsernameLabel";
            this.LoginUsernameLabel.Size = new System.Drawing.Size(55, 13);
            this.LoginUsernameLabel.TabIndex = 2;
            this.LoginUsernameLabel.Text = "Username";
            // 
            // LoginUsernameBox
            // 
            this.LoginUsernameBox.Location = new System.Drawing.Point(11, 77);
            this.LoginUsernameBox.Name = "LoginUsernameBox";
            this.LoginUsernameBox.Size = new System.Drawing.Size(171, 20);
            this.LoginUsernameBox.TabIndex = 0;
            // 
            // LoginPanel
            // 
            this.LoginPanel.Controls.Add(this.ChooseWorkspacePanel);
            this.LoginPanel.Controls.Add(this.LoginUsernameBox);
            this.LoginPanel.Controls.Add(this.LoginLabel);
            this.LoginPanel.Controls.Add(this.LoginPasswordLabel);
            this.LoginPanel.Controls.Add(this.LoginPasswordBox);
            this.LoginPanel.Controls.Add(this.LoginEnterButton);
            this.LoginPanel.Controls.Add(this.LoginUsernameLabel);
            this.LoginPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LoginPanel.Location = new System.Drawing.Point(0, 0);
            this.LoginPanel.Name = "LoginPanel";
            this.LoginPanel.Size = new System.Drawing.Size(375, 355);
            this.LoginPanel.TabIndex = 2;
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
            this.ChooseWorkspacePanel.Size = new System.Drawing.Size(375, 355);
            this.ChooseWorkspacePanel.TabIndex = 5;
            this.ChooseWorkspacePanel.Visible = false;
            // 
            // ChooseProjectPanel
            // 
            this.ChooseProjectPanel.Controls.Add(this.ProjectGroupBox);
            this.ChooseProjectPanel.Controls.Add(this.ChooseProjectNextButton);
            this.ChooseProjectPanel.Controls.Add(this.ChooseProjectBackButton);
            this.ChooseProjectPanel.Controls.Add(this.ChooseProjectLabel);
            this.ChooseProjectPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ChooseProjectPanel.Location = new System.Drawing.Point(0, 0);
            this.ChooseProjectPanel.Name = "ChooseProjectPanel";
            this.ChooseProjectPanel.Size = new System.Drawing.Size(375, 355);
            this.ChooseProjectPanel.TabIndex = 5;
            this.ChooseProjectPanel.Visible = false;
            // 
            // ProjectGroupBox
            // 
            this.ProjectGroupBox.Controls.Add(this.ProjectPanel);
            this.ProjectGroupBox.Location = new System.Drawing.Point(33, 38);
            this.ProjectGroupBox.Name = "ProjectGroupBox";
            this.ProjectGroupBox.Size = new System.Drawing.Size(309, 246);
            this.ProjectGroupBox.TabIndex = 28;
            this.ProjectGroupBox.TabStop = false;
            this.ProjectGroupBox.Text = "Projects";
            // 
            // ProjectPanel
            // 
            this.ProjectPanel.AutoScroll = true;
            this.ProjectPanel.Controls.Add(this.ProjectLoadingLabel);
            this.ProjectPanel.Location = new System.Drawing.Point(6, 17);
            this.ProjectPanel.Name = "ProjectPanel";
            this.ProjectPanel.Size = new System.Drawing.Size(297, 223);
            this.ProjectPanel.TabIndex = 0;
            // 
            // ProjectLoadingLabel
            // 
            this.ProjectLoadingLabel.AutoSize = true;
            this.ProjectLoadingLabel.Location = new System.Drawing.Point(101, 93);
            this.ProjectLoadingLabel.Name = "ProjectLoadingLabel";
            this.ProjectLoadingLabel.Size = new System.Drawing.Size(98, 13);
            this.ProjectLoadingLabel.TabIndex = 0;
            this.ProjectLoadingLabel.Text = "Loading Projects....";
            // 
            // ChooseProjectNextButton
            // 
            this.ChooseProjectNextButton.Location = new System.Drawing.Point(267, 301);
            this.ChooseProjectNextButton.Name = "ChooseProjectNextButton";
            this.ChooseProjectNextButton.Size = new System.Drawing.Size(75, 23);
            this.ChooseProjectNextButton.TabIndex = 27;
            this.ChooseProjectNextButton.Text = "Next";
            this.ChooseProjectNextButton.UseVisualStyleBackColor = true;
            this.ChooseProjectNextButton.Click += new System.EventHandler(this.ChooseProjectNext_Click);
            // 
            // ChooseProjectBackButton
            // 
            this.ChooseProjectBackButton.Location = new System.Drawing.Point(17, 301);
            this.ChooseProjectBackButton.Name = "ChooseProjectBackButton";
            this.ChooseProjectBackButton.Size = new System.Drawing.Size(75, 23);
            this.ChooseProjectBackButton.TabIndex = 26;
            this.ChooseProjectBackButton.Text = "Back";
            this.ChooseProjectBackButton.UseVisualStyleBackColor = true;
            // 
            // ChooseProjectLabel
            // 
            this.ChooseProjectLabel.AutoSize = true;
            this.ChooseProjectLabel.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChooseProjectLabel.Location = new System.Drawing.Point(103, 12);
            this.ChooseProjectLabel.Name = "ChooseProjectLabel";
            this.ChooseProjectLabel.Size = new System.Drawing.Size(161, 24);
            this.ChooseProjectLabel.TabIndex = 24;
            this.ChooseProjectLabel.Text = "Select Projects";
            // 
            // WorkspacesGroupBox
            // 
            this.WorkspacesGroupBox.Controls.Add(this.WorkspacePanel);
            this.WorkspacesGroupBox.Location = new System.Drawing.Point(33, 38);
            this.WorkspacesGroupBox.Name = "WorkspacesGroupBox";
            this.WorkspacesGroupBox.Size = new System.Drawing.Size(309, 246);
            this.WorkspacesGroupBox.TabIndex = 8;
            this.WorkspacesGroupBox.TabStop = false;
            this.WorkspacesGroupBox.Text = "Workspaces";
            // 
            // WorkspacePanel
            // 
            this.WorkspacePanel.Location = new System.Drawing.Point(6, 17);
            this.WorkspacePanel.Name = "WorkspacePanel";
            this.WorkspacePanel.Size = new System.Drawing.Size(297, 223);
            this.WorkspacePanel.TabIndex = 0;
            // 
            // WorkspaceLabel
            // 
            this.WorkspaceLabel.AutoSize = true;
            this.WorkspaceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WorkspaceLabel.Location = new System.Drawing.Point(103, 9);
            this.WorkspaceLabel.Name = "WorkspaceLabel";
            this.WorkspaceLabel.Size = new System.Drawing.Size(163, 20);
            this.WorkspaceLabel.TabIndex = 3;
            this.WorkspaceLabel.Text = "Choose A Workspace";
            // 
            // WorkspaceBackButton
            // 
            this.WorkspaceBackButton.Location = new System.Drawing.Point(6, 301);
            this.WorkspaceBackButton.Name = "WorkspaceBackButton";
            this.WorkspaceBackButton.Size = new System.Drawing.Size(75, 23);
            this.WorkspaceBackButton.TabIndex = 7;
            this.WorkspaceBackButton.Text = "Back";
            this.WorkspaceBackButton.UseVisualStyleBackColor = true;
            this.WorkspaceBackButton.Click += new System.EventHandler(this.WorkspaceBackButton_Click);
            // 
            // WorkspaceNextButton
            // 
            this.WorkspaceNextButton.Location = new System.Drawing.Point(267, 301);
            this.WorkspaceNextButton.Name = "WorkspaceNextButton";
            this.WorkspaceNextButton.Size = new System.Drawing.Size(75, 23);
            this.WorkspaceNextButton.TabIndex = 9;
            this.WorkspaceNextButton.Text = "Next";
            this.WorkspaceNextButton.UseVisualStyleBackColor = true;
            // 
            // Crescent
            // 
            this.AcceptButton = this.LoginEnterButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 355);
            this.Controls.Add(this.LoginPanel);
            this.Name = "Crescent";
            this.Text = "Crescent";
            this.LoginPanel.ResumeLayout(false);
            this.LoginPanel.PerformLayout();
            this.ChooseWorkspacePanel.ResumeLayout(false);
            this.ChooseWorkspacePanel.PerformLayout();
            this.ChooseProjectPanel.ResumeLayout(false);
            this.ChooseProjectPanel.PerformLayout();
            this.ProjectGroupBox.ResumeLayout(false);
            this.ProjectPanel.ResumeLayout(false);
            this.ProjectPanel.PerformLayout();
            this.WorkspacesGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LoginLabel;
        private System.Windows.Forms.TextBox LoginUsernameBox;
        private System.Windows.Forms.Label LoginPasswordLabel;
        private System.Windows.Forms.Label LoginUsernameLabel;
        private System.Windows.Forms.MaskedTextBox LoginPasswordBox;
        private System.Windows.Forms.Button LoginEnterButton;
        private System.Windows.Forms.Panel LoginPanel;
        private System.Windows.Forms.Label WorkspaceLabel;
        private System.Windows.Forms.Panel ChooseWorkspacePanel;
        private System.Windows.Forms.Button WorkspaceBackButton;
        public System.Windows.Forms.Panel ChooseProjectPanel;
        private System.Windows.Forms.Button ChooseProjectNextButton;
        public System.Windows.Forms.Button ChooseProjectBackButton;
        private System.Windows.Forms.Label ChooseProjectLabel;
        private System.Windows.Forms.GroupBox ProjectGroupBox;
        public System.Windows.Forms.Panel ProjectPanel;
        private System.Windows.Forms.GroupBox WorkspacesGroupBox;
        public System.Windows.Forms.Panel WorkspacePanel;
        public System.Windows.Forms.Button WorkspaceNextButton;
        public System.Windows.Forms.Label ProjectLoadingLabel;
    }
}