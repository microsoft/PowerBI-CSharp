pushd "%~dp0"
del PowerBI.Api\Source\V2\
AutoRest -CodeGenerator CSharp -Input F:\github\powerbi-rest-api-specs\swaggerV2.json -Namespace Microsoft.PowerBI.Api.V2 -OutputDirectory PowerBI.Api\Source\V2\ -ClientName PowerBIClient -AddCredentials true
popd
pause