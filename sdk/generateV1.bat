pushd "%~dp0"
del PowerBI.Api\Source\V1\
AutoRest -CodeGenerator CSharp -Input https://raw.githubusercontent.com/Microsoft/powerbi-rest-api-specs/master/swagger.json -Namespace Microsoft.PowerBI.Api.V1 -OutputDirectory PowerBI.Api\Source\V1\ -ClientName PowerBIClient -AddCredentials true
popd
pause