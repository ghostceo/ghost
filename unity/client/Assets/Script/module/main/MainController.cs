using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class MainController : MonoBehaviour
{
    //public GameObject uiRoot;
    //public GameObject SkillPanel;
    //public GameObject DungeonSelectPanel;
    public GameObject rolePanel;
    public GameObject roleTitle;

    private bool isShow = false;
    public Button[] menuBtns;
    private Dictionary<int, GameObject> panelData = new Dictionary<int, GameObject>();
    //public void OnDungeonClick()
    //{
    //   // GameObject go = new GameObject();
    //    //go.name = "DungeonSelectPanel";
    //    //DungeonSelectPanel.transform.parent = this.transform.root.transform;
    //    //DungeonSelectPanel = ResMan.GetPrefabs("ui/dungeonFrame") as GameObject;
    //    //DungeonSelectPanel.SetActive(false);
    //    GameObject go = NGUITools.AddChild(uiRoot, DungeonSelectPanel);
    //    go.name = "DungeonEnter";
    //    go.transform.localPosition = Vector3.zero;
    //}
    public void OnDungeonClick()
    {
        Application.LoadLevel("dungeon");

    }
    public void OnMenuClick()
    {
        isShow = !isShow;
        foreach (Button btn in menuBtns)
        {
            btn.gameObject.SetActive(isShow);
        }
    }
    public void CloseAllMenuBtn()
    {
        foreach (Button btn in menuBtns)
        {
            btn.gameObject.SetActive(false);
        }
        isShow = false;
    }
    //public void OnSkillClick()
    //{
    //    CloseAllMenuBtn();
    //    //GameObject skillPanel = GameObject.Find("SkillCombinePanel");
    //    if (SkillPanel != null)
    //    {
    //        SkillPanel.gameObject.SetActive(true);
    //        //Destroy(skillPanel.gameObject);
    //    }
    //    //GameObject go = NGUITools.AddChild(uiRoot, SkillPanel);
    //    //go.name = "SkillCombinePanel";
    //    //go.transform.localPosition = Vector3.zero;
    //}
    //public void LoadSkillsFromPlayerPrefs()
    //{
    //    int career = Common.career;
    //    SkillMan.ReadSkill(career);
    //    string[] keys = new string[4] { "H", "U", "I", "O" };
    //    string playerKeys = Common.NewUserName + "UserUsingSkills";
    //    int[] skillIDs = new int[8]{0,0,0,0,0,0,0,0};
    //    string FskillIDs = PlayerPrefs.GetString(playerKeys , "");
    //    if (FskillIDs == "")
    //    {
    //        return;
    //    }
    //    string[] SskillIDs = FskillIDs.Split(',');
    //    for (int i = 0; i < SskillIDs.Length; i++)
    //    {
    //        skillIDs[i] = Utility.ParseInt(SskillIDs[i]);
    //    }
    //    if(!SkillMan.userDefineSkill.ContainsKey(career))
    //    {
    //        SkillMan.userDefineSkill[career] = new Dictionary<string,int>();
    //    }
    //    Dictionary<string , int> userDefine = SkillMan.userDefineSkill[career];
    //    for (int i = 0; i < skillIDs.Length; i += 2)
    //    {
    //        if (skillIDs[i] != 0)
    //        {
    //            string key = keys[i / 2];
    //            userDefine[key] = skillIDs[i];

    //            if (skillIDs[i + 1] != 0)
    //            {
    //                SkillInfo skillInfo = SkillMan.skillDic[career][skillIDs[i]];
    //                while (skillInfo.autoNext != 0)
    //                {
    //                    skillInfo = SkillMan.skillDic[career][skillInfo.nextSkill];
    //                }
    //                skillInfo.nextSkill = skillIDs[i+1];
    //            }
    //        }
    //    }
    //}
    public void OnTestMenuButtonClick()
    {
        GameObject go = GameObject.Find("testPrefab");
        Vector3 vc = go.transform.position + new Vector3(0, 100, 0);
        iTween.MoveTo(go, vc, 1);
    }
    //角色界面
    public void OnMyRolePanelButtonClick()
    {
//       rolePanel.transform.localPosition = Vector3.zero;
//        rolePanel.SetActive(true);

        //int MyPanel = (int)PanelName.MyRolePanel;
        //if (!panelData.ContainsKey(MyPanel))
        //{

        //    CreatePanel(MyPanel, rolePanel);
        //}
        //else
        //{
        //    panelData[MyPanel].SetActive(true);
        //}
    }
    void CreatePanel(int name, GameObject obj)
    {
        GameObject o = Instantiate(obj) as GameObject;
        o.transform.SetParent(this.transform.root.transform);
        o.transform.localPosition = Vector3.zero;
        panelData.Add(name, o);
    }
    void Start()
    {
        //LoadSkillsFromPlayerPrefs();
        MainDataLogic.ins.Init();

        int roleTle = (int)PanelName.roleTitle;
        if (!panelData.ContainsKey(roleTle))
        {

            CreatePanel(roleTle, roleTitle);
            panelData[roleTle].transform.position = new Vector3(0,Screen.height,0);
        }
        else
        {
            panelData[roleTle].SetActive(true);
        }
    }
}

enum PanelName
{
    myRolePanel,
    roleTitle
}