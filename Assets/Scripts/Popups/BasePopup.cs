using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class BasePopup : MonoBehaviour
{
    protected RectTransform window => transform as RectTransform;
    [SerializeField] protected RectTransform topBar;
    [SerializeField] protected TextMeshProUGUI header;
    [SerializeField] protected Button closeButton;
    [SerializeField] public Severity severity { get; protected set; }

    public event Action OnShow;
    
    public bool HideCloseButton { set => closeButton.gameObject.SetActive(!value); }

    protected void Show ()
    {
        OnShow.Invoke();
    }

    public abstract void Error();
    public abstract void Close();

    public virtual void Setup (BasePopup_Data popupData)
    {
        window.sizeDelta = popupData.WindowSize;
        float x = UnityEngine.Random.Range(0, Screen.width - popupData.windowHeight/2);
        float y = UnityEngine.Random.Range(Screen.height / 2, Screen.height- popupData.windowHeight/2);
        OnShow += () => 
        {
            StartCoroutine(ShowAnimation(new Vector2(x, y), .25f));
        };
        window.position = new Vector2(x, 0);
        window.localScale = Vector3.one * 0f;
        PopupManager.AssignPopup(this);
        header.text = popupData.Header;

        if (closeButton != null)
            closeButton.onClick.AddListener(Close);
    }

    IEnumerator ShowAnimation(Vector2 targetPosition, float time)
    {
        Vector2 startPos = (Vector2)window.position;
        Vector2 line = targetPosition - startPos;
        float p = 1f / time;
        float t = 0;
        while (t < time)
        {
            t += Time.deltaTime;
            float percent = t * p;
            window.position = Vector2.Lerp(startPos, targetPosition, percent);
            window.localScale = Vector2.one * percent;
            yield return new WaitForEndOfFrame();
        }
        window.position = Vector2.Lerp(startPos, targetPosition, 1);
        window.localScale = Vector2.one;
    }

    public enum Severity
    {
        Casual, Important, Critical
    }
}