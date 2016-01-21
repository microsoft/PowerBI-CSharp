# Power BI for ASP.NET
## Setup Nuget Package Source

- Name: **Power BI Private Nuget** *(For internal use only)*
- Source: https://www.myget.org/F/powerbi/auth/19dee0e1-a453-4d39-bcae-9b5f3d7469f3/api/v3/index.json

*Make sure to check the "Include prerelease" checkbox within the Nuget Package Manager*

## Install Nuget Packages
###For ASP.NET MVC
`Install-Package Microsoft.PowerBI.Mvc -Version 1.0.0-preview`

###For ASP.NET Webforms
`Install-Package Microsoft.PowerBI.WebForms -Version 1.0.0-preview`

## Get Power BI Client ID & Secret
Go to [Power BI Dev Center](https://dev.powerbi.com/apps) to get your client id and secret

## Authenticate with Power BI via Azure AD

### For ASP.NET Web Applications
- Update the appSettings within your web.config

```
  <appSettings>
    <add key="ida:ClientId" value="{{ClientId}}" />
    <add key="ida:ClientSecret" value="{{ClientSecret}}" />
    <add key="ida:Issuer" value="https://sts.windows.net/{{TenantId}}/" /> // Your Azure AD tenant
    <add key="ida:RedirectUri" value="{{RedirectdUri}}" /> // The redirect uri you used when registering the application
  </appSettings>
```
- Create an `App_Start/Startup.Auth.cs` file with the following code:

```
using Owin;
using System.Configuration;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;

namespace MvcApp
{
    public partial class Startup
    {
        public void ConfigureAuth(IAppBuilder app)
        {
            app.SetDefaultSignInAsAuthenticationType(CookieAuthenticationDefaults.AuthenticationType);
            app.UseCookieAuthentication(new CookieAuthenticationOptions { });

            app.UsePowerBIAuthentication((options) =>
            {
                options.ClientId = ConfigurationManager.AppSettings["ida:ClientId"];
                options.ClientSecret = ConfigurationManager.AppSettings["ida:ClientSecret"];
                options.Issuer = ConfigurationManager.AppSettings["ida:Issuer"];
                options.SuccessRedirectUri = new System.Uri(ConfigurationManager.AppSettings["ida:RedirectUri"]);
            });
        }
    }
}
```

### Managing your own authentication
#### Store your access token
Store your access token with Power BI after you have acquired your Power BI access token.

```
Microsoft.PowerBI.Security.TokenManager.Current.WriteToken(context.AuthenticationTicket.Identity, result.AccessToken);
```

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

## Embedding a Dashboard Tile
Use our build in MVC HTML helpers

Pass in your `ITile` model from our API call

`@Html.PowerBITileFor(m => m.Tile)`

Or, directly embed from a full tile embed url

`@Html.PowerBITileFor(m => m.EmbedUrl)`

## Embedding a Report

Pass in your `IReport` model from our API call

`@Html.PowerBIReportFor(m => m.Report)`

Or, directly embed from a full report embed url

`@Html.PowerBIReportFor(m => m.EmbedUrl)`

**That's it!  Enjoy!**

# ASP.NET WebForms
## Install Nuget Packages
`Install-Package Microsoft.PowerBI.WebForms -Version 1.0.0-preview`

## Setup your Access Token
Ensure you have the following in your view

`<powerbi:Token ID="pbiAccessToken" runat="server" />`

If you are managing access tokens yourself, make sure to provide it here

`<powerbi:Token ID="pbiAccessToken" AccessToken="{{YourAccessToken}}" runat="server" />`

## Embedding a Dashboard Tile
Use our build in MVC HTML helpers

You can either set the full `EmbedUrl`, or just provide the `ReportId`.

`<powerbi:Report id="pbiReport" ReportId="{{ReportId}}" EmbedUrl="{{EmbedUrl}}" runat="server" />`

## Embedding a Report

You can either set the full `EmbedUrl`, or just provide the `DashboardId` and `TileId`.

`<powerbi:Tile id="pbiTile" DashboardId="{{DashboardId}}" TileId="{{TileId}}" EmbedUrl="{{EmbedUrl}}" runat="server" />`

**That's it!  Enjoy!**
