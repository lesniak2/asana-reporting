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
        }

        private void loginEnter_Click(object sender, EventArgs e)
        {
            ChooseWorkspacePanel.Visible = true;
        }

        private void ChooseTaskPanel_Paint(object sender, PaintEventArgs e)
        {

        }


    }
}
