# Power BI for .NET

## Install Nuget Packages
### Power BI Embedded Core Libraries
`Install-Package Microsoft.PowerBI.Core`

### Power BI Embedded REST Client
`Install-Package Microsoft.PowerBI.Api`

###Power BI Embedded for JavaScript
`Install-Package Microsoft.PowerBI.JavaScript`

## Setup Power BI for embedding
Add the Power BI CSS link within your apps `<head>` tag.

*You can optionally add the script reference to an ASP.NET script bundle*

`<link href="/content/powerbi.css" rel="stylesheet"/>`

Add the Power BI script include before your apps closing `</body>` tag

*You can optionally add the CSS reference to an ASP.NET style bundle*

`<script src="/scripts/powerbi.js"></script>`



## Setting the size of embedded components
The tile & report embed will automatically be embedded based on the size of the embed container.  
To override the default size of the embeds simply add a CSS class attribute or inline styles for width & height.

# ASP.NET MVC
##Install Nuget Packages
`Install-Package Microsoft.PowerBI.Mvc`

## Setup your Access Token
`@Html.PowerBIAccesstoken({{YourAccesstoken}})`

Or, directly embed from a full report embed url

## Embed your report
`@Html.PowerBIReportFor(m => m.EmbedUrl)`

# ASP.NET WebForms
## Install Nuget Packages
`Install-Package Microsoft.PowerBI.WebForms`

## Setup your Access Token
Ensure you have the following in your view

`<powerbi:Token ID="pbiAccessToken" runat="server" />`

If you are managing access tokens yourself, make sure to provide it here

`<powerbi:Token ID="pbiAccessToken" AccessToken="{{YourAccessToken}}" runat="server" />`

## Embedding a Report

`<powerbi:Report id="pbiReport" EmbedUrl="{{EmbedUrl}}" runat="server" />`
