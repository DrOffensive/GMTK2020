using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class BasePopup : MonoBehaviour
{
    [SerializeField] protected RectTransform topBar;
    [SerializeField] protected TextMeshProUGUI header;
    [SerializeField] public Severity severity { get; protected set; }

    public event Action OnShow;
    
    public abstract void Error();
    public abstract void Close();

    public virtual void Setup (BasePopup_Data popupData)
    {
        header.text = popupData.Header;
    }



    public enum Severity
    {
        Casual, Important, Critical
    }
}