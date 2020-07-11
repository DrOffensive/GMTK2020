using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PopupLoader 
{



    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
    static void Initialize ()
    {

    }

    static void LoadPopupPrefabs ()
    {

    }

    static void LoadPopupData ()
    {

    }

    public enum PopupType
    {
        Ad, MultipleChoice, Catpcha
    }

    public static BasePopup RequestPopup (PopupType type)
    {
        return null;
    }
}
