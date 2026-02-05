@echo off

chcp 65001 > nul

set CUR=%~dp0
set EXE_NAME=Batch.exe

"%CUR%%EXE_NAME%" %1 %2 %3

exit /b %ERRORLEVEL%
