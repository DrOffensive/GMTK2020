using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitingMinigamePopup : Minigame
{
    public float min_waiting_time = 2f;
    public float max_waiting_time = 10f;
    public float close_button_show_time = 3f;

    public GameObject loader;
    public GameObject close_button;

    
    
    

    void Start()
    {        
        //PopupManager.AssignPopup(popup);
        Cycle();
    }
    
    


    public void Cycle() {
        if (close_button.activeInHierarchy)
        {
            StartCoroutine(ShowHideCloseButton(close_button_show_time));
        }

        else
            StartCoroutine(ShowHideCloseButton(Random.Range(min_waiting_time, max_waiting_time)));
    }


    public void OverrideSettings(float min_waiting_time,float max_waiting_time,float close_button_show_time)
    {
        this.min_waiting_time = min_waiting_time;
        this.max_waiting_time = max_waiting_time;
        this.close_button_show_time = close_button_show_time;
    }

    public void OnSolve()
    {
        PopupManager.ClosePopup(popup);
    }

    

    public IEnumerator ShowHideCloseButton(float time) {
        yield return new WaitForSeconds(time);
        close_button.SetActive(!close_button.activeInHierarchy);
        loader.SetActive(!loader.activeInHierarchy);
        Cycle();
    }

}
