@echo off
echo Start running run-tests.cmd ...
pushd "%~dp0"

echo "C:\Program Files (x86)\Microsoft Visual Studio\2017\Enterprise\Common7\IDE\Extensions\TestPlatform\vstest.console.exe" /logger:trx /Platform:x64 /InIsolation %~dp0..\sdk\PowerBI.Api.Tests\bin\Release\PowerBI.Api.Tests.dll /framework:framework40 /ResultsDirectory:%~dp0../TestResults
call "C:\Program Files (x86)\Microsoft Visual Studio\2017\Enterprise\Common7\IDE\Extensions\TestPlatform\vstest.console.exe" /logger:trx /Platform:x64 /InIsolation %~dp0..\sdk\PowerBI.Api.Tests\bin\Release\PowerBI.Api.Tests.dll /framework:framework40 /ResultsDirectory:%~dp0../TestResults

set EX=%ERRORLEVEL%

if "%EX%" neq "0" (
    echo "Failed to run tests."
    popd
    exit /B %EX%
)
echo "Tests run succesfuly"
popd
exit /B %EX%
