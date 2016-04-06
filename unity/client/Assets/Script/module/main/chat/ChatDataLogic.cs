using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ChatDataLogic : IMessageHandler
{

    private const int MESSAGE_MAX_COUNT = 100;

    public GameObject chatObject;
    public GameObject chatPanelObject;

    private Dictionary<string, List<m_chat_in_channel_toc>> _msgDic;

    private static ChatDataLogic instance;

    public static ChatDataLogic ins
    {
        get
        {
            if (instance == null)
            {
                instance = new ChatDataLogic();
            }
            return instance;
        }
    }

    public void Init(GameObject _chatObject)
    {
        chatObject = _chatObject;
        _msgDic = new Dictionary<string, List<m_chat_in_channel_toc>>();


        addMessagehandle();
    }
    
    public void InitPanel(GameObject _chatPanelObject)
    {
        chatPanelObject = _chatPanelObject;
    }

    //-------------------公共方法------------------
    public List<m_chat_in_channel_toc> getChatList(string channel)
    {
        if (_msgDic != null && _msgDic.ContainsKey(channel))
        {
            return _msgDic[channel];
        }
        return null;
    }

    //-------------------message--------------
    private void addMessagehandle()
    {
        GameNetManager.ins.AddMessageHandler(Commands.CHAT_IN_CHANNEL, this);
        GameNetManager.ins.AddMessageHandler(Commands.CHAT_IN_PAIRS, this);
    }

    public void HandleMessage(IncommingBase message)
    {
        switch (message.protocol)
        {
            case Commands.CHAT_IN_CHANNEL:
                HandleChat(message);
                break;
            case Commands.CHAT_IN_PAIRS:
                HandleChatPairs(message);
                break;
        }
    }

    //--------------send
    public void sendMsg(string msg,string channel)
    {
        m_chat_in_channel_tos cict = new m_chat_in_channel_tos();
        cict.channel_sign = channel;
        cict.msg = msg;
        GameNetManager.ins.SendMessage(cict);
    }

    //--------------handle
    //聊天返回
    public void HandleChat(IncommingBase message)
    {
        m_chat_in_channel_toc cict = message as m_chat_in_channel_toc;
        if(cict.succ){
            if (_msgDic.ContainsKey(cict.channel_sign) == false)
            {
                _msgDic[cict.channel_sign] = new List<m_chat_in_channel_toc>();
            }
            _msgDic[cict.channel_sign].Add(cict);

            if (_msgDic[cict.channel_sign].Count > MESSAGE_MAX_COUNT)
            {
                _msgDic[cict.channel_sign].RemoveAt(0);
            }

            if (chatObject != null)
            {
                chatObject.GetComponent<ChatController>().setChatText(cict);
            }

            if(chatPanelObject != null)
            {
                chatPanelObject.GetComponent<ChatPanelController>().setChatMsg(cict);
            }
        }
    }
    

    public void HandleChatPairs(IncommingBase message)
    {
        m_chat_in_pairs_toc cipt = message as m_chat_in_pairs_toc;



    }
}
