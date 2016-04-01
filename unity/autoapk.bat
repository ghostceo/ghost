@echo off
@set unity="F:\unity\Editor\Unity.exe"
echo auto generating APK...
%unity%  -batchmode -quit -nographics -executeMethod Batchmode.BuildAndroid  -logFile D:\Editor.log -projectPath "E:\room\atest" 
echo APK generated!
pause