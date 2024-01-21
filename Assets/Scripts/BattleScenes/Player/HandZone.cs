using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HandZone : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {

        Drag drag = eventData.pointerDrag.GetComponent<Drag>();

        if (drag != null)
        {
            drag.parentToReturnTo = this.transform;
            Debug.Log("Card added to hand.");
        }

    }
}