# Power BI for .NET

Welcome to the .NET developer community for Power BI Embedded.  Here you will find resources for the .NET SDKs for Power BI Embedded.
If you are looking for the older samples they have been moved to the `saas-samples` branch [here](https://github.com/Microsoft/PowerBI-CSharp/tree/saas-samples).

For questions or issues using the SDKs please log an issue and we will respond as quickly as possible.

For more information regarding onboarding to Power BI Embedded see our [Azure documentation](https://azure.microsoft.com/en-us/services/power-bi-embedded/).

## Power BI Embedded Core Libraries
The `Microsoft.PowerBI.Core` package contains APIs to generate report embed tokens.

### Install from Nuget
`Install-Package Microsoft.PowerBI.Core`

### Usage: Creating a Report Embed Token
Power BI Embedded uses embed tokens, which are HMAC signed JSON Web Tokens.  The tokens are signed with the access key from your Azure Power BI Embedded workspace collection.
Embed tokens are used to provide read only access to a report to embed into an application.

To create a report embed token you will need an Azure Power BI Workspace collection, access key, workspace Id & report Id

```
var accessKey = "{AzureAccessKey}";
var embedToken = PowerBIToken.CreateReportEmbedToken(workspaceCollection, workspaceId, reportId);
var jwt = embedToken.Generate(accessKey);

```

### Required Claims
- ver: 0.2.0
- wcn: {WorkspaceCollectionName}
- wid: {WorkspaceId}
- rid: {ReportId}
- aud: https://analysis.windows.net/powerbi/api
- exp: Token expiration in Unix EPOCH time

### Optional Claims
- nbp: Token valid not before in Unix EPOCH time
- username: The effective username to pass to Power BI Embedded for RLS (Row level security)
- roles: The roles to pass to Power BI Embedded for RLS

Read more about [row level security](https://azure.microsoft.com/en-us/documentation/articles/power-bi-embedded-rls/) in our Azure docs.

### Token Example
eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJ2ZXIiOiIwLjIuMCIsIndjbiI6IlN1cHBvcnREZW1vIiwid2lkIjoiY2E2NzViMTktNmMzYy00MDAzLTg4MDgtMWM3ZGRjNmJkODA5IiwicmlkIjoiOTYyNDFmMGYtYWJhZS00ZWE5LWEwNjUtOTNiNDI4ZWRkYjE3IiwiaXNzIjoiUG93ZXJCSVNESyIsImF1ZCI6Imh0dHBzOi8vYW5hbHlzaXMud2luZG93cy5uZXQvcG93ZXJiaS9hcGkiLCJleHAiOjEzNjAwNDcwNTYsIm5iZiI6MTM2MDA0MzQ1Nn0.LgG2y0m24gg3vjQHhkXYYWKSVnGIUYT-ycA6JmTB6tg

## Power BI Embedded REST Client
The `Microsoft.PowerBI.Api` is a .NET REST Client to easily consume the Power BI Embedded REST services.

### Install from Nuget
`Install-Package Microsoft.PowerBI.Api`

### Usage: Calling the GetReports API
As an example, to get a list or reports within your workspace you need to instantiate a `PowerBIClient` with credentials and call into the `GetReports` API.
```
var credentials = new TokenCredentials("{AzureAccessKey}", "AppKey");
var client = new PowerBIClient(credentials);

var reportsResult = await client.Reports.GetReportsAsync(workspaceCollection, workspaceId);

```

The following APIs groups are available:

- Datasets
- Gateways
- Imports
- Reports
- Workspaces

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

# ASP.NET MVC
The `Microsoft.PowerBI.Mvc` package is a lightweight wrapper that contains MVC HTML helpers that generate HTML markup compatible with the core JavaScript SDK.

## Install from Nuget
`Install-Package Microsoft.PowerBI.Mvc`

## Setup your Access Token
Generate your report embed access token with the `Microsoft.PowerBI.Core` token APIs.
`@Html.PowerBIAccesstoken({{YourAccesstoken}})`

## Embed your report
`@Html.PowerBIReportFor(m => m.EmbedUrl)`

# ASP.NET WebForms
The `Microsoft.PowerBI.WebForms` package is a lightweight wrapper that contains ASP.NET Webform controls that generate HTML markup compatible with the core JavaScript SDK.
## Install from Nuget
`Install-Package Microsoft.PowerBI.WebForms`

## Setup your Access Token
Ensure you have the following in your view

`<powerbi:Token ID="pbiAccessToken" runat="server" />`

If you are managing access tokens yourself, make sure to provide it here

`<powerbi:Token ID="pbiAccessToken" AccessToken="{{YourAccessToken}}" runat="server" />`

## Embedding a Report

`<powerbi:Report id="pbiReport" EmbedUrl="{{EmbedUrl}}" runat="server" />`
