pushd "%~dp0"
rm -rf PowerBI.Api\Source\
AutoRest.exe -CodeGenerator CSharp -Modeler Swagger -Input swagger.json -Namespace Microsoft.PowerBI.Api.V1 -output PowerBI.Api\Source\ -name PowerBIClient -AddCredentials
popd
pause