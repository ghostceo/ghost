using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Linq;
using System.Text;
public class NetWork : MonoBehaviour
{
    #region 变量
    public static NetWork mNetWork;
    public static string server_host;
    public static string account="F1";
    public static string passwd="88";
    public static bool needConnect = false;
    public static string sdk_account = "";
    public static string sdk_id = "";
    public static bool isRun = true;
    public static bool isRepuestPortRun = true;
    public static string IP_URL;
    public static int remote_port;
    public static int serverId;
    public static bool isRepeatConnect=false ;
    private int ConnectNumber = 0;
   
    #endregion

    void Awake()
    {
        mNetWork = this;
    }
    // Use this for initialization
    void Start()
    {
        ReadIpAddress();   
    }
    /// <summary>
    /// 
    /// </summary>
     public static string _UpdateDataFilesPath=
#if UNITY_ANDROID
            Application.persistentDataPath + "/DataFile/";
#elif UNITY_IPHONE
            StringDefine.IOS_AssetBundlesPath + "Library/Caches/DataFile/";
#elif UNITY_STANDALONE_OSX
          Application.dataPath + "/StreamingAssets/DataFile/";
#elif UNITY_STANDALONE_WIN || UNITY_EDITOR
         Application.dataPath + "/StreamingAssets/DataFile/";
#else
 string.Empty;
#endif
    void ReadIpAddress()
    {

//        string filePath;
//#if UNITY_IPHONE
//        filePath = StringDefine.IOS_AssetBundlesPath + "Library/Caches/DataFiles/" + "IP.xml";
//#elif UNITY_ANDROID
//        filePath = StringDefine._UpdateDataFilesPath + "IP.xml";
//#else
//        filePath = _UpdateDataFilesPath + "IP.xml";
//#endif
        //if (File.Exists(filePath))
        //{
        //    ReadXmlFile readXmlFile = new ReadXmlFile();
        //    // 加载办法一
        //    readXmlFile.Load(filePath);
        //    NetWork.IP_URL = readXmlFile.ReadString("IP", "IP_URL");
        //    NetWork.remote_port = readXmlFile.ReadInt("IP", "PORT");
        //    NetWork.serverId = readXmlFile.ReadInt("IP", "serverId");
        //}
        //else
        //{
        //    NetWork.IP_URL = "172.22.254.195";
        //    NetWork.remote_port = 443;
        //    NetWork.serverId = 0;
        //    WriteXmlFile writeXmlFile = new WriteXmlFile(filePath);
        //    // 写入数据
        //    writeXmlFile.WriteString("IP", "IP_URL", IP_URL);
        //    writeXmlFile.WriteInt("IP", "PORT", remote_port);
        //    writeXmlFile.WriteInt("IP", "serverId", serverId);
        //    // 保存
        //    writeXmlFile.Save();
        //}
        needConnect = true;
        StartCoroutine("action");
       
    }

    // Update is called once per frame
    void Update()
    {
        // 重连
        //if (ClientControl.getInstance().iFDisconnect)
        //{
        //    Net_RepeatConnect();
        //    ClientControl.getInstance().iFDisconnect = false;
        //}
        
    }

    public static NetWork getInstance()
    {
        return mNetWork;
    }
    void OnDisable()
    {
    }
    void OnDestroy()
    {
        isRun = false;
        StopAllCoroutines();
        if (ClientControl.getInstance().isConnect)
            ClientControl.getInstance().OnDisconnect(ClientControl.getInstance().sock);
    }
    /// <summary>
    /// 自动重连
    /// </summary>
    public void Net_RepeatConnect()
    {
        ConnectNumber++;
   //     ClientControl.getInstance().receiveQueue.Clear();
        if (ClientControl.getInstance().isConnect)
            ClientControl.getInstance().OnDisconnect(ClientControl.getInstance().sock);       
        ClientControl.getInstance().isConnect = false;
        StartCoroutine("RepeatConnect");
    }
    /// <summary>
    /// 从新登录
    /// </summary>
    public void InitNetWork()
    {
        ConnectNumber = 0;
        StopCoroutine("action");
        ClientControl.getInstance().receiveQueue.Clear();
        if (ClientControl.getInstance().isConnect)
            ClientControl.getInstance().OnDisconnect(ClientControl.getInstance().sock);
        ClientControl.getInstance().isConnect = false;        
        isRun = true;
        needConnect = true ;
        StartCoroutine("action");
    }
   
    /// <summary>
    /// 重连
    /// </summary>
    /// <returns></returns>
    IEnumerator RepeatConnect()
    {
        ClientControl.getInstance().processReceiveQueue();
        yield return 0;
        Debug.Log("@@@@重连@@@@@@@@@");
        yield return new WaitForSeconds(3.0f);
        if (!ClientControl.getInstance().isConnect)
        {
            ClientControl.getInstance().init();
            yield return new WaitForSeconds(0.5f);
        }
        if (ClientControl.getInstance().isConnect)
        { 
            Send_Load10000();           
            ConnectNumber = 0;
        }
    }
   /// <summary>
   /// 连接
   /// </summary>
   /// <returns></returns>
    IEnumerator action()
    {
        isRun = true;
        ClientControl.getInstance().receiveQueue.Clear();
        ClientControl.getInstance().iFDisconnect  = false;
        while (isRun)
        {
            ClientControl.getInstance().processReceiveQueue();

            yield return 0;

            if (needConnect)
            {
                needConnect = false;
                yield return new WaitForSeconds(3.0f);
                if (!ClientControl.getInstance().isConnect)
                {
                    ClientControl.getInstance().init();
                    yield return new WaitForSeconds(0.5f);
                }
                if (ClientControl.getInstance().isConnect)
                {
                    //GameMain.Debug("send p401!!!!!!!!!!!!!");
                    //P401 test = new P401();
                    //test.role_id = 1001;
                    //test.fill();
                    //test.send();
                    NetWork.isRepeatConnect = false;
                }
                needConnect = false;
            }
        }
    }
    
   
    /// <summary>
    /// 发送登录
    /// </summary>
    public void Send_Load10000()
    {
        if (ClientControl.getInstance().isConnect)
        {
//            GameMain.Debug("send p10000");
//            P10000 login_package = new P10000();
//            if (GameMain.mGame_Account == null)
//                login_package.account = account;
//            else
//                login_package.account = GameMain.mGame_Account;
//            if (GameMain.mGame_Password == null)
//                login_package.password = "800000";
//            else
//                login_package.password = GameMain.mGame_Password;
//            login_package.versions = 1001;
//            login_package.netType = 4;// 2G:1, wifi:2, 3G:3, 其他:4

//#if UNITY_IPHONE
//            login_package.channelCode = "appstore";
//#elif UNITY_ANDROID
//            login_package.channelCode = "android";
//#else
//            login_package.channelCode = "pc";
//#endif
//            login_package.phoneType = SystemInfo.deviceModel;
//            login_package.phoneSystem = SystemInfo.operatingSystem;
//            login_package.udid = SystemInfo.deviceUniqueIdentifier;
//            login_package.fill();
//            login_package.send();
        }
        else//重连
        {
            StartCoroutine("RepeatConnect");
        }
    }

    

}
