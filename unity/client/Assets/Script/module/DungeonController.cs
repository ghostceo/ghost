using UnityEngine;
using System.Collections;

public class DungeonController : MonoBehaviour 
{
	// Use this for initialization
    private EasyButton[] btns = new EasyButton[5];
	void Start () 
    {
        DungeonDataLogic.ins.Init();
        //初始化角色;
        InitRole();
        //初始化控制
        InitControlJoyStick();
        //初始化地图
        InitMap();
        //装B专用
        InitFps();
        //Factory.CreateMyRole();
	}
	
	// Update is called once per frame
	void Update () 
    {
	}
    private void InitControlJoyStick()
    {
        GameObject joystick = new GameObject();
        joystick.name = "joystick";
        EasyJoystick joyStickScript = joystick.AddComponent<EasyJoystick>();
        joyStickScript.DynamicJoystick = true;
        for (int i = 0; i < 5; i++)
        {
            GameObject easyButton = new GameObject();
           
            EasyButton btnScript = easyButton.AddComponent<EasyButton>();
            btnScript.Scale = new Vector2(0.6f, 0.6f);
            if (i == 0)
            {
                easyButton.name = "attack";
            }
            else if (i < 3)
            {
                easyButton.name = "skill" + i;
                btnScript.Offset = new Vector2(-80f * i, 0);
            }
            else
            {
                easyButton.name = "skill" + i;
                btnScript.Offset = new Vector2(0, -80f * (i-2));
            }
            btnScript.showDebugArea = false;
            if (btnScript.NormalTexture == null)
            {
                btnScript.NormalTexture = ResMan.GetTexture("easy/Button_normal");
            }
            if (btnScript.ActiveTexture == null)
            {
                btnScript.ActiveTexture = ResMan.GetTexture("easy/Button_normal");
            }
            btns[i] = btnScript;
            //Debug.Log(btnScript.NormalTexture);
        }
    }
    private void InitRole()
    {
        MyRole myRole = new MyRole(Common.career);//PlayerMan.roleInfo.category
        KeyMan km = Camera.main.gameObject.GetComponent<KeyMan>();
        km.role = myRole;
        PlayerMan.hero = myRole;
        PlayerMan.ins.AddRole(myRole);
    }
    private void InitMap()
    {
        GameObject map = new GameObject();
        map.AddComponent<MapLayer>();
    }
    private void InitFps()
    {
        Camera.main.gameObject.AddComponent<Fps>();

    }
}
