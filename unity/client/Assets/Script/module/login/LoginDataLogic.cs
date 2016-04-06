using UnityEngine;
using System.Collections;
/************************************************************************/
/* Login 的数据保存和逻辑代码编写的地方,建议使用单例类                                                                    */
/************************************************************************/
public class LoginDataLogic : IMessageHandler
{
    private GameObject loginObject;
    private static LoginDataLogic instance;
    private LoginDataLogic()
    {

    }
    public void Init(GameObject _loginObject)
    {
        loginObject = _loginObject;
        GameNetManager.ins.AddMessageHandler(Commands.ROLE_AUTH, this);
        GameNetManager.ins.AddMessageHandler(Commands.ROLE_CHOOSE, this);
    }

    //迟点移动dataLogic那边
    public void HandleMessage(IncommingBase message)
    {
        switch (message.protocol)
        {
            case Commands.ROLE_AUTH:
                HandleLogin(message);
                break;
            case Commands.ROLE_CHOOSE:
                HandleChooseRole(message);
                break;
        }
    }
    public void HandleLogin(IncommingBase message)
    {
        m_role_auth_toc rac = message as m_role_auth_toc;
        if (rac.err_code == 0)
        {
            
        }
        if (rac.role_infos.Count > 0)
        {
            //进入游戏
            p_role_info roleInfo = (p_role_info)rac.role_infos[0];
            PlayerMan.roleInfo = roleInfo;
            Application.LoadLevel("main");
        }
        else
        {
            Application.LoadLevel("createRole");
        }
        //GameObject go = GameObject.Find("loginForm");
        //if (go != null)
        //{
        //    UITweener tw = go.GetComponent<UITweener>();
        //    tw.PlayForward();
        //}
    }
    public void HandleChooseRole(IncommingBase message)
    {
        m_role_choose_toc chooseToc = message as m_role_choose_toc;
        if (chooseToc.succ)
        {
            SendEnterMap(chooseToc.role_details);
            Application.LoadLevel("main");
        }
    }
    public static LoginDataLogic ins
    {
        get
        {
            if (instance == null)
            {
                instance = new LoginDataLogic();
            }
            return instance;
        }
    }


    public void SendLoginMessage(string userName , string clientVersion , string key , string loginPlatform , int osType)
    {
        m_role_auth_tos ras = new m_role_auth_tos();
        ras.account_name = userName;
        ras.client_version = clientVersion;
        ras.key = key;
        ras.login_platform = loginPlatform;
        ras.os_type = osType;
        GameNetManager.ins.SendMessage(ras);
    }
    public void SendEnterMap(p_role roleInfo)
    {
        m_map_enter_tos tos = new m_map_enter_tos();
        tos.map_id = roleInfo.role_pos.map_id;
        GameNetManager.ins.SendMessage(tos);

    }
}
