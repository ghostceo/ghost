using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
public class UIDrag : MonoBehaviour , IDragHandler
{
    public void OnDrag(PointerEventData eventData)
    {
        this.transform.position = Input.mousePosition;
        //throw new System.NotImplementedException();
    }
}
