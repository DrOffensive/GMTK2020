﻿using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;


[System.Serializable]
public struct AdPopups
{
    [XmlArray("Popups")]
    [SerializeField]
    public AdPopup_Data[] popups;

    List<AdPopup_Data> included;

    public AdPopup_Data Get ()
    {
        if(included == null ||included.Count < 1)
        {
            included = new List<AdPopup_Data>();
            foreach(AdPopup_Data pop in popups)
            {
                included.Add(pop);
            }
        }

        if (popups == null || popups.Length < 1)
            return null;
        int index = Random.Range(0, included.Count);
        AdPopup_Data popup = included[index];
        included.Remove(popup);
        return popup;
    }
}

[System.Serializable]
public class AdPopup_Data : BasePopup_Data
{ 
    [XmlAttribute("BodyText")]
    [SerializeField]
    public string body;
    [XmlAttribute("ImageName")]
    [SerializeField]
    public string imageName;

    public AdPopup_Data()
    {
        Header = "";
        body = "";
        imageName = "";
    }

    public AdPopup_Data(string header, string body, string imageName)
    {
        this.Header = header;
        this.body = body;
        this.imageName = imageName;
    }
    public AdPopup_Data(string header, string body, string imageName, Vector2 size)
    {
        this.Header = header;
        this.body = body;
        this.imageName = imageName;
        this.windowWidth = size.x;
        this.windowHeight = size.y;
    }

    public AdPopup_Data(string fill)
    {
        this.Header = fill;
        this.body = fill;
        this.imageName = fill;
    }
}
