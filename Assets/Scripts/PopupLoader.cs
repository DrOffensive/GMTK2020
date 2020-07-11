using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PopupLoader 
{
    const string AD_POPUP_PATH = "/PopupData/AdPopups.xml";
    const string MINIGAME_POPUP_PATH = "/PopupData/MinigamePopups.xml";
    const string MULTICHOICE_POPUP_PATH = "/PopupData/MultiChoicePopups.xml";
    static AdPopups adPopupData;
    static MinigamePopups minigamePopupData;
    static MultiChoicePopups multiChoicePopupData;

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
    static void Initialize ()
    {
        LoadPopupData();
        //Create(minigamePopupData.Get());
    }

    static void LoadPopupData ()
    {
        adPopupData = XMLLoader.LoadXML<AdPopups>(Application.dataPath + AD_POPUP_PATH);
        minigamePopupData = XMLLoader.LoadXML<MinigamePopups>(Application.dataPath + MINIGAME_POPUP_PATH);
        multiChoicePopupData = XMLLoader.LoadXML<MultiChoicePopups>(Application.dataPath + MULTICHOICE_POPUP_PATH);
    }

    public static BasePopup_Data CreateRandomPopup ()
    {
        int i = Random.Range(0, 3);
        switch (i)
        {
            case 0:
                return adPopupData.Get();
                
            case 1:
                return minigamePopupData.Get();

            case 2:
                return multiChoicePopupData.Get();

            default: return null;
        }
    }

    public static void Create(BasePopup_Data data)
    {
        switch (data.popupType) {
            case PopupType.Ad:
                UnityEngine.Object adprefab = Resources.Load("popups/AdPopup");
                BasePopup adinstance = (adprefab as GameObject).GetComponent<BasePopup>() ?? null;
                AdPopup adpopup = GameObject.Instantiate(adinstance, PopupCanvas.RectTransform) as AdPopup;
                adpopup.Setup(data);
                break;
            case PopupType.Minigame:
                UnityEngine.Object minigameprefab = Resources.Load("popups/MinigamePopup");
                BasePopup minigameinstance = (minigameprefab as GameObject).GetComponent<BasePopup>() ?? null;
                MinigamePopup minigamepopup = GameObject.Instantiate(minigameinstance, PopupCanvas.RectTransform) as MinigamePopup;
                minigamepopup.Setup(data);
                break;
            case PopupType.MultipleChoice:
                UnityEngine.Object multiChoiceprefab = Resources.Load("popups/MultiChoicePopup");
                BasePopup multiChoiceinstance = (multiChoiceprefab as GameObject).GetComponent<BasePopup>() ?? null;
                MultiChoicePopup multiChoicepopup = GameObject.Instantiate(multiChoiceinstance, PopupCanvas.RectTransform) as MultiChoicePopup;
                multiChoicepopup.Setup(data);
                break;
        }
    }

    public enum PopupType
    {
        Ad, MultipleChoice, Minigame
    }

    public static BasePopup_Data RequestPopup (PopupType type)
    {
        return null;
    }
}
