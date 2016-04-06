using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Collections;
public class  ListUtil
{
    /// <summary>
    /// 排序正序
    /// </summary>
    public static int CASEINSENSITIVE = 1;

    /// <summary>
    /// 排序倒序
    /// </summary>
    public static int DESCENDING = 2;

    /// <summary>
    /// 获取List中所有符合参数值得数列
    /// </summary>
    /// <param name="list">需要获取的List</param>
    /// <param name="name">属性名</param>
    /// <param name="value">属性值</param>
    /// <returns>属性列表</returns>
    public static IList listFind(IList list, string attributeName, object attributeValue)
    {
        if (list.Count > 0)
        {
            object proto = list[0];
            Type proteoType = proto.GetType();
            FieldInfo fieldInfo = proteoType.GetField(attributeName);  //获得属性
            if (fieldInfo != null)
            {
                Type listType = list.GetType();    //得到此类类型
                IList listObj = listType.Assembly.CreateInstance(listType.FullName) as IList;
                object nowProto;
                for (int i = 0; i < list.Count; i++)
                {
                    nowProto = list[i];
                    if (fieldInfo.GetValue(nowProto) == attributeValue)
                    {
                        listObj.Add(nowProto);
                    }
                }
                return listObj;
            }
        }
        return null;
    }

    /// <summary>
    /// 数组排序方法
    /// </summary>
    /// <param name="list">需要排序的数组</param>
    /// <param name="attributeName">需要排序的字段</param>
    /// <param name="sortType">排序类型 ListUtil.CASEINSENSITIVE 正序  ListUtil.DESCENDING 倒序</param>
    /// <returns>排序后列表</returns>
    public static IList listSort(IList list, string attributeName, int sortType=1)
    {
        if (list.Count > 0)
        {
            object proto = list[0];
            Type proteoType = proto.GetType();
            FieldInfo fieldInfo = proteoType.GetField(attributeName);  //获得属性
            if (fieldInfo != null)
            {
                Type listType = list.GetType();    //得到此类类型
                IList listObj = listType.Assembly.CreateInstance(listType.FullName) as IList;

                object nowProto;         //需要遍历的数组中的对象
                object nowInListProto;   //已经插入返回列表中的对象
                for (int i = 0; i < list.Count; i++)
                {
                    nowProto = list[i];
                    if(listObj.Count == 0){
                        listObj.Add(nowProto);
                        continue;
                    }

                    int insertIndex = -1;
                    for (int j = 0; j < listObj.Count; j++)
                    {
                        nowInListProto = listObj[j];
                        if (sortType == CASEINSENSITIVE)
                        {
                            if (float.Parse(fieldInfo.GetValue(nowProto).ToString()) <= 
                                float.Parse(fieldInfo.GetValue(nowInListProto).ToString ()))
                            {
                                insertIndex = j;
                                break;
                            }
                        }
                        else
                        {

                            if (float.Parse(fieldInfo.GetValue(nowProto).ToString()) > 
                                float.Parse(fieldInfo.GetValue(nowInListProto).ToString()))
                            {
                                insertIndex = j;
                                break;
                            }
                        }
                    }

                    if (insertIndex == -1)
                    {
                        listObj.Add(nowProto);
                    }
                    else
                    {
                        listObj.Insert(insertIndex, nowProto);
                    }
                }
                return listObj;
            }
        }
        return null;
    }
}



