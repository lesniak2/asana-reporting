using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace WindowsFormsApplication1
{
    public partial class Browser : Form
    {
        private string AuthorizationEndpoint;
        private static Thread PopUpBrowser;
        public Browser()
        {
            InitializeComponent();
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            string url = e.Url.AbsoluteUri;
            if (url.IndexOf("https://asanareporting.asana.com") == 0 && url.IndexOf("code=") != -1)
                {
                    TokenManager.Token = url.Substring(url.IndexOf("=") + 1);
                    return;
                }
                else if (url.IndexOf("https://asanareporting.asana.com") == 0)
                {
                    TokenManager.PermissionGranted = false;
                    string message = "For this application to work you must allow it Asana permissions. Do you want to allow them?" ;
                    string caption = "Permission Warning";
                    var result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.No)
                    {
                        this.Close();
                        Application.Exit();
                    }
                    else
                    {
                        this.Navigate();
                    }

                }
        }

        private void webBrowser1_NewWindow(object sender, System.ComponentModel.CancelEventArgs e)
        {
            
    //        webBrowser1.Navigate(webBrowser1.StatusText);
            e.Cancel = true;
         //   this.Close();
        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            Console.WriteLine("hi");
        }

        private void webBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            Console.WriteLine(e.Url);
            if (e.Url.ToString() == "https://app.asana.com/-/oauth_authorize")
            {
                TokenManager.PermissionChosen = true;
                this.Navigate();
             //   this.Close();
            }
        }
        private void webBrowser1_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            if (e.Url.ToString() == "https://app.asana.com/-/oauth_authorize")
            {
            }
                Console.WriteLine("Navigating to: " + e.Url.ToString());
        }
        public void Navigate()
        {
            string _clientId = "13475859369712";
            // private static string _secret = "3ebc035fde72bac5c02b3611188ed0be";
            string RedirectUri = @"https://asanareporting.asana.com";
            // private static Uri TokenEndpoint = new Uri("https://app.asana.com/-/oauth_token");
            // private static Uri AuthorizationEndpoint = new Uri("https://app.asana.com/-/oauth_authorize");
            AuthorizationEndpoint = @"https://app.asana.com/-/oauth_authorize?"
                + "client_id=" + _clientId + "&"
                + "redirect_uri=" + RedirectUri + "&"
                + "response_type=code";
            if (TokenManager.PermissionChosen == false)
            {
                webBrowser1.Navigate(AuthorizationEndpoint, false);
            }
            try
            {
                Application.Run(this);
            }
            catch (Exception e) {
                //this.Close();
                webBrowser1.Navigate(AuthorizationEndpoint, true);
            }
              
        }
    }

}
