using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

[System.Serializable]
public abstract class BasePopup_Data
{
    [XmlAttribute("HeaderText")]
    [SerializeField]
    public string Header;

    [XmlAttribute("Type")]
    [SerializeField]
    public PopupLoader.PopupType popupType;
    
    [XmlAttribute("Width")]
    [SerializeField]
    public float windowWidth = 200;
    
    [XmlAttribute("Height")]
    [SerializeField]
    public float windowHeight = 200;

    public Vector2 WindowSize => new Vector2(windowWidth, windowHeight);

    public BasePopup_Data Data => this;

    public BasePopup_Data ()
    {
        Header = "";
        popupType = PopupLoader.PopupType.Ad;
    }
}
