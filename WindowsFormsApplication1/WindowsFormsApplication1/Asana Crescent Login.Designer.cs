namespace WindowsFormsApplication1
{
    partial class CresentLogin
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
            this.components = new System.ComponentModel.Container();
            this.AsanaLogin_label = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.LoginEnterButton = new System.Windows.Forms.Button();
            this.LoginPasswordBox = new System.Windows.Forms.MaskedTextBox();
            this.LoginPasswordLabel = new System.Windows.Forms.Label();
            this.LoginUsernameLabel = new System.Windows.Forms.Label();
            this.LoginUsernameBox = new System.Windows.Forms.TextBox();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.AsanaCresentLogin = new System.Windows.Forms.Panel();
            this.ChooseWorkspace = new System.Windows.Forms.Panel();
            this.ChooseProject = new System.Windows.Forms.Panel();
            this.ChooseProjectNextButton = new System.Windows.Forms.Button();
            this.ChooseProjectBackButton = new System.Windows.Forms.Button();
            this.ChooseProjectvScrollBar = new System.Windows.Forms.VScrollBar();
            this.chooseaproject_label = new System.Windows.Forms.Label();
            this.MasterCheckB = new System.Windows.Forms.CheckBox();
            this.DeployedCheckB = new System.Windows.Forms.CheckBox();
            this.ClosedCheckB = new System.Windows.Forms.CheckBox();
            this.BudgetCheckB = new System.Windows.Forms.CheckBox();
            this.IncidentCheckB = new System.Windows.Forms.CheckBox();
            this.SprintCheckB = new System.Windows.Forms.CheckBox();
            this.BacklogCheckB = new System.Windows.Forms.CheckBox();
            this.InvestigationCheckB = new System.Windows.Forms.CheckBox();
            this.InitiativesCheckB = new System.Windows.Forms.CheckBox();
            this.AllCheckB = new System.Windows.Forms.CheckBox();
            this.wmpbox = new System.Windows.Forms.PictureBox();
            this.workspace_label = new System.Windows.Forms.Label();
            this.lfobox = new System.Windows.Forms.PictureBox();
            this.WorkspaceBackButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.AsanaCresentLogin.SuspendLayout();
            this.ChooseWorkspace.SuspendLayout();
            this.ChooseProject.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wmpbox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lfobox)).BeginInit();
            this.SuspendLayout();
            // 
            // AsanaLogin_label
            // 
            this.AsanaLogin_label.AutoSize = true;
            this.AsanaLogin_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AsanaLogin_label.Location = new System.Drawing.Point(3, 3);
            this.AsanaLogin_label.Name = "AsanaLogin_label";
            this.AsanaLogin_label.Size = new System.Drawing.Size(153, 18);
            this.AsanaLogin_label.TabIndex = 0;
            this.AsanaLogin_label.Text = "Asana Crescent Login";
            this.AsanaLogin_label.Click += new System.EventHandler(this.label1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(17, 36);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(237, 194);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
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
            this.LoginUsernameBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // AsanaCresentLogin
            // 
            this.AsanaCresentLogin.Controls.Add(this.ChooseWorkspace);
            this.AsanaCresentLogin.Controls.Add(this.LoginUsernameBox);
            this.AsanaCresentLogin.Controls.Add(this.AsanaLogin_label);
            this.AsanaCresentLogin.Controls.Add(this.LoginPasswordLabel);
            this.AsanaCresentLogin.Controls.Add(this.LoginPasswordBox);
            this.AsanaCresentLogin.Controls.Add(this.LoginEnterButton);
            this.AsanaCresentLogin.Controls.Add(this.LoginUsernameLabel);
            this.AsanaCresentLogin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AsanaCresentLogin.Location = new System.Drawing.Point(0, 0);
            this.AsanaCresentLogin.Name = "AsanaCresentLogin";
            this.AsanaCresentLogin.Size = new System.Drawing.Size(318, 287);
            this.AsanaCresentLogin.TabIndex = 2;
            this.AsanaCresentLogin.Visible = false;
            this.AsanaCresentLogin.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // ChooseWorkspace
            // 
            this.ChooseWorkspace.Controls.Add(this.ChooseProject);
            this.ChooseWorkspace.Controls.Add(this.wmpbox);
            this.ChooseWorkspace.Controls.Add(this.workspace_label);
            this.ChooseWorkspace.Controls.Add(this.lfobox);
            this.ChooseWorkspace.Controls.Add(this.WorkspaceBackButton);
            this.ChooseWorkspace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ChooseWorkspace.Location = new System.Drawing.Point(0, 0);
            this.ChooseWorkspace.Name = "ChooseWorkspace";
            this.ChooseWorkspace.Size = new System.Drawing.Size(318, 287);
            this.ChooseWorkspace.TabIndex = 5;
            this.ChooseWorkspace.Visible = false;
            this.ChooseWorkspace.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // ChooseProject
            // 
            this.ChooseProject.Controls.Add(this.ChooseProjectNextButton);
            this.ChooseProject.Controls.Add(this.ChooseProjectBackButton);
            this.ChooseProject.Controls.Add(this.ChooseProjectvScrollBar);
            this.ChooseProject.Controls.Add(this.chooseaproject_label);
            this.ChooseProject.Controls.Add(this.MasterCheckB);
            this.ChooseProject.Controls.Add(this.DeployedCheckB);
            this.ChooseProject.Controls.Add(this.ClosedCheckB);
            this.ChooseProject.Controls.Add(this.BudgetCheckB);
            this.ChooseProject.Controls.Add(this.IncidentCheckB);
            this.ChooseProject.Controls.Add(this.SprintCheckB);
            this.ChooseProject.Controls.Add(this.BacklogCheckB);
            this.ChooseProject.Controls.Add(this.InvestigationCheckB);
            this.ChooseProject.Controls.Add(this.InitiativesCheckB);
            this.ChooseProject.Controls.Add(this.AllCheckB);
            this.ChooseProject.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ChooseProject.Location = new System.Drawing.Point(0, 0);
            this.ChooseProject.Name = "ChooseProject";
            this.ChooseProject.Size = new System.Drawing.Size(318, 287);
            this.ChooseProject.TabIndex = 5;
            // 
            // ChooseProjectNextButton
            // 
            this.ChooseProjectNextButton.Location = new System.Drawing.Point(217, 242);
            this.ChooseProjectNextButton.Name = "ChooseProjectNextButton";
            this.ChooseProjectNextButton.Size = new System.Drawing.Size(75, 23);
            this.ChooseProjectNextButton.TabIndex = 27;
            this.ChooseProjectNextButton.Text = "Next";
            this.ChooseProjectNextButton.UseVisualStyleBackColor = true;
            this.ChooseProjectNextButton.Click += new System.EventHandler(this.ChooseProjectNext_Click);
            // 
            // ChooseProjectBackButton
            // 
            this.ChooseProjectBackButton.Location = new System.Drawing.Point(217, 33);
            this.ChooseProjectBackButton.Name = "ChooseProjectBackButton";
            this.ChooseProjectBackButton.Size = new System.Drawing.Size(75, 23);
            this.ChooseProjectBackButton.TabIndex = 26;
            this.ChooseProjectBackButton.Text = "Back";
            this.ChooseProjectBackButton.UseVisualStyleBackColor = true;
            this.ChooseProjectBackButton.Click += new System.EventHandler(this.ChooseProjectBack_Click);
            // 
            // ChooseProjectvScrollBar
            // 
            this.ChooseProjectvScrollBar.Location = new System.Drawing.Point(295, 0);
            this.ChooseProjectvScrollBar.Name = "ChooseProjectvScrollBar";
            this.ChooseProjectvScrollBar.Size = new System.Drawing.Size(23, 292);
            this.ChooseProjectvScrollBar.TabIndex = 25;
            // 
            // chooseaproject_label
            // 
            this.chooseaproject_label.AutoSize = true;
            this.chooseaproject_label.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chooseaproject_label.Location = new System.Drawing.Point(7, 3);
            this.chooseaproject_label.Name = "chooseaproject_label";
            this.chooseaproject_label.Size = new System.Drawing.Size(184, 24);
            this.chooseaproject_label.TabIndex = 24;
            this.chooseaproject_label.Text = "Choose A Project";
            // 
            // MasterCheckB
            // 
            this.MasterCheckB.AutoSize = true;
            this.MasterCheckB.Location = new System.Drawing.Point(17, 248);
            this.MasterCheckB.Name = "MasterCheckB";
            this.MasterCheckB.Size = new System.Drawing.Size(100, 17);
            this.MasterCheckB.TabIndex = 23;
            this.MasterCheckB.Text = "BI: Master Data";
            this.MasterCheckB.UseVisualStyleBackColor = true;
            this.MasterCheckB.Click += new System.EventHandler(this.MasterCheckB_Click);
            // 
            // DeployedCheckB
            // 
            this.DeployedCheckB.AutoSize = true;
            this.DeployedCheckB.Location = new System.Drawing.Point(17, 225);
            this.DeployedCheckB.Name = "DeployedCheckB";
            this.DeployedCheckB.Size = new System.Drawing.Size(174, 17);
            this.DeployedCheckB.TabIndex = 22;
            this.DeployedCheckB.Text = "BI Tasks: Deployed/Completed";
            this.DeployedCheckB.UseVisualStyleBackColor = true;
            this.DeployedCheckB.Click += new System.EventHandler(this.DeployedCheckB_Click);
            // 
            // ClosedCheckB
            // 
            this.ClosedCheckB.AutoSize = true;
            this.ClosedCheckB.Location = new System.Drawing.Point(17, 201);
            this.ClosedCheckB.Name = "ClosedCheckB";
            this.ClosedCheckB.Size = new System.Drawing.Size(158, 17);
            this.ClosedCheckB.TabIndex = 21;
            this.ClosedCheckB.Text = "Closed/Cancelled Requests";
            this.ClosedCheckB.UseVisualStyleBackColor = true;
            this.ClosedCheckB.CheckedChanged += new System.EventHandler(this.checkBox8_CheckedChanged);
            this.ClosedCheckB.Click += new System.EventHandler(this.ClosedCheckB_Click);
            // 
            // BudgetCheckB
            // 
            this.BudgetCheckB.AutoSize = true;
            this.BudgetCheckB.Location = new System.Drawing.Point(17, 178);
            this.BudgetCheckB.Name = "BudgetCheckB";
            this.BudgetCheckB.Size = new System.Drawing.Size(135, 17);
            this.BudgetCheckB.TabIndex = 20;
            this.BudgetCheckB.Text = "BI: Budgetary Deferrals";
            this.BudgetCheckB.UseVisualStyleBackColor = true;
            this.BudgetCheckB.CheckedChanged += new System.EventHandler(this.BudgetCheckB_CheckedChanged);
            this.BudgetCheckB.Click += new System.EventHandler(this.BudgetCheckB_Click);
            // 
            // IncidentCheckB
            // 
            this.IncidentCheckB.AutoSize = true;
            this.IncidentCheckB.Location = new System.Drawing.Point(17, 155);
            this.IncidentCheckB.Name = "IncidentCheckB";
            this.IncidentCheckB.Size = new System.Drawing.Size(145, 17);
            this.IncidentCheckB.TabIndex = 19;
            this.IncidentCheckB.Text = "BI: Incident Management";
            this.IncidentCheckB.UseVisualStyleBackColor = true;
            this.IncidentCheckB.Click += new System.EventHandler(this.IncidentCheckB_Click);
            // 
            // SprintCheckB
            // 
            this.SprintCheckB.AutoSize = true;
            this.SprintCheckB.Location = new System.Drawing.Point(17, 132);
            this.SprintCheckB.Name = "SprintCheckB";
            this.SprintCheckB.Size = new System.Drawing.Size(93, 17);
            this.SprintCheckB.TabIndex = 18;
            this.SprintCheckB.Text = "BI: Sprint Plan";
            this.SprintCheckB.UseVisualStyleBackColor = true;
            this.SprintCheckB.Click += new System.EventHandler(this.SprintCheckB_Click);
            // 
            // BacklogCheckB
            // 
            this.BacklogCheckB.AutoSize = true;
            this.BacklogCheckB.Location = new System.Drawing.Point(17, 109);
            this.BacklogCheckB.Name = "BacklogCheckB";
            this.BacklogCheckB.Size = new System.Drawing.Size(81, 17);
            this.BacklogCheckB.TabIndex = 17;
            this.BacklogCheckB.Text = "BI: Backlog";
            this.BacklogCheckB.UseVisualStyleBackColor = true;
            this.BacklogCheckB.Click += new System.EventHandler(this.BacklogCheckB_Click);
            // 
            // InvestigationCheckB
            // 
            this.InvestigationCheckB.AutoSize = true;
            this.InvestigationCheckB.Location = new System.Drawing.Point(17, 86);
            this.InvestigationCheckB.Name = "InvestigationCheckB";
            this.InvestigationCheckB.Size = new System.Drawing.Size(140, 17);
            this.InvestigationCheckB.TabIndex = 16;
            this.InvestigationCheckB.Text = "BI: Internal Investigation";
            this.InvestigationCheckB.UseVisualStyleBackColor = true;
            this.InvestigationCheckB.Click += new System.EventHandler(this.InvestigationCheckB_Click);
            // 
            // InitiativesCheckB
            // 
            this.InitiativesCheckB.AutoSize = true;
            this.InitiativesCheckB.Location = new System.Drawing.Point(17, 63);
            this.InitiativesCheckB.Name = "InitiativesCheckB";
            this.InitiativesCheckB.Size = new System.Drawing.Size(86, 17);
            this.InitiativesCheckB.TabIndex = 15;
            this.InitiativesCheckB.Text = "BI: Initiatives";
            this.InitiativesCheckB.UseVisualStyleBackColor = true;
            this.InitiativesCheckB.Click += new System.EventHandler(this.InitiativesCheckB_Click);
            // 
            // AllCheckB
            // 
            this.AllCheckB.AutoSize = true;
            this.AllCheckB.Location = new System.Drawing.Point(17, 40);
            this.AllCheckB.Name = "AllCheckB";
            this.AllCheckB.Size = new System.Drawing.Size(37, 17);
            this.AllCheckB.TabIndex = 14;
            this.AllCheckB.Text = "All";
            this.AllCheckB.UseVisualStyleBackColor = true;
            this.AllCheckB.Click += new System.EventHandler(this.AllCheckB_Click);
            // 
            // wmpbox
            // 
            this.wmpbox.Image = global::WindowsFormsApplication1.Properties.Resources.WMP;
            this.wmpbox.Location = new System.Drawing.Point(6, 141);
            this.wmpbox.Name = "wmpbox";
            this.wmpbox.Size = new System.Drawing.Size(254, 56);
            this.wmpbox.TabIndex = 5;
            this.wmpbox.TabStop = false;
            this.wmpbox.Click += new System.EventHandler(this.wmpbox_Click);
            // 
            // workspace_label
            // 
            this.workspace_label.AutoSize = true;
            this.workspace_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.workspace_label.Location = new System.Drawing.Point(13, 36);
            this.workspace_label.Name = "workspace_label";
            this.workspace_label.Size = new System.Drawing.Size(163, 20);
            this.workspace_label.TabIndex = 3;
            this.workspace_label.Text = "Choose A Workspace";
            this.workspace_label.Click += new System.EventHandler(this.workspace_label_Click);
            // 
            // lfobox
            // 
            this.lfobox.Image = global::WindowsFormsApplication1.Properties.Resources.leapfrog;
            this.lfobox.Location = new System.Drawing.Point(13, 77);
            this.lfobox.Name = "lfobox";
            this.lfobox.Size = new System.Drawing.Size(237, 39);
            this.lfobox.TabIndex = 4;
            this.lfobox.TabStop = false;
            this.lfobox.Click += new System.EventHandler(this.lfo_click);
            // 
            // WorkspaceBackButton
            // 
            this.WorkspaceBackButton.Location = new System.Drawing.Point(107, 237);
            this.WorkspaceBackButton.Name = "WorkspaceBackButton";
            this.WorkspaceBackButton.Size = new System.Drawing.Size(75, 23);
            this.WorkspaceBackButton.TabIndex = 7;
            this.WorkspaceBackButton.Text = "Back";
            this.WorkspaceBackButton.UseVisualStyleBackColor = true;
            this.WorkspaceBackButton.Click += new System.EventHandler(this.WorkspaceBackButton_Click);
            // 
            // CresentLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(318, 287);
            this.Controls.Add(this.AsanaCresentLogin);
            this.Controls.Add(this.groupBox1);
            this.Name = "CresentLogin";
            this.Text = "Login";
            this.Load += new System.EventHandler(this.CresentLogin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.AsanaCresentLogin.ResumeLayout(false);
            this.AsanaCresentLogin.PerformLayout();
            this.ChooseWorkspace.ResumeLayout(false);
            this.ChooseWorkspace.PerformLayout();
            this.ChooseProject.ResumeLayout(false);
            this.ChooseProject.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wmpbox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lfobox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label AsanaLogin_label;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox LoginUsernameBox;
        private System.Windows.Forms.Label LoginPasswordLabel;
        private System.Windows.Forms.Label LoginUsernameLabel;
        private System.Windows.Forms.MaskedTextBox LoginPasswordBox;
        private System.Windows.Forms.Button LoginEnterButton;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Panel AsanaCresentLogin;
        private System.Windows.Forms.PictureBox wmpbox;
        private System.Windows.Forms.PictureBox lfobox;
        private System.Windows.Forms.Label workspace_label;
        private System.Windows.Forms.Panel ChooseWorkspace;
        private System.Windows.Forms.Panel ChooseProject;
        private System.Windows.Forms.Label chooseaproject_label;
        private System.Windows.Forms.CheckBox MasterCheckB;
        private System.Windows.Forms.CheckBox DeployedCheckB;
        private System.Windows.Forms.CheckBox ClosedCheckB;
        private System.Windows.Forms.CheckBox BudgetCheckB;
        private System.Windows.Forms.CheckBox IncidentCheckB;
        private System.Windows.Forms.CheckBox SprintCheckB;
        private System.Windows.Forms.CheckBox BacklogCheckB;
        private System.Windows.Forms.CheckBox InvestigationCheckB;
        private System.Windows.Forms.CheckBox InitiativesCheckB;
        private System.Windows.Forms.CheckBox AllCheckB;
        private System.Windows.Forms.VScrollBar ChooseProjectvScrollBar;
        private System.Windows.Forms.Button ChooseProjectNextButton;
        private System.Windows.Forms.Button ChooseProjectBackButton;
        private System.Windows.Forms.Button WorkspaceBackButton;
    }
}