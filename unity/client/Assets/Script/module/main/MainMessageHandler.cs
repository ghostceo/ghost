using UnityEngine;
using System.Collections;
/************************************************************************/
/* 这个是协议处理类,由于主场景等某些地方可能需要处理大量的协议,所以特别写了个处理协议的类,
 * 其它的模块如果能把协议写在数据逻辑上,可以写在一起*/
/************************************************************************/
public class MainMessageHandler : IMessageHandler
{
    private static MainMessageHandler instance;
    private MainMessageHandler()
    {

    }
    public static MainMessageHandler ins
    {
        get
        {
            if (instance == null)
                instance = new MainMessageHandler();
            return instance;
        }
    }
    /************************************************************************/
    /* 初始化协议监听                                                                     */
    /************************************************************************/
    public void Init()
    {
        GameNetManager.ins.AddMessageHandler(1, this);
    }

    /************************************************************************/
    /* 处理协议                                                                     */
    /************************************************************************/
    public void HandleMessage(IncommingBase message)
    {
        switch (message.protocol)
        {
            case 1 :

                break;
        }
    }
    public void SendSomeMessage()
    {

    }
}
