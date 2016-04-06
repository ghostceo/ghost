using UnityEngine;
using System.Collections;
using Engine;

public class HeartMan : MonoBehaviour 
{
    private static HeartMan instance;
    public static HeartMan ins
    {
        get
        {
            return instance;
        }
    }
	// Use this for initialization
	void Start () 
    {
	}
	
	// Update is called once per frame
	void Update ()
    {
        GameNetManager.ins.Update();
        //PlayerMan.ins.Update();
        //MonsterMan.ins.Update();
        //MagicMan.Update();
        //SkillMan.Update();
	}
    void Awake()
    {
        instance = this;
    }
}
