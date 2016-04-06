using UnityEngine;
using System.Collections;

public class CreateRoleDataLogic : IMessageHandler
{
    private static CreateRoleDataLogic instance;
    private GameObject createRoleObject;
    private CreateRoleDataLogic()
    {

    }
    public static CreateRoleDataLogic ins
    {
        get 
        {
            if (instance == null)
            {
                instance = new CreateRoleDataLogic();
            }
            return instance;
        }
    }
    public void Init(GameObject _createRoleObject)
    {
        createRoleObject = _createRoleObject;
        GameNetManager.ins.AddMessageHandler(Commands.ROLE_ADD, this);
    }

    public void HandleMessage(IncommingBase message)
    {
        switch (message.protocol)
        {
            case Commands.ROLE_ADD:
                HandleCreateRole(message);
                break;
        }
    }
    public void SendCreateRole(string roleName , int career)
    {
        m_role_add_tos mrat = new m_role_add_tos();
        mrat.role_name = roleName;
        mrat.sex = 0;
        mrat.category = career;
        mrat.faction_id = 0;
        mrat.hair_color = 0;
        mrat.hair_type = 0;
        mrat.head = 0;
        GameNetManager.ins.SendMessage(mrat);
    }
    public void HandleCreateRole(IncommingBase message)
    {
        m_role_add_toc addRoletoc = message as m_role_add_toc;
        if (addRoletoc.succ)
        {
            //m_role_choose_tos chooseRole = new m_role_choose_tos();
            //chooseRole.role_id = addRoletoc.role_id;
            //GameNetManager.ins.SendMessage(chooseRole);
        }
        else
        {
            createRoleObject.GetComponent<CreateRoleController>().SetErrorText(addRoletoc.reason);
            //提示玩家错误信息
        }
    }
}
