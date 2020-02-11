# Power BI for .NET
> see https://aka.ms/autorest 

## Getting Started 
To build the SDK for PowerBI API, simply install AutoRest via `npm` (`npm install -g autorest`) and then run:
> `autorest powerbi.md`

``` yaml
input-file: swaggers\swagger.json
namespace: Microsoft.PowerBI.Api
use-extension: 
    "@microsoft.azure/autorest.csharp" : "2.2.57"
csharp:
    output-folder: PowerBI.Api\Source
    override-client-name: PowerBIClient
    add-credentials: true
    model-name: PowerBIClient 
```
