using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEditor;
using UnityEngine;

[ExecuteAlways]
public class CreateXMLTemplate : MonoBehaviour
{

    public enum TemplateToSave
    {
        Ad, Minigame, MultiChoice
    }

    public TemplateToSave templateToSave;
    public MinigamePopups minigamedata;
    public AdPopups adpopupdata;
    public MultiChoicePopups multichoicepopupdata;
    public string path;

    public bool create = false;
    
    // Update is called once per frame
    void Update()
    {
        if(create)
        {
            create = false;
            switch(templateToSave)
            {
                case TemplateToSave.Ad:
                    CreateAds();
                    break;
                case TemplateToSave.Minigame:
                    CreateMinigames();
                    break;
                case TemplateToSave.MultiChoice:
                    CreateMultiChoices();
                    break;
            }
        }
    }
    
    void CreateAds ()
    {
        XMLSaver.SaveXML(adpopupdata, path, "AdPopups");
        AssetDatabase.Refresh();
    }
    void CreateMinigames()
    {
        XMLSaver.SaveXML(minigamedata, path, "MinigamePopups");
        AssetDatabase.Refresh();
    }
    void CreateMultiChoices()
    {
        XMLSaver.SaveXML(multichoicepopupdata, path, "MultiChoicePopups");
        AssetDatabase.Refresh();
    }
}
