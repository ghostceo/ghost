using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LoginController : MonoBehaviour
{
    public Text userNameText;
    public InputField passWordText;
    public Toggle[] servers;
    private string userName;
    private string password;
    public Text errorText;
    public void OnLoginEnterClick(Button btn)
    {
        //LoginDataLogic.ins.SendLoginMessage("lideling3", "0.0.1", "aaa", "bbb", 3);

        userName = userNameText.text;
        if (userName == "")
        {
            SetErrorText("用户名不能为空");
            return;
        }
        password = passWordText.text;
        if (GameNetManager.ins.IsConnected == false)
        {
            string serverIP = "127.0.0.1";
            if (servers[0].isOn)
            {
                serverIP = "192.168.253.12";
            }
            else if (servers[1].isOn)
            {
                serverIP = "192.168.253.12";
            }
            else if (servers[2].isOn)
            {
                serverIP = "192.168.253.12";
            }
            if (!GameNetManager.ins.IsConnected)
            {
                GameNetManager.ins.Init(serverIP, 1443, OnConnected);
            }
        }
        //OnConnected();
        //userName = userNameText.text;
        //password = passWordText.text;
        //GameNetManager.ins.Init(serverIP, 443, OnConnected);
    }
    public void OnConnected(bool isConnected)//bool isConnected
    {
        if (isConnected)
        {
            string loginName = this.userName;
            string passw = this.password;
            LoginDataLogic.ins.SendLoginMessage(loginName, "0.0.1", passw, "uc", 3);
        }
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
    //public void OnFormBack(UIButton btn)
    //{
    //    GameObject go = GameObject.Find("loginForm");
    //    if (go != null)
    //    {
    //        UITweener tw = go.GetComponent<UITweener>();
    //        tw.PlayReverse();
    //    }
    //}
    //public void OnLoginClick(UILabel usernameLabel)
    //{
    //    //start check
    //    string username = usernameLabel.text;

    //    if (PlayerPrefs.HasKey(username))
    //    {
    //        Common.NewUserName = username;
    //        Common.career = PlayerPrefs.GetInt(username);
    //        Application.LoadLevel("main");
    //        //直接切换场景
    //    }
    //    else
    //    {
    //        Common.NewUserName = username;
    //        //Common.career = PlayerPrefs.GetInt(username);
    //        //加载选角
    //        Application.LoadLevel("chooseRole");
    //        //StartCoroutine(LoadScene());
    //    }
        
       
    //}
    //IEnumerator LoadScene()
    //{




    //    return null;
    //}
    void Start()
    {
        HideErrorText();
        //GameNetManager.ins.Init("172.22.254.199", 443);
        LoginDataLogic.ins.Init(this.gameObject);
    }
}
