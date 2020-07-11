﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AdPopup : BasePopup
{
    [SerializeField] TextMeshProUGUI body;

    public override void Setup (BasePopup_Data popupData)
    {
        base.Setup(popupData);
        AdPopup_Data data = (AdPopup_Data)popupData ?? null;
        if(data!=null)
        {
            if(body != null)
                body.text = data.body;
        }
        Show();
    }

    public override void Close()
    {
        PopupManager.ClosePopup(this as BasePopup);
    }

    public override void Error()
    {
        throw new System.NotImplementedException();
    }
}
