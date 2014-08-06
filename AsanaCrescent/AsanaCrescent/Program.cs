using System;
using System.Windows.Forms;

namespace AsanaCrescent
{
    class Program
    {
        /// <summary>
        /// Entry point to the application. Not very complicated
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Crescent crescent = new Crescent();
            crescent.StartPosition = FormStartPosition.CenterScreen;
            Application.Run(crescent);
        }
    }
}