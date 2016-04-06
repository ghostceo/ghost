using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class ChatConst
{
    public static string getChatType(int index)
    {
        switch (index)
        {
            case 0:
                return "channel_world";
            default:
                return "channel_world";
        }
    }

    public static string getWorldShow(string channel)
    {
        string show = "";
        if (channel == "channel_world")
        {
            show = "[世界]";
        }
        return show;
    }
}

