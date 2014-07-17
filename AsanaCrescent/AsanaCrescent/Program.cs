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
/*            //////////////ExcelTesting//////////////////////////////
            string[] arr1 = { "twill14", "tles14", "dchinta14", "fzam14", "ddon14" };
            string[] arr2 = { "twill15", "tles15", "dchinta15", "fzam15", "ddon15" };
            string[] arr3 = { "twill16", "tles16", "dchinta16", "fzam16", "ddon16" };
            string[] arr4 = { "twill17", "tles17", "dchinta17", "fzam17", "ddon17" };
            ExcelMaster excel = new ExcelMaster();
            excel.AddRow(arr1);
            excel.AddRow(arr2);
            excel.AddRow(arr3);
            excel.AddRow(arr4);
            string[] col1 = { "Column 1", "Column 2", "Column 3", "Column 4", "Column 5" };
            excel.AddColumn(col1);
            /////////////////////////////////////////////////////////*/

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