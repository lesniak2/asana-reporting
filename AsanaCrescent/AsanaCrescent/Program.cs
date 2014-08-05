using System;
using System.Linq;
using System.Windows.Forms;
using System.Net;
using System.Diagnostics;
using System.ComponentModel;
using System.Collections;
using System.IO;
using System.Threading;
using Microsoft.VisualBasic;
using AsanaNet;
namespace AsanaCrescent
{
    class Program 
    {
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