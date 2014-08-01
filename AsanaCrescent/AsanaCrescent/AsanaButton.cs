using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace AsanaCrescent
{
    class AsanaButton : Button
    {
        protected override void OnPaint(PaintEventArgs p)
        {
           base.OnPaint(p);
           p.Graphics.DrawRectangle(new Pen(this.BackColor,0), this.ClientRectangle);
        }
    }
}
