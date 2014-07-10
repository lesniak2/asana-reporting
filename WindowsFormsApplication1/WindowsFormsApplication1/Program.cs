using System;
using System.Linq;
using System.Windows.Forms;
using System.Net;
using System.Diagnostics;
using System.ComponentModel;
using System.IO;
using System.Threading;
using Microsoft.VisualBasic;
using AsanaNet;

namespace WindowsFormsApplication1
{
    class Program
    {
        [STAThread]
        static void Main()
        {
            string api_key = "";
            var asana = new Asana(api_key, AuthenticationType.Basic, (s1, s2, s3) => { });
            asana.GetMe(o =>
            {
                var user = o as AsanaUser;
                MessageBox.Show("Hello, " + user.Name);
            }).Wait(); ;
            
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