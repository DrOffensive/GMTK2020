using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

[System.Serializable]
public struct MinigamePopups
{
    [XmlArray("Popups")]
    [SerializeField]
    public MinigamePopup_Data[] popups;

    public MinigamePopup_Data Get()
    {
        if (popups == null || popups.Length < 1)
            return null;
        int index = Random.Range(0, popups.Length);
        return popups[index];
    }
}

[System.Serializable]
public class MinigamePopup_Data : BasePopup_Data
{
    [XmlAttribute("Minigame")]
    [SerializeField]
    public string minigame;

    public MinigamePopup_Data()
    {
        Header = "";
        minigame = "";
    }

    public MinigamePopup_Data(string header, string body, string minigameName)
    {
        this.Header = header;
        this.minigame = minigameName;
    }
    public MinigamePopup_Data(string fill)
    {
        this.Header = fill;
        this.minigame = fill;
    }
}