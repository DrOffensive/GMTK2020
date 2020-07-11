using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpotTheDifferencePopup : Minigame
{

    public Sprite sprite_spot;
    public Sprite sprite_difference;    
    public Image image_unchanged;
    public Image image_changed;
    public Button button_difference;

    // Start is called before the first frame update
    void Start()
    {
        PopupManager.AssignPopup(popup);
        popup.HideCloseButton = true;
        image_changed.sprite = image_changed.sprite = sprite_spot;
        button_difference.image.sprite = sprite_difference;
        button_difference.transform.gameObject.GetComponent<RectTransform>().localPosition = (Vector3)new Vector2( Random.Range(-60,60), Random.Range(-60, 60));
    }

    
    

    public void OnSolve()
    {
        PopupManager.ClosePopup(popup);

    }
}
