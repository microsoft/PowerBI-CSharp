//Copyright Microsoft 2015

using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System.IO;
using System.Linq;
using PowerBIExtensionMethods;
using System.Web.Script.Serialization;

namespace PBIGettingStarted
{

    //Sample to show how to use the Power BI API
    //  See also, http://docs.powerbi.apiary.io/reference

    //To run this sample:
    //Step 1 - Replace {Client ID from Azure AD app registration} with your client app ID. 
    //To learn how to get a client app ID, see Register a client app (https://msdn.microsoft.com/en-US/library/dn877542.aspx#clientID)

    class Program
    {
        //Step 1 - Replace {client id} with your client app ID. 
        //To learn how to get a client app ID, see Register a client app (https://msdn.microsoft.com/en-US/library/dn877542.aspx#clientID)
        private static string clientID = "{Client ID from Azure AD app registration}";

        //RedirectUri you used when you registered your app.
        //For a client app, a redirect uri gives AAD more details on the specific application that it will authenticate.
        private static string redirectUri = "https://login.live.com/oauth20_desktop.srf";
        
        //Resource Uri for Power BI API
        private static string resourceUri = "https://analysis.windows.net/powerbi/api";       
      
        //OAuth2 authority Uri
        private static string authority = "https://login.windows.net/common/oauth2/authorize";
        
        private static AuthenticationContext authContext = null;
        private static string token = String.Empty;

        //Uri for Power BI datasets
        private static string datasetsUri = "https://api.powerbi.com/v1.0/myorg";
        
        //Example dataset name and group name
        private static string datasetName = "SalesMarketing";
        private static string groupName = "Q1 Product Group";

        static void Main(string[] args)
        {
            //Example table name
            string tableName = "Product";

            Console.WriteLine("--- Power BI REST API examples ---");

            //Create Dataset operation
            Console.WriteLine("Press Enter key to create a Dataset in Power BI:");
            Console.ReadLine();

            CreateDataset();

            Console.WriteLine("Dataset created");

            //Get Datasets operation
            Console.WriteLine();
            Console.WriteLine("Press Enter key to get Datasets:");
            Console.ReadLine();

            //Get a dataset id from a Dataset name. The dataset id is used for UpdateTableSchema, AddRows, and DeleteRows
            string datasetId = GetDatasets().value.GetDataset(datasetName).Id;
            dataset[] datasets = GetDatasets().value;

            foreach (dataset ds in datasets)
            {
                Console.WriteLine(String.Format("id: {0} Name: {1}", ds.Id, ds.Name));
            }

            //Get Tables operation
            Console.WriteLine();
            Console.WriteLine("Press Enter key to get Tables in a Dataset:");
            Console.ReadLine();

            table[] tables = GetTables(datasetId).value;

            foreach (table table in tables)
            {
                Console.WriteLine(String.Format("Name: {0}", table.Name));
            }

            //Add Rows operation
            Console.WriteLine();
            Console.WriteLine("Press Enter key to Add Row to Dataset:");
            Console.ReadLine();

            AddRows(datasetId, tableName);

            Console.WriteLine("Rows added");

            //Delete Rows operation
            Console.WriteLine();
            Console.WriteLine("Press Enter key to Delete Rows to Dataset:");
            Console.ReadLine();

            DeleteRows(datasetId, tableName);

            Console.WriteLine("Rows deleted");
            
            //Update Table Schema operation
            Console.WriteLine();
            Console.WriteLine("Press the Enter key to update a table schema:");
            Console.ReadLine();

            UpdateTableSchema(datasetId, tableName);

            Console.WriteLine("Schema updated");
            Console.WriteLine();

            //*** Group operations ***
            //To create a group, see [Create a group](https://support.powerbi.com/knowledgebase/articles/654250)
            Console.WriteLine("Press Enter key to get Groups:");
            Console.ReadLine();

            //groupId is used for Group operations
            string groupId = GetGroups().value.GetGroup(groupName).Id;

            //Get Groups operation
            group[] groups = GetGroups().value;
            foreach (group grp in groups)
            {
                Console.WriteLine(String.Format("Name: {0} Name: {1}", grp.Name, grp.Id));
            }

            Console.WriteLine();

            //Create Dataset Group operation
            Console.WriteLine();
            Console.WriteLine("Press Enter key to create a Dataset in a Group:");
            Console.ReadLine();

            CreateDataset(groupId);

            string groupDatasetId = GetDatasets(groupId).value.GetDataset(datasetName).Id;

            Console.WriteLine();
            Console.WriteLine("Dataset created");

            //Get Datasets Group operation
            Console.WriteLine();
            Console.WriteLine("Press Enter key to get Datasets in a Group:");
            Console.ReadLine();

            dataset[] groupDatasets = GetDatasets(groupId).value;
            foreach (dataset ds in datasets)
            {
                Console.WriteLine(String.Format("id: {0} Name: {1}", ds.Id, ds.Name));
            }
         
            //Get Tables Group operation
            Console.WriteLine();
            Console.WriteLine("Press Enter key to get Tables in a Dataset in a Group:");
            Console.ReadLine();

            table[] groupTables = GetTables(groupId, groupDatasetId).value;
            foreach (table table in groupTables)
            {
                Console.WriteLine(String.Format("Name: {0}", table.Name));
            }

            //Add Rows Group operation
            Console.WriteLine();
            Console.WriteLine("Press Enter key to Add Row to Dataset in a Group:");
            Console.ReadLine();

            AddRows(groupId, groupDatasetId, tableName);

            Console.WriteLine("Rows added");

            //Delete Rows Group operation
            Console.WriteLine();
            Console.WriteLine("Press Enter key to Delete Rows to Dataset in a Group:");
            Console.ReadLine();

            DeleteRows(groupId, groupDatasetId, tableName);

            Console.WriteLine("Rows deleted");

            //Update Table Schema Group operation
            Console.WriteLine();
            Console.WriteLine("Press the Enter key to update a table schema in a Group:");
            Console.ReadLine();

            UpdateTableSchema(groupId, groupDatasetId, tableName);

            Console.WriteLine("Schema updated");

            // Finished pushing rows to Power BI, close the console window
            Console.WriteLine();
            Console.WriteLine("Data pushed to Power BI. Press the Enter key to close this window:");
            Console.ReadLine();
        }

