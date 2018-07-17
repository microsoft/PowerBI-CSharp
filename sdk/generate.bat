pushd "%~dp0"
del PowerBI.Api\Source\V2\Models
del PowerBI.Api\Source\V2\

@echo Generating code using powerbi.md
AutoRest powerbi.md
popd
pause