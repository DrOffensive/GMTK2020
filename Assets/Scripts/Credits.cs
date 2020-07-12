using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Credits : MonoBehaviour, IPointerDownHandler
{

    RectTransform rectTransform => transform as RectTransform;
    [SerializeField] IntroScreenButton creditsButton;
    bool open = false;
    [SerializeField] float animationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        creditsButton.ClickAction = Open;
    }

    IEnumerator OpenCloseAnimation (float time)
    {
        float t = 0;
        rectTransform.localScale = Vector3.one * (open ? 1 : 0);
        while(t < time)
        {
            t += Time.deltaTime;
            float p = 1f / time * t;
            rectTransform.localScale = Vector3.one * (open ? 1f-p : p);
            yield return new WaitForEndOfFrame();
        }
        rectTransform.localScale = Vector3.one * (open ? 0 : 1);
        open = !open;
    }

    void Open ()
    {
        if (!open)
        {
            StartCoroutine(OpenCloseAnimation(animationSpeed));
        }
    }

    void Close ()
    {
        if (open)
        {
            StartCoroutine(OpenCloseAnimation(animationSpeed));
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Close();
    }
}
