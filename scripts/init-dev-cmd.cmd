@echo off
echo ==================================================
echo "Initialize VS 2017 Dev Cmd ..."
echo ==================================================
pushd "%~dp0"

call "C:\Program Files (x86)\Microsoft Visual Studio\2017\Enterprise\Common7\Tools\VsDevCmd.bat" -arch=amd64 -host_arch=amd64

set EX=%ERRORLEVEL%
if "%EX%" neq "0" (
    echo "Failed to Initialize Dev Cmd ..."
)
popd
exit /B %EX%
