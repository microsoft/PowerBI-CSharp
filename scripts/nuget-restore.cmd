@echo off
pushd "%~dp0.."

set PACKAGES_DIRECTORY="%~dp0..\sdk\packages"
echo "Remove folder %PACKAGES_DIRECTORY% if exists"
if exist %PACKAGES_DIRECTORY% (
	call rmdir %PACKAGES_DIRECTORY% /s /q
)

echo Clean previous build outputs ...
call cmd.exe /c %~dp0clean.cmd
if exist msbuild.log del msbuild.log

echo call nuget restore "%~dp0..\sdk\PowerBI.CSharp.Sdk.sln" -ConfigFile "%~dp0..\sdk\.nuget\NuGet.Config" 
call nuget restore "%~dp0..\sdk\PowerBI.CSharp.Sdk.sln" -ConfigFile "%~dp0..\sdk\.nuget\NuGet.Config" 
set EX=%ERRORLEVEL%
if "%EX%" neq "0" (
    popd
    echo "Failed to restore nuget packages."
    exit /b %EX%
)

popd
exit /B %EX%
