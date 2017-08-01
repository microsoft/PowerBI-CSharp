# Power BI for .NET

Welcome to the .NET developer community for Power BI Embedded.  Here you will find resources for the .NET SDKs for Power BI Embedded.

For questions or issues using the SDKs please log an issue and we will respond as quickly as possible.

For more information regarding onboarding to Power BI Embedded see our [Azure documentation](https://azure.microsoft.com/en-us/services/power-bi-embedded/).

## Power BI Embedded REST Client
The `Microsoft.PowerBI.Api` is a .NET REST Client to easily consume the Power BI Embedded REST services.

### Install from Nuget
`Install-Package Microsoft.PowerBI.Api`

### Usage: Calling the GetReports API
As an example, to get a list or reports within your workspace (e.g. "My Workspace") you need to instantiate a `PowerBIClient` with credentials and call into the `GetReports` API.
```
var credential = new UserPasswordCredential(Username, Password);

// Authenticate using created credentials
var authenticationContext = new AuthenticationContext(AuthorityUrl);
var authenticationResult = authenticationContext.AcquireTokenAsync(ResourceUrl, ClientId, credential).Result;

var tokenCredentials = new TokenCredentials(authenticationResult.AccessToken, "Bearer");

// Create a Power BI Client object (it will be used to call Power BI APIs)
using (var client = new PowerBIClient(new Uri(ApiUrl), tokenCredentials))
{

    // Get a list of reports
    var reports = client.Reports.GetReports();

    // Do anything you want with the list of reports.
}

```

There are multiple variations for each method. For example, to get a list of reports you can use one of the methods below:

1) client.Reports.GetReports() - Synchronous method to get a list of reports in "My Workspace".

2) client.Reports.GetReportsInGroup(groupId) - Synchronous method to get a list of reports in specific group (e.g. App workspace).

3) client.Reports.GetReportsAsync() - async method to get a list of reports in "My Workspace".

4) client.Reports.GetReportsInGroupAsync(groupId) - async method to get a list of reports in specific group (e.g. App workspace).


The following API groups are available:

- Dashboards
- Datasets
- Gateways
- Groups
- Imports
- Reports

## Power BI Embedded for JavaScript
The JavaScript SDK is underlying component for all embed scenarios.  The SDK is vanilla JS but we also ship components for many popular SPA frameworks including Angular, React & Ember JS.  

Visit our [JavaScript SDK](https://github.com/Microsoft/powerbi-javascript) home for more information

### Install from Nuget
`Install-Package Microsoft.PowerBI.JavaScript`

### Setup Power BI for embedding
Add the Power BI script include before your apps closing `</body>` tag

*You can optionally add the CSS reference to an ASP.NET style bundle*

`<script src="/scripts/powerbi.js"></script>`

### Setting the size of embedded components
The tile & report embed will automatically be embedded based on the size of the embed container.  
To override the default size of the embeds simply add a CSS class attribute or inline styles for width & height.

# Embedding a Report
To embed a report, you need to write:
1) Backend code to generate Embed Tokens. This uses Microsoft.PowerBI.Api nuget.
2) Frontend code (javascript) to embed a report. This uses Microsoft.PowerBI.Javascript nuget.

A full sample is available in this [Github](https://github.com/Microsoft/PowerBI-developer-samples)

## Backend code sample To generate embed token

```
var credential = new UserPasswordCredential(Username, Password);

// Authenticate using created credentials
var authenticationContext = new AuthenticationContext(AuthorityUrl);
var authenticationResult = authenticationContext.AcquireTokenAsync(ResourceUrl, ClientId, credential).Result;

var tokenCredentials = new TokenCredentials(authenticationResult.AccessToken, "Bearer");

// Create a Power BI Client object (it will be used to call Power BI APIs)
using (var client = new PowerBIClient(new Uri(ApiUrl), tokenCredentials))
{

    // Get a list of reports
    var reports = client.Reports.GetReportsInGroup(GroupId);

    // Get the first report in the group
    var report = reports.Value.FirstOrDefault();

    // Generate an embed token
    var generateTokenRequestParameters = new GenerateTokenRequest(accessLevel: "view");
    var tokenResponse = client.Reports.GenerateTokenInGroup(GroupId, report.Id, generateTokenRequestParameters);

    embedToken = tokenResponse.Token;
    embedUrl = report.EmbedUrl;
    reportId = report.Id;
}
```

## Frontend code sample To embed a report using embed token
```
var txtAccessToken = "access token value";
var txtEmbedUrl = "embed url value";
var txtEmbedReportId = "report Id";
 
// Get models. models contains enums that can be used.
var models = window['powerbi-client'].models;
 
// We give All permissions to demonstrate switching between View and Edit mode and saving report.
var permissions = models.Permissions.All;
 
// Embed configuration used to describe the what and how to embed.
// This object is used when calling powerbi.embed.
// This also includes settings and options such as filters.
// You can find more information at https://github.com/Microsoft/PowerBI-JavaScript/wiki/Embed-Configuration-Details.
var config= {
    type: 'report',
    tokenType: models.TokenType.Embed,
    accessToken: txtAccessToken,
    embedUrl: txtEmbedUrl,
    id: txtEmbedReportId,
    permissions: permissions,
    settings: {
        filterPaneEnabled: true,
        navContentPaneEnabled: true
    }
};
 
// Get a reference to the embedded report HTML element
var embedContainer = $('#embedContainer')[0];
 
// Embed the report and display it within the div container.
var report = powerbi.embed(embedContainer, config);
 
// Report.off removes a given event handler if it exists.
report.off("loaded");
 
// Report.on will add an event handler which prints to Log window.
report.on("loaded", function() {
    Log.logText("Loaded");
});
 
report.on("error", function(event) {
    Log.log(event.detail);
     
    report.off("error");
});
 
report.off("saved");
report.on("saved", function(event) {
    Log.log(event.detail);
    if(event.detail.saveAs) {
        Log.logText('In order to interact with the new report, create a new token and load the new report');
     }
 });
```

## Live demo
A live demo of Power BI Embedded with a lot of javascript code sample is available [here](https://microsoft.github.io/PowerBI-JavaScript/demo/v2-demo/index.html).
