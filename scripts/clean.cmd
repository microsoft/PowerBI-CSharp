setlocal
@echo off 
pushd "%~dp0"
echo Start cleaning...
for /d %%G in (%~dp0..\sdk\PowerBI.Api\bin, %~dp0..\sdk\PowerBI.Api\obj, %~dp0..\sdk\PowerBI.Api.Tests\bin, %~dp0..\sdk\PowerBI.Api.Tests\obj ) do (call :deletefolder %%G)

echo Cleaning Done.
endlocal
goto :eof

:deletefolder
setlocal
set folder =%1
if exist %1 (
   echo Deleting %1 
   rmdir %1 /s /q 
) else (
   echo Skipping %1
)
endlocal
