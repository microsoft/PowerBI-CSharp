using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Microsoft.PowerBI.Api.V1;
using Microsoft.PowerBI.Api.V1.Models;
using Microsoft.PowerBI.Security;
using Microsoft.Rest;

namespace WindowsFormsSample
{
    public partial class Form1 : Form
    {
        private IList<Report> Reports { get; set; }

        private string AccessToken { get; set; }

        public Form1()
        {
            InitializeComponent();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            // Create a token credentials with "AppKey" type
            var credentials = new TokenCredentials(txtAccessKey.Text, "AppKey");

            using (var client = new PowerBIClient(credentials))
            {
                client.BaseUri = new Uri(txtBaseUrl.Text);

                var reportsResponse = client.Reports.GetReports(txtCollection.Text, txtWorkspaceId.Text);

                Reports = reportsResponse.Value;

                Print(Reports);
            }
        }

        private void Print(IList<Report> reports)
        {
            txtReports.Text = string.Empty;
            foreach (var report in reports)
            {
                txtReports.Text += report.Name + Environment.NewLine + report.Id + Environment.NewLine + Environment.NewLine;
            }

            // Put the last report Id in the request textbox.
            var lastReport = reports.LastOrDefault();
            if (lastReport != null)
            {
                txtRequestedReportId.Text = lastReport.Id;
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            var report = FindReport(txtRequestedReportId.Text);

            if (report == null)
            {
                MessageBox.Show("No such report");
                return;
            }

            var embedToken = PowerBIToken.CreateReportEmbedToken(txtCollection.Text, txtWorkspaceId.Text, report.Id);

            AccessToken = embedToken.Generate(txtAccessKey.Text);

            webBrowser1.DocumentCompleted += WebBrowser1_DocumentCompleted;

            webBrowser1.Navigate(report.EmbedUrl);

        }

        private void WebBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (AccessToken != null)
            {
                var message = "{\"action\":\"loadReport\",\"accessToken\":\"" + AccessToken + "\"}";
                webBrowser1.Document.InvokeScript("postMessage", new object[] { message, "*" });
            }
            else
            {
                MessageBox.Show("AccessToken is not defined.");
            }
        }

        private Report FindReport(string reportId)
        {
            if (Reports != null)
            {
                foreach (var report in Reports)
                {
                    if (report.Id == reportId)
                    {
                        return report;
                    }
                }
                
            }

            MessageBox.Show("You should get a list of reports first. click Generate");
            return null;
        }
    }
}
