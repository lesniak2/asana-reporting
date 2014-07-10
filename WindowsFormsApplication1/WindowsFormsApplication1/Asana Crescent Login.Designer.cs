namespace WindowsFormsApplication1
{
    partial class CrescentLogin
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
            this.AsanaCrescentLogin = new System.Windows.Forms.Panel();
            this.ChooseWorkspace = new System.Windows.Forms.Panel();
            this.ChooseProject = new System.Windows.Forms.Panel();
            this.ChooseProjectNextButton = new System.Windows.Forms.Button();
            this.ChooseProjectBackButton = new System.Windows.Forms.Button();
            this.chooseaproject_label = new System.Windows.Forms.Label();
            this.wmpbox = new System.Windows.Forms.PictureBox();
            this.workspace_label = new System.Windows.Forms.Label();
            this.lfobox = new System.Windows.Forms.PictureBox();
            this.WorkspaceBackButton = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.AsanaCrescentLogin.SuspendLayout();
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
            // AsanaCrescentLogin
            // 
            this.AsanaCrescentLogin.Controls.Add(this.ChooseWorkspace);
            this.AsanaCrescentLogin.Controls.Add(this.LoginUsernameBox);
            this.AsanaCrescentLogin.Controls.Add(this.AsanaLogin_label);
            this.AsanaCrescentLogin.Controls.Add(this.LoginPasswordLabel);
            this.AsanaCrescentLogin.Controls.Add(this.LoginPasswordBox);
            this.AsanaCrescentLogin.Controls.Add(this.LoginEnterButton);
            this.AsanaCrescentLogin.Controls.Add(this.LoginUsernameLabel);
            this.AsanaCrescentLogin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AsanaCrescentLogin.Location = new System.Drawing.Point(0, 0);
            this.AsanaCrescentLogin.Name = "AsanaCrescentLogin";
            this.AsanaCrescentLogin.Size = new System.Drawing.Size(375, 355);
            this.AsanaCrescentLogin.TabIndex = 2;
            this.AsanaCrescentLogin.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
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
            this.ChooseWorkspace.Size = new System.Drawing.Size(375, 355);
            this.ChooseWorkspace.TabIndex = 5;
            this.ChooseWorkspace.Visible = false;
            this.ChooseWorkspace.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // ChooseProject
            // 
            this.ChooseProject.Controls.Add(this.vScrollBar1);
            this.ChooseProject.Controls.Add(this.checkBox1);
            this.ChooseProject.Controls.Add(this.listBox1);
            this.ChooseProject.Controls.Add(this.ChooseProjectNextButton);
            this.ChooseProject.Controls.Add(this.ChooseProjectBackButton);
            this.ChooseProject.Controls.Add(this.chooseaproject_label);
            this.ChooseProject.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ChooseProject.Location = new System.Drawing.Point(0, 0);
            this.ChooseProject.Name = "ChooseProject";
            this.ChooseProject.Size = new System.Drawing.Size(375, 355);
            this.ChooseProject.TabIndex = 5;
            this.ChooseProject.Visible = false;
            this.ChooseProject.Paint += new System.Windows.Forms.PaintEventHandler(this.ChooseProject_Paint);
            // 
            // ChooseProjectNextButton
            // 
            this.ChooseProjectNextButton.Location = new System.Drawing.Point(288, 301);
            this.ChooseProjectNextButton.Name = "ChooseProjectNextButton";
            this.ChooseProjectNextButton.Size = new System.Drawing.Size(75, 23);
            this.ChooseProjectNextButton.TabIndex = 27;
            this.ChooseProjectNextButton.Text = "Next";
            this.ChooseProjectNextButton.UseVisualStyleBackColor = true;
            this.ChooseProjectNextButton.Click += new System.EventHandler(this.ChooseProjectNext_Click);
            // 
            // ChooseProjectBackButton
            // 
            this.ChooseProjectBackButton.Location = new System.Drawing.Point(6, 301);
            this.ChooseProjectBackButton.Name = "ChooseProjectBackButton";
            this.ChooseProjectBackButton.Size = new System.Drawing.Size(75, 23);
            this.ChooseProjectBackButton.TabIndex = 26;
            this.ChooseProjectBackButton.Text = "Back";
            this.ChooseProjectBackButton.UseVisualStyleBackColor = true;
            this.ChooseProjectBackButton.Click += new System.EventHandler(this.ChooseProjectBack_Click);
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
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(23, 43);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(300, 238);
            this.listBox1.TabIndex = 28;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(32, 54);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(80, 17);
            this.checkBox1.TabIndex = 29;
            this.checkBox1.Text = "checkBox1";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.Location = new System.Drawing.Point(302, 43);
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(21, 238);
            this.vScrollBar1.TabIndex = 30;
            this.vScrollBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vScrollBar1_Scroll);
            // 
            // CrescentLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 355);
            this.Controls.Add(this.AsanaCrescentLogin);
            this.Controls.Add(this.groupBox1);
            this.Name = "CrescentLogin";
            this.Text = "Asana Crescent";
            this.Load += new System.EventHandler(this.CrescentLogin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.AsanaCrescentLogin.ResumeLayout(false);
            this.AsanaCrescentLogin.PerformLayout();
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
        private System.Windows.Forms.Panel AsanaCrescentLogin;
        private System.Windows.Forms.PictureBox wmpbox;
        private System.Windows.Forms.PictureBox lfobox;
        private System.Windows.Forms.Label workspace_label;
        private System.Windows.Forms.Panel ChooseWorkspace;
        private System.Windows.Forms.Button WorkspaceBackButton;
        private System.Windows.Forms.Panel ChooseProject;
        private System.Windows.Forms.Button ChooseProjectNextButton;
        private System.Windows.Forms.Button ChooseProjectBackButton;
        private System.Windows.Forms.Label chooseaproject_label;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.VScrollBar vScrollBar1;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}