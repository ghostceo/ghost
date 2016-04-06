::¿½GameCore
cd D:\WORK_SPACE\mobile\trunk\GameCore\bin\Debug\
if exist "GameCore.dll.mdb" (del GameCore.dll.mdb)
echo 111
xcopy /s GameCore.dll D:\WORK_SPACE\mobile\trunk\Assets\Plugins\ /y
D:\WORK_SPACE\mobile\trunk\Convertor\pdb2mdb.exe GameCore.dll
xcopy /s "GameCore.dll.mdb" D:\WORK_SPACE\mobile\trunk\Assets\Plugins\ /y
cd ..
cd ..

exit
::×¢ÊÍ·û
