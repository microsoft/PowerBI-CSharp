pushd "%~dp0"
rd PowerBI.Api\Source\ /s /q

@echo Generating code using powerbi.md
AutoRest powerbi.md
popd
pause