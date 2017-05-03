pushd "%~dp0"
del PowerBI.Service.Api\Source\
AutoRest -CodeGenerator CSharp -Input PBIServiceApi.json -Namespace Microsoft.PowerBI.Service.Api.V1 -OutputDirectory PowerBI.Service.Api\Source\ -ClientName PowerBIClient -AddCredentials true
popd
pause