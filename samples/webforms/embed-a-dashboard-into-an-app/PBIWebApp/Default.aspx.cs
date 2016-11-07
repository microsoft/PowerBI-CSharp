
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System.Threading.Tasks;
using System.Net.Http;
using System.Collections.Specialized;
using Newtonsoft.Json;

namespace PBIWebApp
{
 /* NOTE: This sample is to illustrate how to authenticate a Power BI web app. 
 * In a production application, you should provide appropriate exception handling and refactor authentication settings into 
 * a configuration. Authentication settings are hard-coded in the sample to make it easier to follow the flow of authentication. */
    public partial class _Default : Page
    {
        public AuthenticationResult authResult { get; set; }
        string baseUri = "https://api.powerbi.com/beta/myorg/";

        protected void Page_Load(object sender, EventArgs e)
        {

            //Test for AuthenticationResult
            if (Session["authResult"] != null)
            {
                //Get the authentication result from the session
                authResult = (AuthenticationResult)Session["authResult"];

                //Show Power BI Panel
                signInStatus.Visible = true;

                //Set user and token from authentication result
                userLabel.Text = authResult.UserInfo.DisplayableId;
                accessTokenTextbox.Text = authResult.AccessToken;
            }
        }

        protected void signInButton_Click(object sender, EventArgs e)
        {
            //Create a query string
            //Create a sign-in NameValueCollection for query string
            var @params = new NameValueCollection
            {
                //Azure AD will return an authorization code. 
                //See the Redirect class to see how "code" is used to AcquireTokenByAuthorizationCode
                {"response_type", "code"},

                //Client ID is used by the application to identify themselves to the users that they are requesting permissions from. 
                //You get the client id when you register your Azure app.
                {"client_id", Properties.Settings.Default.ClientID},

                //Resource uri to the Power BI resource to be authorized
                {"resource", "https://analysis.windows.net/powerbi/api"},

                //After user authenticates, Azure AD will redirect back to the web app
                {"redirect_uri", "http://localhost:13526/Redirect"}
            };
            
            //Create sign-in query string
            var queryString = HttpUtility.ParseQueryString(string.Empty);
            queryString.Add(@params);

            //Redirect authority
            //Authority Uri is an Azure resource that takes a client id to get an Access token
            string authorityUri = "https://login.windows.net/common/oauth2/authorize/";
            var authUri = String.Format("{0}?{1}", authorityUri, queryString);
            Response.Redirect(authUri);       
        }

        protected void getDashboardsButton_Click(object sender, EventArgs e)
        {
            string responseContent = string.Empty;

            //Configure dashboards request
            System.Net.WebRequest request = System.Net.WebRequest.Create(String.Format("{0}dashboards", baseUri)) as System.Net.HttpWebRequest;
            request.Method = "GET";
            request.ContentLength = 0;
            request.Headers.Add("Authorization", String.Format("Bearer {0}", authResult.AccessToken));

            //Get dashboards response from request.GetResponse()
            using (var response = request.GetResponse() as System.Net.HttpWebResponse)
            {
                //Get reader from response stream
                using (var reader = new System.IO.StreamReader(response.GetResponseStream()))
                {
                    responseContent = reader.ReadToEnd();

                    //Deserialize JSON string
                    PBIDashboards PBIDashboards = JsonConvert.DeserializeObject<PBIDashboards>(responseContent);
                    Table1.Visible = true;
                    //Get each dashboard 
                    foreach (PBIDashboard dsb in PBIDashboards.value)
                    {
                        TableRow tRow = new TableRow();

                        Table1.Rows.Add(tRow);
                        TableCell idCell = new TableCell();
                        idCell.Text = dsb.id;
                        tRow.Cells.Add(idCell);

                        Table1.Rows.Add(tRow);
                        TableCell nameCell = new TableCell();
                        nameCell.Text = dsb.displayName;
                        tRow.Cells.Add(nameCell);

                        Table1.Rows.Add(tRow);
                        TableCell isReadOnlyCell = new TableCell();
                        isReadOnlyCell.Text = dsb.isReadOnly.ToString();
                        tRow.Cells.Add(isReadOnlyCell);

                        Table1.Rows.Add(tRow);
                        TableCell embedUrlCell = new TableCell();
                        embedUrlCell.Text = dsb.embedUrl;
                        tRow.Cells.Add(embedUrlCell);
                    }
                }
            }
        }


    }
    
    //Power BI Datasets
    public class PBIDatasets
    {
        public Dataset[] Datasets { get; set; }
    }

    public class PBIGroups
    {
        public PBIGroup[] value { get; set; }
    }

    public class Dataset
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }

    public class PBIGroup
    {
        public string id { get; set; }
        public string name {get; set;}
    }

    public class PBIDashboards
    {
        public PBIDashboard[] value { get; set; }
    }
    public class PBIDashboard
    {
        public string id { get; set; }
        public string displayName { get; set; }
        public string embedUrl { get; set; }
        public bool isReadOnly { get; set; }
    }
    public class PBIReports
    {
        public PBIReport[] value { get; set; }
    }
    public class PBIReport
    {
        public string id { get; set; }

        // the name of this property will change to 'displayName' when the API moves from Beta to V1 namespace
        public string name { get; set; }

        public string webUrl { get; set; }
        
        public string embedUrl { get; set; } 
    }


    public class PBITiles
    {
        public PBITile[] value { get; set; }
    }
    public class PBITile
    {
        public string id { get; set; }
        public string title { get; set; }
        public string embedUrl { get; set; }
    }

}