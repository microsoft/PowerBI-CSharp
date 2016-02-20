pushd "%~dp0"
rem rm -rf Generated\v1.0
rem AutoRest.exe -CodeGenerator CSharp -Modeler Swagger -Input https://onebox-redirect.analysis.windows-int.net/swagger/docs/v1.0 -Namespace Microsoft.PowerBI.Api -output PowerBI.Api\Source -name PowerBIClient -AddCredentials
rm -rf Generated\Beta
AutoRest.exe -CodeGenerator CSharp -Modeler Swagger -Input c:\users\wabreza\desktop\swagger.json -Namespace Microsoft.PowerBI.Api.Beta -output PowerBI.Api\Source\Beta -name PowerBIClient -AddCredentials
popd
pause