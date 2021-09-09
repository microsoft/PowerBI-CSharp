@echo off
echo Start running pack-sdk.cmd ...
pushd "%~dp0"

call .\init-dev-cmd.cmd

REM Set Package version
SET VERSION=%CDP_PACKAGE_VERSION_NUMERIC%
if "%VERSION%"=="" SET VERSION=0.0.1111

echo ========================================
echo "Pack PowerBI.Api.csproj Release - AnyCPU..."
echo ========================================
call msbuild %~dp0..\sdk\PowerBI.Api\PowerBI.Api.csproj /t:pack /p:Configuration=Release /p:PackageVersion=%VERSION%-dev /p:PackageOutputPath=%~dp0..\pack\Dev

set EX=%ERRORLEVEL%
if "%EX%" neq "0" (
    echo "Failed to pack PowerBI.Api.csproj."
)
popd
exit /B %EX%

