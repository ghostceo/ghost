 using UnityEngine;
 using System;
 using System.Collections;
 using System.Collections.Generic;   
 using System.IO;   
 using System.Text;  
 using LSocket.Net;
 using LSocket.Type;
 using LSocket.cmd;
 using LSocket.Test;
 using LSocket.Common;

    public class SocketDemo : MonoBehaviour
    {
        public UnitySocket[] socket;
        public String[] textAreaString;
        public String[] textFieldString;
        public GUISkin mySkin;
        // Use this for initialization
        void Start()
        {
            socket = new UnitySocket[4];
            textAreaString = new String[12];
            for (int i = 0; i < 12; i++)
            {
                textAreaString[i] = " ";
            }
            textFieldString = new String[4];
            for(int i=0;i<4;i++){
                textFieldString[i] = " ";
            }
        }

        // Update is called once per frame
        void Update()
        {

        }

        void OnGUI()
        {
            GUI.skin = mySkin;
            for (int i = 0; i < 2; i++)
            {
                //String s = textAreaString[i * 3] + "\n" + textAreaString[i * 3 + 1] + "\n" + textAreaString[i * 3 + 2];
                //GUI.TextArea(new Rect(i % 2 * Screen.width / 2, i / 2 * (Screen.height / 2) + 50, 100, 60), s);
                textFieldString[i] = GUI.TextField(new Rect(i % 2 * Screen.width / 2+100, i / 2 * (Screen.height / 2), 100, 80), textFieldString[i]);
                if (GUI.Button(new Rect(i % 2 * Screen.width / 2, i / 2 * (Screen.height / 2), 100, 80), "连接"))
                {
                    socket[i] = null;
                    socket[i] = new UnitySocket();
                    // socket[i].SocketConnection("172.22.254.67", 443, this, i);
                    socket[i].SocketConnection("192.168.253.100", 2345, this, i);
                    // socket[i].DoLogin(textFieldString[i]);
                }
                else if (GUI.Button(new Rect(i % 2 * Screen.width / 2, i / 2 *( Screen.height / 2) + 85, 100, 80), "关闭"))
                {
                    if (socket[i] != null)
                    {
                        socket[i].close();
                        socket[i] = null;
                    }
                }
            }
        if (GUI.Button(new Rect(Screen.width - 60, Screen.height - 240, 60, 60), "协议")) {
            socket[1].DoBin();
            Debug.Log("haha");
            }
		if (GUI.Button(new Rect(Screen.width - 60, Screen.height - 120, 60, 60), "测试")) {
			// char cha;
			// string path = @"D:\123.txt";   
			// FileStream fs = new FileStream(path, FileMode.Open,FileAccess.Read);   
			// BinaryReader br = new BinaryReader(fs);
			// Debug.Log(br);
			// cha = br.ReadChar(); 
			// Debug.Log(cha);
			socket[1].DoTest();
            //byte[] input = new byte[512];
            // input = [1,2,194,75,202,131,104,2,100,0,22,109,95,109,111,110,101,121,95,116,114,101,101,95,102,101,116,99,104,95,116,111,115,98,0,0,0,1]
			//Debug.Log(input);
            Debug.Log("haha");
			}
		if (GUI.Button (new Rect (Screen.width - 60, Screen.height - 180, 60, 60), "数据")) {
            Debug.Log("click here");
			// ByteBuffer buf = ByteBuffer.Allocate(10);
			// buf.WriteInt(101);
			// buf.WriteShort(1000);
   //          Debug.Log(buf.ReadInt());
   //          Debug.Log(buf.ReadByte());
   //          Debug.Log(buf.ReadShort());

            Vector3 vr = new Vector3(1,0,0);  
            Quaternion q1 = Quaternion.LookRotation(vr);  
            Debug.Log(q1);
            Vector3 vforwardp = new Vector3(0,0,1);       
            Quaternion q2 = Quaternion.FromToRotation(vforwardp ,vr);  
            Debug.Log(q2);

            Quaternion q3 = new Quaternion();
            q3.eulerAngles = new Vector3(10, 30, 20);
            Debug.Log(q3.eulerAngles);
            Quaternion qx3 = Quaternion.AngleAxis(10,Vector3.right);        
            Quaternion qy3 = Quaternion.AngleAxis(30,Vector3.up);
            Quaternion qz3 = Quaternion.AngleAxis(20,Vector3.forward);
            Quaternion qxyz3 = qz3*qy3*qx3;
            Debug.Log(qxyz3);
			}
		if (GUI.Button(new Rect(Screen.width - 60, Screen.height - 60, 60, 60), "退出")) {
                Application.Quit();
            }

        }
    }