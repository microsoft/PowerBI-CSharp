@echo off
echo Start running pack-sdk.cmd ...
pushd "%~dp0"

echo call "C:\Program Files (x86)\Microsoft Visual Studio\2017\Enterprise\MSBuild\15.0\Bin\MsBuild.exe" %~dp0..\sdk\PowerBI.Api\PowerBI.Api.csproj /t:pack /p:Configuration=Release /p:PackageVersion=%CDP_PACKAGE_VERSION_NUMERIC% /p:PackageOutputPath=%~dp0..\pack\Dev
call "C:\Program Files (x86)\Microsoft Visual Studio\2017\Enterprise\MSBuild\15.0\Bin\MsBuild.exe" %~dp0..\sdk\PowerBI.Api\PowerBI.Api.csproj /t:pack /p:Configuration=Release /p:PackageVersion=%CDP_PACKAGE_VERSION_NUMERIC% /p:PackageOutputPath=%~dp0..\pack\Dev

set EX=%ERRORLEVEL%

if "%EX%" neq "0" (
    echo "Failed to pack PowerBI.Api.csproj."
    popd
    exit /B %EX%
)
echo "PowerBI.Api.csproj packed succesfuly"
popd
exit /B %EX%
