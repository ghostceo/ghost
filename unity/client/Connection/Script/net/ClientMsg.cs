using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

using System.Collections;
using System.Net;
using System.Net.Sockets;
using System.Xml;
using System.IO;
public class ClientMsg
{

    private static ClientMsg _instance = null;
    public static ClientMsg getInstance()
    {
        if (_instance == null)
            _instance = new ClientMsg();
        return _instance;
    }

    /// <summary>
    /// erlang的服务器消息
    /// <summary>
    public Dictionary<int, MsgHandlerDelegate> msgMap = new Dictionary<int, MsgHandlerDelegate>();

    private ClientMsg()
    {

        //network msg hander register
        this.registeMsgHander();
    }
    ///// <summary>
    ///// 
    ///// </summary>
    ///// <param name="mp"></param>
    //void onU401(MsgPacket mp)
    //{
    //    U401 u = new U401();
    //    u.fill(mp);
    //    GameMain.Debug("@@onU401u.role_name= " + u.role_name);
    //}
    ///// <summary>
    ///// ping网络时间
    ///// </summary>
    ///// <param name="mp"></param>
    //void onU9911(MsgPacket mp)
    //{
    //    //     GameMain .Debug("网络延时onU9911");
    //    U9911 u = new U9911();
    //    u.fill(mp);
    //}
   
    ///// <summary>
    ///// 角色登录
    ///// <summary>
    //void onU10000(MsgPacket mp)
    //{
    //    GameMain.Debug("onU10000");

    //    U10000 u = new U10000();
    //    u.fill(mp);
    //    GameMain_Time.updateServerTicket(u.serverTime);
    //    GameMain.Debug("世界时：" + GameMain_Time.ToString((int)GameMain_Time.clientTicket) + "@时间：" + u.serverTime);
    //    switch (u.code)
    //    {
    //        case 0:	// 正常登录.
    //            {
    //                if (!NetWork.isRepeatConnect)
    //                {
    //                    GameMain.Debug("正常登录 send P10002!!");
    //                //    new P10002().send();
    //                    Application.LoadLevel("GameLoading");
    //                }
    //                else
    //                {
    //                    NetWork.isRepeatConnect = false;
    //                    GameMain.Debug("重新连接登录！！");
    //                }
    //            }
    //            break;
    //        case 1:	// 首次登录.
    //            {
    //                GameMain.Debug("首次登录!!");
    //            }
    //            break;
    //        case 2:	// 登录失败.
    //            GameMain.Debug("登录失败!!");
    //            break;
    //        case 3:	// 账号已在其他地方登录.
    //            GameMain.Debug("账号已在其他地方登录!!");
    //            break;

    //        case 4:
    //            GameMain.Debug("密码错误!!");
    //            break;
    //    }
    //}
    public void registeMsgHander()
    {
        //this.msgMap[9911] = onU9911;
        //this.msgMap[401] = onU401;
        ////
        //this.msgMap[10000] = onU10000;
    }
}
