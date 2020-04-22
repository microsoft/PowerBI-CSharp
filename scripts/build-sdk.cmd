@echo off
echo Start running build-sdk.cmd ...
pushd "%~dp0"

echo Build PowerBI.CSharp.Sdk.sln Release - AnyCPU...
call "C:\Program Files (x86)\Microsoft Visual Studio\2017\Enterprise\MSBuild\15.0\Bin\MsBuild.exe" %~dp0..\sdk\PowerBI.CSharp.Sdk.sln /p:Configuration=Release /p:Platform="AnyCPU" -fl

set EX=%ERRORLEVEL%

if "%EX%" neq "0" (
    echo "Failed to build PowerBI.CSharp.Sdk.sln."
    popd
    exit /B %EX%
)
echo "PowerBI.CSharp.Sdk.sln built succesfuly"
popd
exit /B %EX%
