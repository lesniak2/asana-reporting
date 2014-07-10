using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Authentication : Form
    {
        public Authentication()
        {
            InitializeComponent();
        }

        private void EnterButton_Click(object sender, EventArgs e)
        {

        }

        private void APIAccessForm_Load(object sender, EventArgs e)
        {

        }

        public string GetAPIKey()
        {
            return this.ApiTextBox.Text;
        }
    }
}
