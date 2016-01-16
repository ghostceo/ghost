::语法: call [[Drive:][Path] FileName [BatchParameters]] [:label [arguments]]
::参数: [Drive:][Path] FileName 指定要调用的批处理程序的位置和名称。filename 参数必须具有 .bat 或 .cmd 扩展名。
::调用另一个批处理程序，并且不终止父批处理程序。
::如果不用call而直接调用别的批处理文件，那么执行完那个批处理文件后将无法返回当前文件并执行当前文件的后续命令。
::call 命令接受用作调用目标的标签。如果在脚本或批处理文件外使用 Call，它将不会在命令行起作用。
::Sample：call="%cd%\test2.bat" haha kkk aaa (调用指定目录下的 test2.bat，且输入3个参数给他)
::Sample：call test2.bat arg1 arg2 (调用同目录下的 test2.bat，且输入2个参数给他)
echo %cd% 
echo %~dp0
::@del %cd%\makefile
::@xcopy %cd%\win\makefile  %cd%    /k /q
::make
@cmd