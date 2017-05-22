pushd "%~dp0"
del PowerBI.Api\Source\V2\
AutoRest -CodeGenerator CSharp -Input https://raw.githubusercontent.com/Microsoft/powerbi-rest-api-specs/master/swaggerV2.json -Namespace Microsoft.PowerBI.Api.V2 -OutputDirectory PowerBI.Api\Source\V2\ -ClientName PowerBIClient -AddCredentials true
popd
pause