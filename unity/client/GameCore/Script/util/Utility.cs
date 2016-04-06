using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Utility 
{
    public static int ParseInt(string s)
    {
        if (s == null || s == "")
            return 0;
        return int.Parse(s);
    }
    public static int ParseInt(System.Object s)
    {
        return Convert.ToInt32(s);
    }
    public static float ParseFloat(string s)
    {
        if (s == null || s == "")
            return 0f;
        return float.Parse(s);
    }
    public static int[] TransStringArr(string[] str)
    {
        int[] arr = new int[str.Length];
        for (int i = 0; i < str.Length; i++)
        {
            arr[i] = int.Parse(str[i]);
        }
        return arr;
    }
    public static List<int> TransStringArray(string[] str)
    {
        List<int> temp = new List<int>();
        for (int i = 0; i < str.Length; i++)
        {
            temp.Add(ParseInt(str[i]));
        }
        return temp;
    }
    public static int calcFaceDirectionByPos(float x1 , float x2)
	{
		return x1 > x2 ? 1 : -1;
	}
}