        //The Create Dataset operation creates a new Dataset from a JSON schema definition and returns the Dataset ID 
        //and the properties of the dataset created.
        //POST https://api.powerbi.com/v1.0/myorg/datasets
        //Create Dataset operation: https://msdn.microsoft.com/en-US/library/mt203562(Azure.100).aspx
        static void CreateDataset()
        {
            //In a production application, use more specific exception handling.           
            try
            {
                //Create a POST web request to list all datasets
                HttpWebRequest request = DatasetRequest(String.Format("{0}/datasets", datasetsUri), "POST", AccessToken());

                //Get a list of datasets
                dataset ds = GetDatasets().value.GetDataset(datasetName);

                if (ds == null)
                { 
                    //POST request using the json schema from Product
                    Console.WriteLine(PostRequest(request, new Product().ToDatasetJson(datasetName)));
                }
                else
                {
                    Console.WriteLine("Dataset exists");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //Groups: The Create Dataset operation can also create a dataset in a group
        //POST https://api.PowerBI.com/v1.0/myorg/groups/{group_id}/datasets
        //Create Dataset operation: https://msdn.microsoft.com/en-US/library/mt203562(Azure.100).aspx
        static void CreateDataset(string groupId)
        {
            //In a production application, use more specific exception handling.           
            try
            {
                //Create a POST web request to list all datasets
                HttpWebRequest request = DatasetRequest(String.Format("{0}/groups/{1}/datasets", datasetsUri, groupId), "POST", AccessToken());

                //Get a list of datasets in groupId
                dataset[] groupDatasets = GetDatasets(groupId).value;

                if (groupDatasets.Count() == 0)
                {
                    //POST request using the json schema from Product into groupId
                    Console.WriteLine(PostRequest(request, new Product().ToDatasetJson(datasetName)));
                }
                else
                {
                    Console.WriteLine("Dataset exists in this group.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //The Get Datasets operation returns a JSON list of all Dataset objects that includes a name and id.
        //GET https://api.powerbi.com/v1.0/myorg/datasets
        //Get Dataset operation: https://msdn.microsoft.com/en-US/library/mt203567.aspx
        static Datasets GetDatasets()
        {
            Datasets response = null;

            //In a production application, use more specific exception handling.
            try
            {
                //Create a GET web request to list all datasets
                HttpWebRequest request = DatasetRequest(String.Format("{0}/datasets", datasetsUri), "GET", AccessToken());

                //Get HttpWebResponse from GET request
                string responseContent = GetResponse(request);

                JavaScriptSerializer json = new JavaScriptSerializer();
                response = (Datasets)json.Deserialize(responseContent, typeof(Datasets));
            }
            catch (Exception ex)
            {
                //In a production application, handle exception
            }

            return response;
        }

        //Groups: The Get Datasets operation can also get datasets in a group
        //GET https://api.powerbi.com/v1.0/myorg/groups/{group_id}/datasets
        //Get Dataset operation: https://msdn.microsoft.com/en-US/library/mt203567.aspx
        static Datasets GetDatasets(string groupId)
        {
            Datasets response = null;

            //In a production application, use more specific exception handling.
            try
            {
                //Create a GET web request to list all datasets in a group
                HttpWebRequest request = DatasetRequest(String.Format("{0}/groups/{1}/datasets", datasetsUri, groupId), "GET", AccessToken());

                //Get HttpWebResponse from GET request
                string responseContent = GetResponse(request);

                JavaScriptSerializer json = new JavaScriptSerializer();
                response = (Datasets)json.Deserialize(responseContent, typeof(Datasets));
            }
            catch (Exception ex)
            {
                //In a production application, handle exception
            }

            return response;
        }

        //The Get Tables operation returns a JSON list of Tables for the specified Dataset.
        //GET https://api.powerbi.com/v1.0/myorg/datasets/{dataset_id}/tables
        //Get Tables operation: https://msdn.microsoft.com/en-US/library/mt203556.aspx
        static Tables GetTables(string datasetId)
        {
            Tables response = null;

            //In a production application, use more specific exception handling.
            try
            {
                //Create a GET web request to list all datasets
                HttpWebRequest request = DatasetRequest(String.Format("{0}/datasets/{1}/tables", datasetsUri, datasetId), "GET", AccessToken());

                //Get HttpWebResponse from GET request
                string responseContent = GetResponse(request);

                JavaScriptSerializer json = new JavaScriptSerializer();
                response = (Tables)json.Deserialize(responseContent, typeof(Tables));
            }
            catch (Exception ex)
            {
                //In a production application, handle exception
            }

            return response;
        }

        //Groups: The Get Tables operation returns a JSON list of Tables for the specified Dataset in a Group.
        //GET https://api.powerbi.com/v1.0/myorg/groups/{group_id}/datasets/{dataset_id}/tables
        //Get Tables operation: https://msdn.microsoft.com/en-US/library/mt203556.aspx
        static Tables GetTables(string groupId, string datasetId)
        {
            Tables response = null;

            //In a production application, use more specific exception handling.
            try
            {
                //Create a GET web request to list all datasets
                HttpWebRequest request = DatasetRequest(String.Format("{0}/groups/{1}/datasets/{2}/tables", datasetsUri, groupId, datasetId), "GET", AccessToken());

                //Get HttpWebResponse from GET request
                string responseContent = GetResponse(request);

                JavaScriptSerializer json = new JavaScriptSerializer();
                response = (Tables)json.Deserialize(responseContent, typeof(Tables));
            }
            catch (Exception ex)
            {
                //In a production application, handle exception
            }

            return response;
        }

        //The Add Rows operation adds Rows to a Table in a Dataset.
        //POST https://api.powerbi.com/v1.0/myorg/datasets/{dataset_id}/tables/{table_name}/rows
        //Add Rows operation: https://msdn.microsoft.com/en-US/library/mt203561.aspx
        static void AddRows(string datasetId, string tableName)
        {
            //In a production application, use more specific exception handling. 
            try
            {
                HttpWebRequest request = DatasetRequest(String.Format("{0}/datasets/{1}/tables/{2}/rows", datasetsUri, datasetId, tableName), "POST", AccessToken());

                //Create a list of Product
                List<Product> products = new List<Product>
                {
                    new Product{ProductID = 1, Name="Adjustable Race", Category="Components", IsCompete = true, ManufacturedOn = new DateTime(2014, 7, 30)},
                    new Product{ProductID = 2, Name="LL Crankarm", Category="Components", IsCompete = true, ManufacturedOn = new DateTime(2014, 7, 30)},
                    new Product{ProductID = 3, Name="HL Mountain Frame - Silver", Category="Bikes", IsCompete = true, ManufacturedOn = new DateTime(2014, 7, 30)},
                };

                //POST request using the json from a list of Product
                //NOTE: Posting rows to a model that is not created through the Power BI API is not currently supported. 
                //      Please create a dataset by posting it through the API following the instructions on http://dev.powerbi.com.
                Console.WriteLine(PostRequest(request, products.ToJson(JavaScriptConverter<Product>.GetSerializer())));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //Groups: The Add Rows operation adds Rows to a Table in a Dataset in a Group.
        //POST https://api.powerbi.com/v1.0/myorg/groups/{group_id}/datasets/{dataset_id}/tables/{table_name}/rows
        //Add Rows operation: https://msdn.microsoft.com/en-US/library/mt203561.aspx
        static void AddRows(string groupId, string datasetId, string tableName)
        {
            //In a production application, use more specific exception handling. 
            try
            {
                HttpWebRequest request = DatasetRequest(String.Format("{0}/groups/{1}/datasets/{2}/tables/{3}/rows", datasetsUri, groupId, datasetId, tableName), "POST", AccessToken());

                //Create a list of Product
                List<Product> products = new List<Product>
                {
                    new Product{ProductID = 1, Name="Adjustable Race", Category="Components", IsCompete = true, ManufacturedOn = new DateTime(2014, 7, 30)},
                    new Product{ProductID = 2, Name="LL Crankarm", Category="Components", IsCompete = true, ManufacturedOn = new DateTime(2014, 7, 30)},
                    new Product{ProductID = 3, Name="HL Mountain Frame - Silver", Category="Bikes", IsCompete = true, ManufacturedOn = new DateTime(2014, 7, 30)},
                };

                //POST request using the json from a list of Product
                //NOTE: Posting rows to a model that is not created through the Power BI API is not currently supported. 
                //      Please create a dataset by posting it through the API following the instructions on http://dev.powerbi.com.
                Console.WriteLine(PostRequest(request, products.ToJson(JavaScriptConverter<Product>.GetSerializer())));

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //The Delete Rows operation deletes Rows from a Table in a Dataset.
        //DELETE https://api.powerbi.com/v1.0/myorg/datasets/{dataset_id}/tables/{table_name}/rows
        //Delete Rows operation: https://msdn.microsoft.com/en-US/library/mt238041.aspx
        static void DeleteRows(string datasetId, string tableName)
        {
            //In a production application, use more specific exception handling. 
            try
            {
                //Create a DELETE web request
                HttpWebRequest request = DatasetRequest(String.Format("{0}/datasets/{1}/tables/{2}/rows", datasetsUri, datasetId, tableName), "DELETE", AccessToken());
                request.ContentLength = 0;

                Console.WriteLine(GetResponse(request));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //Groups: The Delete Rows operation deletes Rows from a Table in a Dataset in a Group.
        //DELETE https://api.powerbi.com/v1.0/myorg/groups/{group_id}/datasets/{dataset_id}/tables/{table_name}/rows
        //Delete Rows operation: https://msdn.microsoft.com/en-US/library/mt238041.aspx
        static void DeleteRows(string groupId, string datasetId, string tableName)
        {
            //In a production application, use more specific exception handling. 
            try
            {
                //Create a DELETE web request
                HttpWebRequest request = DatasetRequest(String.Format("{0}/groups/{1}/datasets/{2}/tables/{3}/rows", datasetsUri, groupId, datasetId, tableName), "DELETE", AccessToken());
                request.ContentLength = 0;

                Console.WriteLine(GetResponse(request));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //The Update Table Schema operation updates a Table schema in a Dataset.
        //PUT https://api.powerbi.com/v1.0/myorg/datasets/{dataset_id}/tables/{table_name}
        //Update Table Schema operation: https://msdn.microsoft.com/en-US/library/mt203560.aspx
        static void UpdateTableSchema(string datasetId, string tableName)
        {
            //In a production application, use more specific exception handling.           
            try
            {
                //Create a POST web request to list all datasets
                HttpWebRequest request = DatasetRequest(String.Format("{0}/datasets/{1}/tables/{2}", datasetsUri, datasetId, tableName), "PUT", AccessToken());

                PostRequest(request, new Product2().ToTableSchema(tableName));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        //Groups: The Update Table Schema operation updates a Table schema in a Dataset in a Group.
        //PUT https://api.powerbi.com/v1.0/myorg/groups/{group_id}/datasets/{dataset_id}/tables/{table_name}
        //Update Table Schema operation: https://msdn.microsoft.com/en-US/library/mt203560.aspx
        static void UpdateTableSchema(string groupId, string datasetId, string tableName)
        {
            //In a production application, use more specific exception handling.           
            try
            {
                //Create a POST web request to list all datasets
                HttpWebRequest request = DatasetRequest(String.Format("{0}/groups/{1}/datasets/{2}/tables/{3}", datasetsUri, groupId, datasetId, tableName), "PUT", AccessToken());

                PostRequest(request, new Product2().ToTableSchema(tableName));
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

        //The Get Groups operation returns a JSON list of all the Groups that the signed in user is a member of. 
        //GET https://api.powerbi.com/v1.0/myorg/groups
        //Get Groups operation: https://msdn.microsoft.com/en-US/library/mt243842.aspx
        static Groups GetGroups()
        {
            Groups response = null;

            //In a production application, use more specific exception handling.
            try
            {

                //Create a GET web request to list all datasets
                HttpWebRequest request = DatasetRequest(String.Format("{0}/groups", datasetsUri), "GET", AccessToken());

                //Get HttpWebResponse from GET request
                string responseContent = GetResponse(request);

                JavaScriptSerializer json = new JavaScriptSerializer();
                response = (Groups)json.Deserialize(responseContent, typeof(Groups));
            }
            catch (Exception ex)
            {
                //In a production application, handle exception
            }

            return response;
        }

        /// <summary>
        /// Use AuthenticationContext to get an access token
        /// </summary>
        /// <returns></returns>
        static string AccessToken()
        {
            if (token == String.Empty)
            {
                //Get Azure access token
                // Create an instance of TokenCache to cache the access token
                TokenCache TC = new TokenCache();
                // Create an instance of AuthenticationContext to acquire an Azure access token
                authContext = new AuthenticationContext(authority, TC);
                // Call AcquireToken to get an Azure token from Azure Active Directory token issuance endpoint
                token = authContext.AcquireToken(resourceUri, clientID, new Uri(redirectUri), PromptBehavior.RefreshSession).AccessToken;
            }
            else
            {
                // Get the token in the cache
                token = authContext.AcquireTokenSilent(resourceUri, clientID).AccessToken;
            }

            return token;
        }
        private static string PostRequest(HttpWebRequest request, string json)
        {
            byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(json);
            request.ContentLength = byteArray.Length;

            //Write JSON byte[] into a Stream
            using (Stream writer = request.GetRequestStream())
            {
                writer.Write(byteArray, 0, byteArray.Length);
            }

            return GetResponse(request);
        }

        private static string GetResponse(HttpWebRequest request)
        {
            string response = string.Empty;

            using (HttpWebResponse httpResponse = request.GetResponse() as System.Net.HttpWebResponse)
            {
                //Get StreamReader that holds the response stream
                using (StreamReader reader = new System.IO.StreamReader(httpResponse.GetResponseStream()))
                {
                    response = reader.ReadToEnd();                 
                }
            }

            return response;
        }

        private static HttpWebRequest DatasetRequest(string datasetsUri, string method, string accessToken)
        {
            HttpWebRequest request = System.Net.WebRequest.Create(datasetsUri) as System.Net.HttpWebRequest;
            request.KeepAlive = true;
            request.Method = method;
            request.ContentLength = 0;
            request.ContentType = "application/json";
            request.Headers.Add("Authorization", String.Format( "Bearer {0}", accessToken));

            return request;
        }
    }
}
