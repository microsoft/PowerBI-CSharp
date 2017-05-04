pushd "%~dp0"
del PowerBI.Api\Source\
AutoRest -CodeGenerator CSharp -Input PBIServiceApi.json -Namespace Microsoft.PowerBI.Api.V1 -OutputDirectory PowerBI.Api\Source\ -ClientName PowerBIClient -AddCredentials true
popd
pause