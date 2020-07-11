using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;


[System.Serializable]
public struct MultiChoicePopups
{
    [XmlArray("Popups")]
    [SerializeField]
    public MultiChoicePopup_Data[] popups;

    public MultiChoicePopup_Data Get()
    {
        if (popups == null || popups.Length < 1)
            return null;
        int index = Random.Range(0, popups.Length);
        return popups[index];
    }
}

[System.Serializable]
public class MultiChoicePopup_Data : BasePopup_Data
{
    [XmlAttribute("BodyText")]
    [SerializeField] 
    public string body;

    [XmlArray("Buttons")]
    [SerializeField] 
    public string[] buttons;

    [XmlAttribute("Answer")]
    [SerializeField]
    public int correctAnswer;
}
