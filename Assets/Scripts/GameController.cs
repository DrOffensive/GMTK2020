using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class GameController : MonoBehaviour
{
    static bool running;
    public static bool Running { get => running; set => running = value; }

    [SerializeField] Vector2 intervalRange;
    float next;
    [SerializeField] Vector2Int popupRange;
    [SerializeField] TextMeshProUGUI debugText;
    // Update is called once per frame
    void Update()
    {
        if(running)
        {
            if(Time.realtimeSinceStartup >= next)
            {
                next = Time.realtimeSinceStartup + (Random.Range(intervalRange.x, intervalRange.y));
                SpawnPopups();
            }
        }

        //for debugging
        if(Input.GetKeyDown(KeyCode.Space))
        {
            running = !running;
            debugText.text = running ? "Running" : "Stopped";
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    void SpawnPopups ()
    {
        int popups = Random.Range(popupRange.x, popupRange.y);
        for(int i = 0; i < popups; i++)
        {
            PopupManager.AddPopup(PopupLoader.CreateRandomPopup());
        }
    }
}
