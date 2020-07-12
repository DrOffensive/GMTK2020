using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    static bool running;
    public static bool Running { get => running; set => running = value; }

    [SerializeField] Vector2 intervalRange;
    float next;
    [SerializeField] Vector2Int popupRange;

    [SerializeField] RectTransform startScreen;
    [SerializeField] Image transitionFader;
    [SerializeField] IntroScreenButton startButton, quitButton;

    [SerializeField] AudioSource introAudioSource;

    Coroutine startAnimation;

    [SerializeField] AudioClip transition;

    private void Start()
    {
        quitButton.ClickAction = () =>
        {
            Application.Quit();
        };
        startButton.ClickAction = () =>
        {
            if(startAnimation==null)
            {
                startAnimation = StartCoroutine(StartAnimation());
            }
        };
    }

    IEnumerator StartAnimation ()
    {
        introAudioSource.clip = transition;
        introAudioSource.Play();
        yield return new WaitForSeconds(transition.length);
    }

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
