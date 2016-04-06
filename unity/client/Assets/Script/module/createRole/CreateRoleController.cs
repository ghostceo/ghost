using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CreateRoleController : MonoBehaviour 
{
    //public Toggle fashi;
    //public Toggle jianshi;
    //public Toggle quanshou;
    public Toggle[] roles;
    public Text nameLabel;
    public Text errorText;
    public void OnEnterMainScene()
    {
        int career = 1;
        if (roles[0].isOn)
            career = 3;
        if (roles[1].isOn)
            career = 1;
        if (roles[2].isOn)
            career = 2;

        //Common.career = career;
        //PlayerPrefs.SetInt(Common.NewUserName, career);
        //PlayerPrefs.Save();
        //Application.LoadLevel("main");
        //新加的
        string userName = nameLabel.text;
        if (userName == "" || userName == null)
        {
            SetErrorText("用户名不能为空");
            return;
        }
        CreateRoleDataLogic.ins.SendCreateRole(userName, career);
    }
    public void SetErrorText(string error)
    {
        errorText.text = error;
        errorText.gameObject.SetActive(true);
        Invoke("HideErrorText", 2);
    }
    private void HideErrorText()
    {
        errorText.gameObject.SetActive(false);
    }
    void Start()
    {
        HideErrorText();
        CreateRoleDataLogic.ins.Init(this.gameObject);
        roles[Random.Range(0, roles.Length)].isOn = true;
    }

}
