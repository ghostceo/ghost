using UnityEngine;
using System.Collections;

public class MainDataLogic 
{
    private static MainDataLogic instance;
    public static MainDataLogic ins
    {
        get
        {
            if (instance == null)
            {
                instance = new MainDataLogic();
            }
            return instance;
        }
    }
    private MainDataLogic()
    {

    }
    public void Init()
    {
        MainMessageHandler.ins.Init();
    }
}
