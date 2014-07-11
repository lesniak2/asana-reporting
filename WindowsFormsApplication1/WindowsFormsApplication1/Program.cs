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
            string api_key = "";
            ArrayList workspaces = new ArrayList();
            ArrayList projects = new ArrayList();
            ArrayList ProjectCheckBoxes = new ArrayList();
            Authentication auth = new Authentication();
            if (auth.ShowDialog() == DialogResult.OK)
                api_key = auth.GetAPIKey();
            Crescent crescent = new Crescent();
            var asana = new Asana(api_key, AuthenticationType.Basic, (s1, s2, s3) => { });
            AsanaManager manager = new AsanaManager(crescent, asana);
            manager.PopulateWorkspaces();

            Application.Run(crescent);
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