using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MyRolePanelController : MonoBehaviour
{
    public GameObject roleInfoView;
    public Button[] roles;
    private RoleInfoctrl _roleInfoScript;

 
    void Start()
    {
        _roleInfoScript = roleInfoView.GetComponent<RoleInfoctrl>();
        onClickToggBar();
    }

    public void closeRolePanel()
    {
        this.gameObject.SetActive(false);
    }
    public void onClickToggBar()
    {
        

    }
    //充值接口
    public void OnClickChongZhi()
    {

    }
    //更新角色信息
    public void onUpdateRoleInfo(IncommingBase message)
    {
        _roleInfoScript.updateInfo(message);
    }
}
