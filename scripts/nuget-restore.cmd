@echo off
pushd "%~dp0"

set PACKAGES_DIRECTORY="%~dp0..\sdk\packages"
echo "Remove folder %PACKAGES_DIRECTORY% if exists"
if exist %PACKAGES_DIRECTORY% (
    call rmdir %PACKAGES_DIRECTORY% /s /q
)

echo Clean previous build outputs ...
call cmd.exe /c %~dp0clean.cmd
if exist msbuild.log del msbuild.log

call .\init-dev-cmd.cmd

echo =====================================================
echo "Restoring Nuget packages for PowerBI.CSharp.Sdk.sln"
echo =====================================================
nuget restore -NonInteractive "%~dp0..\sdk\PowerBI.CSharp.Sdk.sln" -ConfigFile "%~dp0..\sdk\.nuget\NuGet.Config"

set EX=%ERRORLEVEL%
if "%EX%" neq "0" (
    echo Failed to restore dependencies for PowerBI.CSharp.Sdk.sln
)
popd
exit /B %EX%
