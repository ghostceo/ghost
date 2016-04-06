using UnityEngine;
using System.Collections;

public class EuipViewController : MonoBehaviour {

	public GameObject pot1;
	public int[] itemArr;
	public Transform EquipItems;
	// Use this for initialization
	void Start () {
		
//        createItem(); 
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void createItem()
	{
		int[] test1 = new int[] {1,2,3,4,5,6};
		//itemArr = new EquipItem[test1.Length];

		//for(int i=0;i<test1.Length;i++)
		//{
		//    itemArr[i] = CreatePot(pot1, test1[i]);
		//}

	}
	public void update()
	{
		int index = 1;

//        foreach (EquipItem item in itemArr)
//        {
//            if (item.index == index)
//            {
////                item.transform;
//            }
//        }
	}
	//EquipItem CreatePot(GameObject pot, int index)
	//{
	//    GameObject o = Instantiate(pot) as GameObject;
	//    o.transform.SetParent(EquipItems);
	//    EquipItem item = o.GetComponent<EquipItem>();
	//    item.index = index;
	//    return item;
	//}
}
