::¿½Connection
cd D:\WORK_SPACE\mobile\trunk\Connection\bin\Debug\
if exist "Connection.dll.mdb" (del Connection.dll.mdb)
echo 111
xcopy /s Connection.dll D:\WORK_SPACE\mobile\trunk\Assets\Plugins\ /y
D:\WORK_SPACE\mobile\trunk\Convertor\pdb2mdb.exe Connection.dll
xcopy /s "Connection.dll.mdb" D:\WORK_SPACE\mobile\trunk\Assets\Plugins\ /y
cd ..
cd ..
exit
::×¢ÊÍ·û