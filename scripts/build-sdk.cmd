@echo off
echo Start running build-sdk.cmd ...
pushd "%~dp0"

call .\init-dev-cmd.cmd

echo ==================================================
echo "Build PowerBI.CSharp.Sdk.sln Release - AnyCPU..."
echo ==================================================
call msbuild %~dp0..\sdk\PowerBI.CSharp.Sdk.sln /p:Configuration=Release /p:Platform="AnyCPU" -fl

set EX=%ERRORLEVEL%
if "%EX%" neq "0" (
    echo "Failed to build PowerBI.CSharp.Sdk.sln."
)
popd
exit /B %EX%
