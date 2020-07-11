using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PopupLoader 
{
    const string AD_POPUP_PATH = "/PopupData/AdPopups.xml";
    static AdPopups adPopupData;
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
    static void Initialize ()
    {
        LoadPopupData();
        Create(adPopupData.Get());
    }

    static void LoadPopupData ()
    {
        adPopupData = XMLLoader.LoadXML<AdPopups>(Application.dataPath + AD_POPUP_PATH);
    }


    public static void Create(BasePopup_Data data)
    {
        switch (data.popupType) {
            case PopupType.Ad:
                UnityEngine.Object prefab = Resources.Load("popups/AdPopup");
                BasePopup instance = (prefab as GameObject).GetComponent<BasePopup>() ?? null;
                AdPopup popup = GameObject.Instantiate(instance, PopupCanvas.RectTransform) as AdPopup;
                popup.Setup(data);
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
