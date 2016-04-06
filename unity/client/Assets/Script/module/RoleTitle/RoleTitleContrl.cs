using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RoleTitleContrl : MonoBehaviour
{
    //头像
    public Image roleImage;
    //战斗力文本
    public Text powerTxt;
    //名字文本
    public Text nameTxt;
    //元宝文本
    public Text goldTxt;
    //金钱文本
    public Text silverTxt;
    //等级文本
    public Text levelTxt;
    //邮件按钮
    public Button mailButton;
    //VIP按钮
    public Button vipButton;
    //充值按钮
    public Button chongZhiButton;

    // Use this for initialization
    void Start()
    {
        //添加按钮点击事件
        EventTriggerListener.Get(roleImage.gameObject).onClick = OnButtonClick;
        EventTriggerListener.Get(mailButton.gameObject).onClick = OnButtonClick;
        EventTriggerListener.Get(chongZhiButton.gameObject).onClick = OnButtonClick;
        EventTriggerListener.Get(chongZhiButton.gameObject).onClick = OnButtonClick;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnButtonClick(GameObject go)
    {
        if (go == roleImage.gameObject)
        {
            Debug.Log("MyRoleTitleImage Click");
        }
        else if (go == mailButton.gameObject)
        {
            Debug.Log("mailButton Click");
        }
        else if (go == chongZhiButton.gameObject)
        {
            Debug.Log("chongZhiButton Click");
        }
        else if (go == vipButton.gameObject)
        {
            Debug.Log("chongZhiButton Click");
        }
    }

    public void updateInfo()
    {
        //加载头像
        //      Sprite newSprite = Resources.Load<GameObject>("ui/MyRolePanel/upwith_d2_1").GetComponent<SpriteRenderer>().sprite;
        //      roleImage.sprite = newSprite;
    }
}
