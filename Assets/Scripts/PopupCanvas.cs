using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[RequireComponent(typeof(Canvas))]
public class PopupCanvas : MonoBehaviour
{
    static Canvas canvas;
    static RectTransform rectTransform;

    public static Canvas Canvas => canvas;
    public static RectTransform RectTransform => rectTransform;

    private void Awake()
    {
        rectTransform = transform as RectTransform;
        canvas = this.GetComponent<Canvas>();
    }
}
