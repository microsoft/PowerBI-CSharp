pushd "%~dp0"
del PowerBI.Api\Source\
AutoRest -CodeGenerator CSharp -Input https://raw.githubusercontent.com/Microsoft/powerbi-rest-api-specs/master/swaggerV2.json -Namespace Microsoft.PowerBI.Api.V1 -OutputDirectory PowerBI.Api\Source\ -ClientName PowerBIClient -AddCredentials true
popd
pause