using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ChatPanelController : MonoBehaviour
{

    public Button sendBtn;
    public Button close;
    public Text contentText;
    public InputField messageInput;

    private string nowSelectChannel;
	// Use this for initialization
	void Start () {
        //chatTab.image
        ChatDataLogic.ins.InitPanel(this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    public void messageTabChange(int value)
    {
        nowSelectChannel = ChatConst.getChatType(value);

        showChatMsg();
    }

    public void closePanel()
    {
        this.gameObject.SetActive(false);
    }

    public void sendChatMassage()
    {
        string massage = messageInput.text;
        ChatDataLogic.ins.sendMsg(massage,nowSelectChannel);                                       
    }

    //--------------逻辑-----------
    public void setChatMsg(m_chat_in_channel_toc cict)
    {
        contentText.text += cict.role_info.rolename + "：" + cict.msg + "\n";
    }

    private void showChatMsg()
    {
        List<m_chat_in_channel_toc> showMsgList = ChatDataLogic.ins.getChatList(nowSelectChannel);
        if(showMsgList != null){
            string showMsg = ""; 
            for (int i = 0; i < showMsgList.Count;i++ )
            {
                showMsg += showMsgList[i].role_info.rolename + "："  +showMsgList[i].msg + "\n";
            }
            contentText.text = showMsg;
        }
    }
}
