using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DungeonInsideUIController : MonoBehaviour 
{
    public EasyButton[] btns;

	public void OnDungeonReturnBtn()
    {
        Application.LoadLevel("main");
    }

    void Awake()
    {
        //如果没有按键,就取消摇杆按钮的显示
        Dictionary<string, int> userDefine = new Dictionary<string, int>();// = SkillMan.userDefineSkill[Common.career];
        string[] keys = new string[4] { "H", "U", "I", "O" };
        for (int i = 0; i < keys.Length; i++)
        {
            if (userDefine.ContainsKey(keys[i]))
            {
                btns[i].gameObject.SetActive(true);
            }
            else
            {
                btns[i].gameObject.SetActive(false);
            }
        }
    }
}
