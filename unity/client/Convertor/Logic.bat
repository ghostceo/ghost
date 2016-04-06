::需要自已修改路径

::拷GameLogic
cd D:\WORK_SPACE\mobile\trunk\GameLogic\bin\Debug\
if exist "GameLogic.dll.mdb" (del GameLogic.dll.mdb)
echo 111
xcopy /s GameLogic.dll D:\WORK_SPACE\mobile\trunk\Assets\Plugins\ /y
D:\WORK_SPACE\mobile\trunk\Convertor\pdb2mdb.exe GameLogic.dll
xcopy /s "GameLogic.dll.mdb" D:\WORK_SPACE\mobile\trunk\Assets\Plugins\ /y
cd ..
cd ..



exit
::注释符

