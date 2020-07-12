using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RunningXPopup : Minigame
{
    // Start is called before the first frame update
    public int variant = -1;
    public float time_between_jumps = 0.5f;
    public int clickammount;
    public Button button;

    
    public TextMeshProUGUI text;

    public float x_min, x_max, y_min, y_max;

    void Start()
    {
        //PopupManager.AssignPopup(popup);
        variant = Random.Range(0, 2);
        Teleport();
        if (variant == 1) {
            Cycle();
            clickammount = 1;
        }
        else
            {
            clickammount = Random.Range(3, 7);                
            }

        text.text = " Click x this ammount more: " + clickammount;
    }


    public void Cycle()
    {
        StartCoroutine(TeleportAfterTime());
     }

    public void Clicked() {
        clickammount--;
        if (clickammount <= 0)
            OnSolved();

        if (variant == 0)
            Teleport();

        text.text = " Click x this ammount more: " + clickammount;
    }


    public void Teleport() {
        button.transform.gameObject.GetComponent<RectTransform>().localPosition = (Vector3)new Vector2(Random.Range(x_min, x_max), Random.Range(y_min, y_max));
    }
    


    public void OnSolved() {
        PopupManager.ClosePopup(popup);
    }


    public IEnumerator TeleportAfterTime() {
        yield return new WaitForSeconds(time_between_jumps);
        Teleport();
        Cycle();
    }
    
}
