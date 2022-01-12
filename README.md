# Power BI REST APIs for .NET

## Overview
The Power BI REST APIs provide service endpoints for embedding, user resources management, administration and governance.

For more information about Power BI REST APIs, see [Power BI REST APIs overview](https://docs.microsoft.com/rest/api/power-bi/).

## Power BI API library 
The Microsoft.PowerBI.Api library for .NET enables you to work with Power BI REST APIs in your .NET or NET Core application.

Install the [NuGet package](https://www.nuget.org/packages/Microsoft.PowerBI.Api/) directly from the Visual Studio [Package Manager console](https://docs.microsoft.com/en-us/nuget/consume-packages/install-use-packages-powershell).

### Visual Studio Package Manager
```powershell
Install-Package Microsoft.PowerBI.Api
```

## Examples

Below are basic examples demonstrating some of the most common capabilities of the SDK.
Full examples including authentication are avaliable in [PowerBI-Developer-Samples](https://github.com/Microsoft/PowerBI-Developer-Samples)

### Get the list of datasets and reports in a Power BI workspace
```C#
...
using (PowerBIClient client = new PowerBIClient(credentials))
{

    Console.WriteLine("\r*** DATASETS ***\r");

    // List of datasets in a workspace
    Datasets datasets = client.Datasets.GetDatasets(groupId);

    foreach(Dataset ds in datasets.Value)
    {
        Console.WriteLine(ds.Id + " | " + ds.Name);
    }

    Console.WriteLine("\r*** REPORTS ***\r");

    // List of reports in a workspace
    Reports reports = client.Reports.GetReports(groupId);

    foreach (Report rpt in reports.Value)
    {
        Console.WriteLine(rpt.Id + " | " + rpt.Name +  " | DatasetID = " + rpt.DatasetId);
    }
}
...
```
### Creating an Embed Token to reports and datasets
Embed tokens are used to provide access to Power BI artifacts like reports and datasets to embed into an application.
To create a report embed token you will need a Power BI Embedded capacity, and the Ids of the workspaces and artifacts to provide access to.
For more information about Power BI Embedded visit the [Power BI Embedded Analytics Playground](https://playground.powerbi.com)


```C#
...
using (PowerBIClient client = new PowerBIClient(credentials))
{
    // Create a request for getting Embed token
    var tokenRequest = new GenerateTokenRequestV2(datasets: datasets, reports: reports, targetWorkspaces: workspaces, identities: identities);

    // Get Embed token
    var embedToken = client.EmbedToken.GenerateToken(tokenRequest);
}
...
```
### Get Reports As Admin
Returns a list of reports for the organization. The caller must have administrator rights.
```C#
...
using (PowerBIClient client = new PowerBIClient(credentials))
{
    Console.WriteLine("\r*** REPORTS ***\r");

    // List of reports in the organization.
    AdminReports reports = client.Reports.GetReportsAsAdmin();

    foreach (AdminReport rpt in reports.Value)
    {
        Console.WriteLine(rpt.Id + " | " + rpt.Name);
    }
}
...
```

## Additional links
- [Power BI REST APIs](https://docs.microsoft.com/rest/api/power-bi/)
- [PowerBI-Developer-Samples](https://github.com/Microsoft/PowerBI-Developer-Samples)
- [AAD Application registration](https://docs.microsoft.com/power-bi/developer/embedded/register-app?tabs=customers%2CAzure#register-an-azure-ad-app)
- [Power BI Embedded Analytics Playground](https://playground.powerbi.com)
- [PowerBI Powershell CmdLet](https://github.com/microsoft/powerbi-powershell)
