using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EC
{
    public delegate void Fun(IECMessage param);
	//public static Dictionary<string,Fun> modDic = new Dictionary<string,Fun>();
	public static Hashtable msgHandler = new Hashtable();
	public EC()
	{
	}
	/**
	* 注册事件处理器 
	* @param msg 消息名,来自EventList
	* @param handler 对应的事件处理
	* @priority 事件的处理优先级，整数值越大，处理的优先级越高
	*/		
	public static void AddListener(string msg , Fun handler)
	{
		if(msgHandler[msg] == null)
		{
			msgHandler[msg] = new List<Fun>();
		}
		RemoveListener(msg, handler);
		(msgHandler[msg] as List<Fun>).Add(handler);
	}
	/**
	* 移除事件处理,
	* 如果handler为空,可以考虑把所有监听去掉,暂时不实现
	* @param msg
	* @param handler
	*/		
	public static void RemoveListener(string msg , Fun handler)
	{
		if(msgHandler[msg] != null)
		{
			List<Fun> msgHandlers = msgHandler[msg] as List<Fun>;
			foreach(Fun handlerFun in msgHandlers)
			{
				if(handlerFun == handler)
				{
					int index = msgHandlers.IndexOf(handlerFun);
					if(index != -1)
					{
						msgHandlers.RemoveAt(index);
					}
					break;
				}
			}
		}
	}
	public static void dispatch(string msg , IECMessage param = null)
	{
		if(msgHandler[msg] != null)
		{
			List<Fun> msgHandlers = (msgHandler[msg] as List<Fun>);
			//要考虑到在执行过程中整个数组被删的情况
			//msgHandlers.sortOn("priority", Array.NUMERIC);
			for(int i = msgHandlers.Count - 1; i >=0 ; i--)
			{
				Fun fun = msgHandlers[i];
				fun(param);//监听的方法暂时只支持1个参数
			}
		}
	}
}
