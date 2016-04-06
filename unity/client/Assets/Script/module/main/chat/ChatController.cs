using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
public class ChatController : MonoBehaviour
{   
    private Transform root;
    private List<string> buttonName;
    public Text chatText;

    public GameObject chatPanelClass;
    private GameObject chatPanel;

    private int nowSelectChannel;
	// Use this for initialization
	void Start () {
        root = GameObject.Find("Canvas").transform;
        ChatDataLogic.ins.Init(this.gameObject);

        buttonName = new List<string>();
        buttonName.Add("chat/chatBtn");
        buttonName.Add("chat/fightBtn");
	}
	
	// Update is called once per frame
	void Update () {

	}

    public void chatTabChange(int value)
    {
        nowSelectChannel = value;
        if (buttonName != null)
        {
            GameObject button;
            for (var i = 0; i < buttonName.Count; i++)
            {
                button = root.Find(buttonName[i]).gameObject;
                if(button != null){
            
                }
                if (i == value)
                {
                    button.SetActive(true);
                    continue;
                }
                button.SetActive(false);
            }
        }
    }

    public void chatPanelOpen()
    {
        if (chatPanel == null)
        {
            chatPanel = Instantiate(chatPanelClass) as GameObject;
            chatPanel.transform.SetParent(this.transform.root.transform);
            chatPanel.transform.localPosition = Vector3.zero;
        }
        else
        {
            chatPanel.gameObject.SetActive(!chatPanel.gameObject.activeSelf);
        }
    }

    public void fightPanelOpen()
    {

    }

    public void setChatText(m_chat_in_channel_toc cict)
    {
        if (nowSelectChannel == 0)
        {
            chatText.text += "<color=#00ffff>" + ChatConst.getWorldShow(cict.channel_sign) + "</color>" + cict.role_info.rolename+"：" + cict.msg + "\n";
        }
        else
        {

        }
        
    }

}