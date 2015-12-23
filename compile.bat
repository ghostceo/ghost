::echo %cd% 输出当前目录F:\hello
::echo %~dp0   :: F:\hello\
@del %cd%\makefile
@xcopy %cd%\win\makefile  %cd%    /k /q
make
@cmd