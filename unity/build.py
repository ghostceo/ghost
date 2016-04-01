#!/bin/sh

#参数判断  
if [ $# != 1 ];then  
    echo "需要一个参数。 参数是游戏包的名子"  
    exit     
fi  


#UNITY程序的路径#
UNITY_PATH=/Applications/Unity/Unity.app/Contents/MacOS/Unity

#游戏程序路径#
PROJECT_PATH=/Users/MOMO/commond

#在Unity中构建apk#
$UNITY_PATH -projectPath $PROJECT_PATH -executeMethod ProjectBuild.BuildForAndroid project-$1 -quit


echo "Apk生成完毕"