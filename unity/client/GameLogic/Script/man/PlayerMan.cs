using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerMan
{
    public static MyRole hero;
    public static p_role_info roleInfo;
    private static PlayerMan instance;
    private static Dictionary<float, Role> playerDic;
    private PlayerMan()
    {
        playerDic = new Dictionary<float, Role>();
    }
    public static PlayerMan ins
    {
        get
        {
            if (instance == null)
                instance = new PlayerMan();
            return instance;
        }
    }
    public void Update()
    {
        foreach (Role role in playerDic.Values)
        {
            role.Update();
        }
    }
    public void AddRole(Role role)
    {
        playerDic[role.ID] = role;
    }
    public void RemoveRole(float id)
    {

    }
    public void RemoveAll()
    {
        playerDic.Clear();
    }
}
