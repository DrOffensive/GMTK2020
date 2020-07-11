using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.Requests;
using UnityEngine;
using UnityEngine.Networking;

public class MinigamePopup : BasePopup
{

    const string MINIGAME_PATH = "minigames/";
    [SerializeField] RectTransform contentTransform;
    public override void Close()
    {
        PopupManager.ClosePopup(this as MinigamePopup);
    }

    public override void Error()
    {
        throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
    void Start()
    {
        closeButton.onClick.AddListener(() => Close());
        HideCloseButton = true;
    }

    public override void Setup(BasePopup_Data popupData)
    {
        base.Setup(popupData);
        if (popupData is MinigamePopup_Data)
        {
            MinigamePopup_Data minigamedata = (MinigamePopup_Data)popupData;
            Minigame minigame = Instantiate(LoadMinigame(minigamedata.minigame), contentTransform);
            minigame.Initialize(this);
            Show();
        }
    }

    static Minigame LoadMinigame (string minigame)
    {
        Object game = Resources.Load(MINIGAME_PATH + minigame);
        return (game as GameObject).GetComponent<Minigame>() ?? null;
    }
}
