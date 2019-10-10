using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drop : MonoBehaviour, IDropHandler
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (this.transform.childCount == 0)
        {
            Drag.selectedItem.transform.SetParent(transform);
        }
    }
}
