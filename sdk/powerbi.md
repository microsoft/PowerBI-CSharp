# Power BI for .NET
> see https://aka.ms/autorest 

## Getting Started 
To build the SDK for PowerBI API, simply install AutoRest via `npm` (`npm install -g autorest`) and then run:
> `autorest powerbi.md`

``` yaml
input-file: swaggers\swaggerV2.json
namespace: Microsoft.PowerBI.Api.V2
use-extension: 
    "@microsoft.azure/autorest.csharp" : "2.2.57"
csharp:
    output-folder: PowerBI.Api\Source\V2
    override-client-name: PowerBIClient
    add-credentials: true
    model-name: PowerBIClient 
```
