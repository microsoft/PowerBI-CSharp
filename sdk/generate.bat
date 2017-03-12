pushd "%~dp0"
del PowerBI.Api\Source\
AutoRest.exe -CodeGenerator CSharp -Modeler Swagger -Input https://raw.githubusercontent.com/Microsoft/powerbi-rest-api-specs/master/swagger.json -Namespace Microsoft.PowerBI.Api.V1 -output PowerBI.Api\Source\ -name PowerBIClient -AddCredentials
popd
pause