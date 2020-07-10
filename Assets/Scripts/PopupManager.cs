using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PopupManager
{

    static List<BasePopup> popups;
    static int maxPopupsOnScreen = 10;
    static Queue<BasePopup> popupQueue = new Queue<BasePopup>();

    public static int Popups => popups.Count;

    static void AddPopup (BasePopup popup)
    {
        if (popups.Count >= maxPopupsOnScreen)
            popupQueue.Enqueue(popup);
        else
        {
            popups.Add(popup);
            popup.Show();
        }
    }


    public static void ClosePopup (BasePopup popup)
    {
        if (popups == null)
            return;

        if(popups.Contains(popup))
            popups.Remove(popup);

        if(popups.Count < maxPopupsOnScreen && popupQueue.Count > 0)
        {
            popups.Add(popup);
            popup.Show();
        }
    }


}
