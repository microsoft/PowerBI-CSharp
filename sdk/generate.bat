pushd "%~dp0"
del PowerBI.Api\Source\
AutoRest -Input https://raw.githubusercontent.com/Microsoft/powerbi-rest-api-specs/master/swagger.json -AddCredentials true -ClientName PowerBIClient  -CodeGenerator Azure.CSharp -Namespace Microsoft.PowerBI.Api.V1  -OutputDirectory PowerBI.Api\Source\ 
popd
pause