using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PopupLoader 
{
    const string AD_POPUP_PATH = "/PopupData/AdPopups.xml";
    const string MINIGAME_POPUP_PATH = "/PopupData/MinigamePopups.xml";
    static AdPopups adPopupData;
    static MinigamePopups minigamePopupData;

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
    }

    public static BasePopup_Data CreateRandomPopup ()
    {
        int i = Random.Range(0, 2);
        switch (i)
        {
            case 0:
                return adPopupData.Get();
                
            case 1:
                return minigamePopupData.Get();

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
