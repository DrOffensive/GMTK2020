using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Security.Cryptography;

public class AdPopup : BasePopup
{
    [SerializeField] TextMeshProUGUI body;
    [SerializeField] Image adImage;
    public override void Setup (BasePopup_Data popupData)
    {
        base.Setup(popupData);
        AdPopup_Data data = (AdPopup_Data)popupData ?? null;
        if(data!=null)
        {
            if(body != null)
                body.text = data.body;
            if (adImage != null)
            {
                if (data.imageName != "")
                    adImage.sprite = SpriteLoader.LoadSprite(data.imageName);
                else
                    GameObject.Destroy(adImage.gameObject);
            }
        }
        Show();
    }

    public override void Close()
    {
        PopupManager.ClosePopup(this as BasePopup);
    }

    public override void Error()
    {
        throw new System.NotImplementedException();
    }
}
