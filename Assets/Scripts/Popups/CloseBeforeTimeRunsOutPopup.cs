using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CloseBeforeTimeRunsOutPopup : Minigame
{
    float time = 0;
    public float min_time = 3f;
    public float max_time = 10f;
    public TextMeshProUGUI timer;
    public GameObject text;
    public GameObject loading;
    
    // Start is called before the first frame update
    void Start()
    {
        //PopupManager.AssignPopup(popup);
        popup.HideCloseButton = false;
        timer.text = ((int)time).ToString();
        time = Random.Range((int)min_time, (int)max_time);

    }

    // Update is called once per frame
    void Update()
    {
        if (!loading.activeInHierarchy) {
            if (time > 0)
            {
                time -= Time.deltaTime;
                timer.text = ((int)time).ToString();
            }
            else
            {
                timer.text = "Too slow! Now wait.";
                StartCoroutine(Delay(Random.Range(min_time, max_time)));
            }    
            
        }
    }

    public void SetTimer(float time)
    {
        this.time = time;
    }


    public void OnSolve() {
       

    }

    public IEnumerator Delay(float time) {

        popup.HideCloseButton = true;
        loading.SetActive(true);
        text.SetActive(false);
        yield return new WaitForSeconds(time);
        text.SetActive(true);
        loading.SetActive(false);
        this.time = time;
        popup.HideCloseButton = false;
    }
}
