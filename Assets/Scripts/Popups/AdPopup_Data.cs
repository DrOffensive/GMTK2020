using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

[System.Serializable]
public struct AdPopups
{
    [XmlArray("Popups")]
    [SerializeField]
    public AdPopup_Data[] popups;
}

[System.Serializable]
public struct AdPopup_Data 
{
    [XmlAttribute("HeaderText")]
    [SerializeField]
    public string header;
    [XmlAttribute("BodyText")]
    [SerializeField]
    public string body;
    [XmlAttribute("ImageName")]
    [SerializeField]
    public string imageName;
}
