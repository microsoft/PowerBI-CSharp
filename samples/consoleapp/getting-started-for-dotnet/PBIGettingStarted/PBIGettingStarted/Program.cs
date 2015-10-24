//Copyright Microsoft 2015

using System;
using System.Collections.Generic;
using System.Linq;
using BISharp;
using System.Threading.Tasks;
using BISharp.Contracts;

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
        private static PowerBiAuthentication pbi = new PowerBiAuthentication(clientID);

        //Example dataset name and group name
        private static string datasetName = "SalesMarketing";
        private static string groupName = "Q1 Product Group";

        static void Main(string[] args)
        {
            Console.WriteLine("--- Power BI REST API examples ---");

            //Create Dataset operation
            Console.WriteLine("Press Enter key to create a Dataset in Power BI:");
            Console.ReadLine();

            CreateDataset().Wait();

            Console.WriteLine("Dataset created");

            //Get Datasets operation
            Console.WriteLine();
            Console.WriteLine("Press Enter key to get Datasets:");
            Console.ReadLine();

            //Get a dataset id from a Dataset name. The dataset id is used for UpdateTableSchema, AddRows, and DeleteRows
            string datasetId = GetDatasets().Result.value.First(d=>d.name==datasetName).id;
            var datasets = GetDatasets().Result.value;

            foreach (Dataset ds in datasets)
            {
                Console.WriteLine(String.Format("id: {0} Name: {1}", ds.id, ds.name));
            }

            //Get Tables operation
            Console.WriteLine();
            Console.WriteLine("Press Enter key to get Tables in a Dataset:");
            Console.ReadLine();

            var tables = GetTables(datasetId).Result.value;

            foreach (Table table in tables)
            {
                Console.WriteLine(String.Format("Name: {0}", table.name));
            }

            //Add Rows operation
            Console.WriteLine();
            Console.WriteLine("Press Enter key to Add Row to Dataset:");
            Console.ReadLine();

            AddRows(datasetId, typeof(Product).Name);

            Console.WriteLine("Rows added");

            //Delete Rows operation
            Console.WriteLine();
            Console.WriteLine("Press Enter key to Delete Rows to Dataset:");
            Console.ReadLine();

            DeleteRows(datasetId, typeof(Product).Name);

            Console.WriteLine("Rows deleted");
            
            //Update Table Schema operation
            Console.WriteLine();
            Console.WriteLine("Press the Enter key to update a table schema:");
            Console.ReadLine();

            UpdateTableSchema(datasetId, typeof(Product).Name);

            Console.WriteLine("Schema updated");
            Console.WriteLine();

            //*** Group operations ***
            //To create a group, see [Create a group](https://support.powerbi.com/knowledgebase/articles/654250)
            Console.WriteLine("Press Enter key to get Groups:");
            Console.ReadLine();

            //groupId is used for Group operations
            string groupId = GetGroups().Result.value.First(g=>g.name == groupName).id;

            //Get Groups operation
            var groups = GetGroups().Result.value;
            foreach (Group grp in groups)
            {
                Console.WriteLine(String.Format("Name: {0} Name: {1}", grp.name, grp.id));
            }

            Console.WriteLine();

            //Create Dataset Group operation
            Console.WriteLine();
            Console.WriteLine("Press Enter key to create a Dataset in a Group:");
            Console.ReadLine();

            CreateDataset(groupId);

            string groupDatasetId = GetDatasets(groupId).Result.value.First(d=>d.name == datasetName).id;

            Console.WriteLine();
            Console.WriteLine("Dataset created");

            //Get Datasets Group operation
            Console.WriteLine();
            Console.WriteLine("Press Enter key to get Datasets in a Group:");
            Console.ReadLine();

            var groupDatasets = GetDatasets(groupId).Result.value;
            foreach (Dataset ds in datasets)
            {
                Console.WriteLine(String.Format("id: {0} Name: {1}", ds.id, ds.name));
            }
         
            //Get Tables Group operation
            Console.WriteLine();
            Console.WriteLine("Press Enter key to get Tables in a Dataset in a Group:");
            Console.ReadLine();

            var groupTables = GetTables(groupId, groupDatasetId).Result.value;
            foreach (Table table in groupTables)
            {
                Console.WriteLine(String.Format("Name: {0}", table.name));
            }

            //Add Rows Group operation
            Console.WriteLine();
            Console.WriteLine("Press Enter key to Add Row to Dataset in a Group:");
            Console.ReadLine();

            AddRows(groupId, groupDatasetId, typeof(Product).Name);

            Console.WriteLine("Rows added");

            //Delete Rows Group operation
            Console.WriteLine();
            Console.WriteLine("Press Enter key to Delete Rows to Dataset in a Group:");
            Console.ReadLine();

            DeleteRows(groupId, groupDatasetId, typeof(Product).Name);

            Console.WriteLine("Rows deleted");

            //Update Table Schema Group operation
            Console.WriteLine();
            Console.WriteLine("Press the Enter key to update a table schema in a Group:");
            Console.ReadLine();

            UpdateTableSchema(groupId, groupDatasetId, typeof(Product).Name);

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
        static async Task CreateDataset()
        {
            //In a production application, use more specific exception handling.           
            try
            {
                var datasetsClient = new DatasetsClient(pbi);

                Dataset ds = (await datasetsClient.List()).value.First(d=>d.name == datasetName);

                if (ds == null)
                {
                    //create a dataset using the schema from Product
                    await datasetsClient.Create<Product>(datasetName, false);
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
        static async Task CreateDataset(string groupId)
        {
            try
            {
                var datasetsClient = new DatasetsClient(pbi);

                Dataset ds = (await datasetsClient.List(groupId)).value.First(d => d.name == datasetName);

                if (ds == null)
                {
                    //create a dataset using the schema from Product
                    await datasetsClient.Create<Product>(groupId, datasetName, false);
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

        //The Get Datasets operation returns a JSON list of all Dataset objects that includes a name and id.
        //GET https://api.powerbi.com/v1.0/myorg/datasets
        //Get Dataset operation: https://msdn.microsoft.com/en-US/library/mt203567.aspx
        static async Task<Datasets> GetDatasets()
        {
            DatasetsClient client = new DatasetsClient(pbi);
            return await client.List();
        }

        //Groups: The Get Datasets operation can also get datasets in a group
        //GET https://api.powerbi.com/v1.0/myorg/groups/{group_id}/datasets
        //Get Dataset operation: https://msdn.microsoft.com/en-US/library/mt203567.aspx
        static async Task<Datasets> GetDatasets(string groupId)
        {
            DatasetsClient client = new DatasetsClient(pbi);
            return await client.List(groupId);
        }

        //The Get Tables operation returns a JSON list of Tables for the specified Dataset.
        //GET https://api.powerbi.com/v1.0/myorg/datasets/{dataset_id}/tables
        //Get Tables operation: https://msdn.microsoft.com/en-US/library/mt203556.aspx
        static async Task<Tables> GetTables(string datasetId)
        {
            var client = new DatasetsClient(pbi);
            return await client.ListTables(datasetId);
        }

        //Groups: The Get Tables operation returns a JSON list of Tables for the specified Dataset in a Group.
        //GET https://api.powerbi.com/v1.0/myorg/groups/{group_id}/datasets/{dataset_id}/tables
        //Get Tables operation: https://msdn.microsoft.com/en-US/library/mt203556.aspx
        static async Task<Tables> GetTables(string groupId, string datasetId)
        {
            var client = new DatasetsClient(pbi);
            return await client.ListTables(groupId, datasetId);
        }

        //The Add Rows operation adds Rows to a Table in a Dataset.
        //POST https://api.powerbi.com/v1.0/myorg/datasets/{dataset_id}/tables/{table_name}/rows
        //Add Rows operation: https://msdn.microsoft.com/en-US/library/mt203561.aspx
        static void AddRows(string datasetId, string tableName)
        {
            //In a production application, use more specific exception handling. 
            try
            {
                var datasetClient = new DatasetsClient(pbi);
                //Create a list of Product
                List<Product> products = new List<Product>
                {
                    new Product{ProductID = 1, Name="Adjustable Race", Category="Components", IsCompete = true, ManufacturedOn = new DateTime(2014, 7, 30)},
                    new Product{ProductID = 2, Name="LL Crankarm", Category="Components", IsCompete = true, ManufacturedOn = new DateTime(2014, 7, 30)},
                    new Product{ProductID = 3, Name="HL Mountain Frame - Silver", Category="Bikes", IsCompete = true, ManufacturedOn = new DateTime(2014, 7, 30)},
                };
                var tableRows = new TableRows<Product>();
                tableRows.rows = products;

                //POST request using the json from a list of Product
                //NOTE: Posting rows to a model that is not created through the Power BI API is not currently supported. 
                //      Please create a dataset by posting it through the API following the instructions on http://dev.powerbi.com.
                datasetClient.AddRows<Product>(datasetId, tableName, tableRows);
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
                var datasetClient = new DatasetsClient(pbi);
                //Create a list of Product
                List<Product> products = new List<Product>
                {
                    new Product{ProductID = 1, Name="Adjustable Race", Category="Components", IsCompete = true, ManufacturedOn = new DateTime(2014, 7, 30)},
                    new Product{ProductID = 2, Name="LL Crankarm", Category="Components", IsCompete = true, ManufacturedOn = new DateTime(2014, 7, 30)},
                    new Product{ProductID = 3, Name="HL Mountain Frame - Silver", Category="Bikes", IsCompete = true, ManufacturedOn = new DateTime(2014, 7, 30)},
                };
                var tableRows = new TableRows<Product>();
                tableRows.rows = products;

                //POST request using the json from a list of Product
                //NOTE: Posting rows to a model that is not created through the Power BI API is not currently supported. 
                //      Please create a dataset by posting it through the API following the instructions on http://dev.powerbi.com.
                datasetClient.AddRows<Product>(groupId, datasetId, tableName, tableRows);
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
            var datasetClient = new DatasetsClient(pbi);
            datasetClient.ClearRows(datasetId, tableName);
        }

        //Groups: The Delete Rows operation deletes Rows from a Table in a Dataset in a Group.
        //DELETE https://api.powerbi.com/v1.0/myorg/groups/{group_id}/datasets/{dataset_id}/tables/{table_name}/rows
        //Delete Rows operation: https://msdn.microsoft.com/en-US/library/mt238041.aspx
        static void DeleteRows(string groupId, string datasetId, string tableName)
        {
            var datasetClient = new DatasetsClient(pbi);
            datasetClient.ClearRows(groupId, datasetId, tableName);
        }

        //The Update Table Schema operation updates a Table schema in a Dataset.
        //PUT https://api.powerbi.com/v1.0/myorg/datasets/{dataset_id}/tables/{table_name}
        //Update Table Schema operation: https://msdn.microsoft.com/en-US/library/mt203560.aspx
        static void UpdateTableSchema(string datasetId, string tableName)
        {
            var datasetsClient = new DatasetsClient(pbi);
            datasetsClient.UpdateTableSchema<Product2>(datasetId, tableName);
        }


        //Groups: The Update Table Schema operation updates a Table schema in a Dataset in a Group.
        //PUT https://api.powerbi.com/v1.0/myorg/groups/{group_id}/datasets/{dataset_id}/tables/{table_name}
        //Update Table Schema operation: https://msdn.microsoft.com/en-US/library/mt203560.aspx
        static void UpdateTableSchema(string groupId, string datasetId, string tableName)
        {
            var datasetsClient = new DatasetsClient(pbi);
            datasetsClient.UpdateTableSchema<Product2>(groupId, datasetId, tableName);
        }

        //The Get Groups operation returns a JSON list of all the Groups that the signed in user is a member of. 
        //GET https://api.powerbi.com/v1.0/myorg/groups
        //Get Groups operation: https://msdn.microsoft.com/en-US/library/mt243842.aspx
        static async Task<Groups> GetGroups()
        {
            var groupsClient = new GroupClient(pbi);
            return await groupsClient.Get();
        }
    }
}
