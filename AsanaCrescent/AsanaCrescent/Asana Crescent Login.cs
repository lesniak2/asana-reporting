using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.ComponentModel;
using AsanaNet;

namespace AsanaCrescent
{
    public partial class Crescent : Form
    {
        public Crescent()
        {
            InitializeComponent();
        }

        private void WorkspaceBackButton_Click(object sender, EventArgs e)
        {
            ChooseWorkspacePanel.Visible = false;
            asanacrescentLogo.Visible = true;
        }

        private void APIKeyButton_Click(object sender, EventArgs e)
        {
            asanacrescentLogo.Visible = false;
            var asana = new Asana(APIKeyBox.Text, AuthenticationType.Basic, (s1, s2, s3) => { });
            AsanaManager manager = new AsanaManager(this, asana);
            ChooseWorkspacePanel.Visible = true;
            manager.PopulateWorkspaces();
        }
        private void ChooseProjectPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ProjectPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ProjectGroupBox_Enter(object sender, EventArgs e)
        {

        }

        private void LoginLabel_Click(object sender, EventArgs e)
        {

        }

        private void LoginUsernameBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void ChooseTaskPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void TaskLabel_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }


    }
}
