using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
public class MainMenuContrl : MonoBehaviour
{

    //加号图片
    public Image myAddImg;
    bool isOpen;
    public Image icon;
    public List<Image> icons = new List<Image>();
    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < 16; i++)
        {
            Image img = Instantiate(icon) as Image;
            icons.Add(img);
            img.transform.SetParent(this.transform);
            img.transform.position = myAddImg.transform.position;
            img.transform.SetSiblingIndex(myAddImg.transform.GetSiblingIndex());
            img.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    void setvis(GameObject tmp)
    {
        tmp.SetActive(false);
    }
 
    public void onMainBtnClick()
    {
        if (isOpen)
        {
            iTween.RotateTo(myAddImg.gameObject, iTween.Hash("z", 0, "easeType", "linear", "time", 0.2));
            for (int i = 1; i < icons.Count; i++)
            {

                Image temp = icons[i];
                iTween.MoveTo(temp.gameObject, iTween.Hash("position", myAddImg.transform.position, "easeType", "easeOutBounce", "time", 0.5f, "onComplete", "setvis", "onCompleteTarget", gameObject, "oncompleteparams", temp.gameObject));

            }
        }
        else
        {
            iTween.RotateTo(myAddImg.gameObject, iTween.Hash("z", 135, "easeType", "linear", "time", 0.2));
            for (int i = 1; i < icons.Count; i++)
            {

                Image temp = icons[i];
                temp.gameObject.SetActive(true);
                int laddingX = 10;
                int laddingY = 10;

                int columnCount = 5;

                int rowIndex = i / columnCount;
                int columnIndex = i % columnCount;

                Vector3 vc = myAddImg.transform.position + new Vector3(-(columnIndex * 90 + columnIndex * laddingX), rowIndex * 90 + rowIndex * laddingY, 0);
                iTween.MoveTo(temp.gameObject, iTween.Hash("position", vc, "easeType", "easeOutBounce", "time", 0.5f));
            }

        }

        isOpen = !isOpen;
    }
}
