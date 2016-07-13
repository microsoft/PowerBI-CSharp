# Power BI for .NET

## Install Nuget Packages
###For ASP.NET MVC
`Install-Package Microsoft.PowerBI.Mvc`

###For ASP.NET Webforms
`Install-Package Microsoft.PowerBI.WebForms`

## Authenticate with Power BI via Azure AD

# ASP.NET MVC
## Install Nuget Packages
`Install-Package Microsoft.PowerBI.Mvc -Version 1.0.0-preview`

## Setup Power BI for embedding
Add the Power BI CSS link within your apps `<head>` tag.

*You can optionally add the script reference to an ASP.NET script bundle*

`<link href="/content/powerbi.css" rel="stylesheet"/>`

Add the Power BI script include before your apps closing `</body>` tag

*You can optionally add the CSS reference to an ASP.NET style bundle*

`<script src="/scripts/powerbi.js"></script>`

## Setup your Access Token
Ensure you have the following in your view

`@Html.PowerBIAccessToken()`

Or, if you are managing access tokens yourself, make sure to provide it here

`@Html.PowerBIAccesstoken({{YourAccesstoken}})`

## Setting the size of embedded components
The tile & report embed will automatically be embedded based on the size of the embed container.  
To override the default size of the embeds simply add a CSS class attribute or inline styles for width & height.

## Embedding a Report

Or, directly embed from a full report embed url

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
