using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public static class PopupManager
{

    static List<BasePopup> popups;
    static int maxPopupsOnScreen = 20;
    static Queue<BasePopup_Data> popupQueue = new Queue<BasePopup_Data>();

    public static event System.Action<BasePopup> OnPopupCreated;
    public static int Popups => popups.Count;

    public static void AddPopup (BasePopup_Data popup)
    {
        if (popups == null)
            popups = new List<BasePopup>();

        if (popups.Count >= maxPopupsOnScreen)
            popupQueue.Enqueue(popup);
        else
        {
            PopupLoader.Create(popup);
        }
    }

    public static void AssignPopup (BasePopup popup)
    {
        if (popups == null)
            popups = new List<BasePopup>();

        popups.Add(popup);
        OnPopupCreated?.Invoke(popup);
    }

    public static void ClosePopup (BasePopup popup)
    {
        if (popups == null)
            return;

        if (popups.Contains(popup))
        {
            popups.Remove(popup);
            GameObject.Destroy(popup.gameObject);
        }
        if(popups.Count < maxPopupsOnScreen && popupQueue.Count > 0)
        {
            PopupLoader.Create(popupQueue.Dequeue());
            //popup.Show();
        }
    }


}
