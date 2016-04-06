using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RoleInfoctrl : MonoBehaviour
{
    //职业
	public Text zhiyeTxt;
    //等级
	public Text levelTxt;
    //称号
    public Text titleTxt;
    //工会
    public Text gonghuiTxt;
    //攻击
    public Text gongjiTxt;
    //力量
    public Text liliangTxt;
    //敏捷
    public Text minjieTxt;
    //物防
    public Text wufangTxt;
    //敏防
    public Text minfangTxt;
    //物防
    public Text wukangTxt;
    //敏抗
    public Text minkangTxt;
    //智力
    public Text zhiliTxt;
    //体质
    public Text tizhiTxt;
    //魔防
    public Text mofangTxt;
    //护甲
    public Text hujiaTxt;
    //魔抗
    public Text mokangTxt;
    //纸娃娃
	public Image roleImage;
    
    public Button[] items;
	
	void Start () {
 
	}
	
	void Update () {
	
	}

	public void updateInfo(IncommingBase message)
	{
        //m_role2_attr_change_toc data = message as m_role2_attr_change_toc;

        //myCategoryTxt.text = data.roleid.ToString();
        //myLevelTxt.text = data.roleid.ToString();
        //myGoldTxt.text = data.roleid.ToString();
        //mySilverTxt.text = data.roleid.ToString();
        //myExpBar.value = 0.5f;
        //Sprite newSprite = Resources.Load<GameObject>("ui/MyRolePanel/upwith_d2_1").GetComponent<SpriteRenderer>().sprite;
        //image.sprite = newSprite;
	}
}
