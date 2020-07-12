using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragWindow : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] RectTransform windowBox;
    public bool draggable = true;
    bool drag = false;

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        { 
            BeginDrag();
            PopupCanvas.instance.Focus(windowBox);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
            drag = false;
    }


    Vector2 lastMouse;
    void LateUpdate ()
    {
        if(drag && draggable)
        {
            Vector2 position = windowBox.position;
            Vector2 mouse = (Vector2)Input.mousePosition;
            Vector2 delta = mouse - lastMouse;
            lastMouse = mouse;
            windowBox.position = position + delta;
        }
    }

    void BeginDrag ()
    {
        lastMouse = Input.mousePosition;
        drag = true;
    }
}
