@echo off
pushd "%~dp0"
call .\init-dev-cmd.cmd

echo ========================================
echo "Run PowerBI.Api.Tests ..."
echo ========================================
call "vstest.console" /logger:trx /Platform:x64 /InIsolation %~dp0..\sdk\PowerBI.Api.Tests\bin\Release\PowerBI.Api.Tests.dll /framework:framework40 /ResultsDirectory:%~dp0..\TestResults

set EX=%ERRORLEVEL%

if "%EX%" neq "0" (
    echo "Failed to run tests."
)
popd
exit /B %EX%
