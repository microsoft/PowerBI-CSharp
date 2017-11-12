pushd "%~dp0"
del PowerBI.Api\Source\V2\Models
del PowerBI.Api\Source\V2\

set swagger="%1"
IF "%~1"=="" set swagger="./swaggers/swaggerV2.json"

@echo Generating code using %swagger%
AutoRest -CodeGenerator CSharp -Input %swagger% -Namespace Microsoft.PowerBI.Api.V2 -OutputDirectory PowerBI.Api\Source\V2\ -ClientName PowerBIClient -AddCredentials true
popd
pause