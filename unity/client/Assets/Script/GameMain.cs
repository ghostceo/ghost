using UnityEngine;
using System.Collections;
using System;

public class GameMain : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //SceneManager.ins.SwitchScene("dungeon");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void Awake()
    {
        GameObject heart = new GameObject();
        heart.AddComponent<HeartMan>();
        heart.name = "HeartMan";
        DontDestroyOnLoad(heart);
        Camera.main.orthographicSize = Screen.height / 200f;
        Application.targetFrameRate = 60;
    }
}
