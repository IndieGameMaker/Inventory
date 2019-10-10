using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private Transform inventoryTr;
    private Transform itemListTr;

    public static GameObject selectedItem = null;

    void Start()
    {
        inventoryTr = GameObject.Find("Inventory").transform;    
        itemListTr  = GameObject.Find("ItemList").transform;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        selectedItem = this.gameObject;
        GetComponent<CanvasGroup>().blocksRaycasts = false;

        transform.SetParent(inventoryTr);

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        selectedItem = null;
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        
        if (transform.parent == inventoryTr)
        {
            transform.SetParent(itemListTr);
        }
    }
}
