using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace AsanaCrescent
{
    class AsanaCheckbox : CheckBox
    {
        public AsanaCheckbox() { }
        protected override void OnPaint(PaintEventArgs e) 
        {


            Graphics g = e.Graphics;

            base.OnPaint(e);
            if (this.Checked)
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.Blue), new Rectangle(0, 0, 16, 16));
            }
            else
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.Red), new Rectangle(0, 0, 16, 16));
            }


       }
    }
}
