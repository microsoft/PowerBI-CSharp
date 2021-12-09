@echo off
pushd "%~dp0"

call .\init-dev-cmd.cmd

REM Set Major and Minor package version
SET MAJOR=%CDP_MAJOR_NUMBER_ONLY%
SET MINOR=%CDP_MINOR_NUMBER_ONLY%
SET PATCH=0
if "%MAJOR%"=="" SET MAJOR=0
if "%MINOR%"=="" SET MINOR=0


echo ========================================
echo "Pack PowerBI.Api.csproj Release - AnyCPU..."
echo ========================================
call msbuild %~dp0..\sdk\PowerBI.Api\PowerBI.Api.csproj /t:pack /p:Configuration=Release /p:CdpxPostSigning=true /p:PackageVersion=%MAJOR%.%MINOR%.%PATCH% /p:PackageOutputPath=%~dp0..\pack\Clean

set EX=%ERRORLEVEL%

if "%EX%" neq "0" (
    echo "Failed to pack PowerBI.Api.csproj."
)
popd
exit /B %EX%
