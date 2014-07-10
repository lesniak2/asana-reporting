namespace WindowsFormsApplication1
{
    partial class Authentication
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
            this.EnterButton = new System.Windows.Forms.Button();
            this.RequestApiLabel = new System.Windows.Forms.Label();
            this.ApiTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // EnterButton
            // 
            this.EnterButton.Location = new System.Drawing.Point(186, 227);
            this.EnterButton.Name = "EnterButton";
            this.EnterButton.Size = new System.Drawing.Size(75, 23);
            this.EnterButton.TabIndex = 0;
            this.EnterButton.Text = "Enter";
            this.EnterButton.UseVisualStyleBackColor = true;
            this.EnterButton.Click += new System.EventHandler(this.EnterButton_Click);
            this.EnterButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            // 
            // RequestApiLabel
            // 
            this.RequestApiLabel.AutoSize = true;
            this.RequestApiLabel.Font = new System.Drawing.Font("Garamond", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RequestApiLabel.Location = new System.Drawing.Point(12, 40);
            this.RequestApiLabel.Name = "RequestApiLabel";
            this.RequestApiLabel.Size = new System.Drawing.Size(184, 17);
            this.RequestApiLabel.TabIndex = 1;
            this.RequestApiLabel.Text = "Please Enter Your API Key:";
            // 
            // ApiTextBox
            // 
            this.ApiTextBox.Location = new System.Drawing.Point(12, 93);
            this.ApiTextBox.Name = "ApiTextBox";
            this.ApiTextBox.Size = new System.Drawing.Size(249, 20);
            this.ApiTextBox.TabIndex = 2;
            // 
            // Authentication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.ApiTextBox);
            this.Controls.Add(this.RequestApiLabel);
            this.Controls.Add(this.EnterButton);
            this.Name = "Authentication";
            this.Text = "Authorization";
            this.Load += new System.EventHandler(this.APIAccessForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button EnterButton;
        private System.Windows.Forms.Label RequestApiLabel;
        private System.Windows.Forms.TextBox ApiTextBox;
    }
}