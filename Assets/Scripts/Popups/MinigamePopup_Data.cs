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

    List<MinigamePopup_Data> included;

    public MinigamePopup_Data Get()
    {
        if (included == null || included.Count < 1)
        {
            included = new List<MinigamePopup_Data>();
            foreach (MinigamePopup_Data pop in popups)
            {
                included.Add(pop);
            }
        }

        if (popups == null || popups.Length < 1)
            return null;
        int index = Random.Range(0, included.Count);
        MinigamePopup_Data popup = included[index];
        included.Remove(popup);
        return popup;
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

    public MinigamePopup_Data(string header, string body, string minigameName, Vector2 size)
    {
        this.Header = header;
        this.minigame = minigameName;
        this.windowHeight = size.y;
        this.windowWidth = size.x;
    }
    public MinigamePopup_Data(string fill)
    {
        this.Header = fill;
        this.minigame = fill;
    }
}