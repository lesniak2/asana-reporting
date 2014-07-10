using System;
using System.Linq;
using System.Windows.Forms;
using System.Net;
using System.Diagnostics;
using System.ComponentModel;
using System.IO;
using System.Threading;
using Microsoft.VisualBasic;

namespace WindowsFormsApplication1
{
    class Program
    {
        [STAThread]
        static void Main()
        {
            Application.Run(new CresentLogin());
            
        }
        
        /*


            Uri authuri = new Uri(auth);
            Console.WriteLine(auth);
            Process.Start(auth);
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(authuri);
            req.Method = "GET";
            HttpWebResponse res = (HttpWebResponse)req.GetResponse();


            var dataStream = res.GetResponseStream();

            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();

            reader.Close();
            dataStream.Close();
            res.Close();
            Console.WriteLine(responseFromServer);
        
        }*/
    }
}