using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class IntroScreenButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] TextMeshProUGUI topText;
    Vector2 topTextStart;
    [SerializeField] Color upColor, hoverColor, downColor;
    public System.Action ClickAction;

    public void OnPointerDown(PointerEventData eventData)
    {
        topText.color = downColor;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Hover = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Hover = false;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
            ClickAction?.Invoke();
    }

    bool Hover
    {
        set
        {
            (topText.transform as RectTransform).localPosition = value ? Vector2.zero : topTextStart;
            topText.color = value ? hoverColor : upColor;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        topTextStart = (topText.transform as RectTransform).localPosition;    
        
    }
}
