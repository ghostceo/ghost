using UnityEngine;
using System.Collections;

public class myRolePanelDataLogic : IMessageHandler
{
    private static myRolePanelDataLogic instance;
    private GameObject myRolePanel;
 
    private myRolePanelDataLogic()
    {
      
    }
    public static myRolePanelDataLogic ins
    {
        get 
        {
            if (instance == null)
            {
                instance = new myRolePanelDataLogic();
            }
            return instance;
        }
    }
    public void Init(GameObject _createRoleObject)
    {
        myRolePanel = _createRoleObject;
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
        
    }
    public void HandleCreateRole(IncommingBase message)
    {

    }
}
