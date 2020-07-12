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

    List<MultiChoicePopup_Data> included;

    public MultiChoicePopup_Data Get()
    {
        if (included == null || included.Count < 1)
        {
            included = new List<MultiChoicePopup_Data>();
            foreach (MultiChoicePopup_Data pop in popups)
            {
                included.Add(pop);
            }
        }

        if (popups == null || popups.Length < 1)
            return null;
        int index = Random.Range(0, included.Count);
        MultiChoicePopup_Data popup = included[index];
        included.Remove(popup);
        return popup;
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
