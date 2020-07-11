using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Minigame : MonoBehaviour
{
    protected BasePopup popup;


    public virtual void Initialize(BasePopup popup)
    {
        this.popup = popup;
    }
}
