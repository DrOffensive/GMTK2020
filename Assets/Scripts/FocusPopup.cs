using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FocusPopup : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] int numberOfParents = 1;

    public void OnPointerClick(PointerEventData eventData)
    {
        Transform parent = transform.parent;
        if(numberOfParents > 1)
        {
            for (int i = 1; i <= numberOfParents; i++)
            {
                Transform p = parent.parent;
                parent = p;
            }
        }
        if(eventData.button == PointerEventData.InputButton.Left)
            PopupCanvas.instance.Focus(parent);
    }
}
