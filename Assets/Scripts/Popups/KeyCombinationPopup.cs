using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class KeyCombinationPopup : Minigame
{
    const string GREEN_COLOR = "#008000";
    const string BLACK_COLOR = "#000000";
    public int variant = 0;
    public TextMeshProUGUI text;

    [SerializeField] string textPrefix = "Please press keys: ";
    [SerializeField] Vector2Int letters = new Vector2Int(3, 5);
    (string key, KeyCode keyCode)[] selectedLetters;


    public List<(string key, KeyCode keyCode)> keyValues = new List<(string key, KeyCode keyCode)>() 
    {
        ( "a", KeyCode.A),
        ( "c", KeyCode.B),
        ( "d", KeyCode.A),
        ( "e", KeyCode.B),
        ( "f", KeyCode.A),
        ( "g", KeyCode.B),
        ( "h", KeyCode.A),
        ( "i", KeyCode.B),
        ( "j", KeyCode.A),
        ( "k", KeyCode.B),
        ( "l", KeyCode.A),
        ( "m", KeyCode.B),
        ( "n", KeyCode.A),
        ( "o", KeyCode.B),
        ( "p", KeyCode.A),
        ( "q", KeyCode.B),
        ( "r", KeyCode.A),
        ( "s", KeyCode.B),
        ( "t", KeyCode.A),
        ( "u", KeyCode.B),
        ( "v", KeyCode.A),
        ( "x", KeyCode.B),
        ( "y", KeyCode.A),
        ( "z", KeyCode.B),
        ( "0", KeyCode.A),
        ( "1", KeyCode.B),
        ( "2", KeyCode.A),
        ( "3", KeyCode.B),
        ( "4", KeyCode.A),
        ( "5", KeyCode.B),
        ( "6", KeyCode.A),
        ( "7", KeyCode.B),
        ( "8", KeyCode.A),
        ( "9", KeyCode.B)
    };

    void SelectLetters()
    {
        int amountOfLetters = Random.Range(letters.x, letters.y);
        selectedLetters = new (string key, KeyCode keyCode)[amountOfLetters];
        for(int i = 0; i < amountOfLetters; i++)
        {
            int selection = Random.Range(0, keyValues.Count);
            selectedLetters[i] = keyValues[selection];
            keyValues.Remove(keyValues[selection]);
        }
    }

    void Start()
    {
        //PopupManager.AssignPopup(popup);
        //variant = Random.Range(0, 5);
        //Init();
        SelectLetters();
    }

    void CheckKeys ()
    {
        string text = textPrefix;
        bool allKeysPressed = true;
        for(int i = 0; i < selectedLetters.Length; i++)
        {
            var selection = selectedLetters[i];
            bool pressed = true;

            if (Input.GetKey(selection.keyCode))
            {
                Debug.Log("Registered key: " + selection.key);
            } else
            {
                allKeysPressed = false;
                pressed = false;
            }

            text += ($"<color={(pressed ? GREEN_COLOR : BLACK_COLOR)}>") + selection.key + ("</color>") + (i < selectedLetters.Length-1 ? " + " : "");
        }

        this.text.text = text;

        if (allKeysPressed)
            OnSolved();
    }

    void Update() {

        if(selectedLetters != null && selectedLetters.Length > 0)
        {
            string text = textPrefix;
            bool allKeysPressed = true;
            for (int i = 0; i < selectedLetters.Length; i++)
            {
                var selection = selectedLetters[i];
                bool pressed = true;

                if (Input.GetKey(selection.key))
                {
                    Debug.Log("Registered key: " + selection.key);
                }
                else
                {
                    allKeysPressed = false;
                    pressed = false;
                }

                text += ($"<color={(pressed ? GREEN_COLOR : BLACK_COLOR)}>") + selection.key + ("</color>") + (i < selectedLetters.Length - 1 ? " + " : "");
            }

            this.text.text = text;

            if (allKeysPressed)
                OnSolved();
        }

            /*switch (variant)
            {

                case 0:
                    if (Input.GetKey(KeyCode.Alpha1) && Input.GetKey(KeyCode.C) && Input.GetKey(KeyCode.LeftShift)  && Input.GetKey(KeyCode.Alpha0) && Input.GetKey(KeyCode.N))
                    {
                        OnSolved();
                    }
                    break;
                case 1:
                    if (Input.GetKey(KeyCode.Alpha4) && Input.GetKey(KeyCode.Alpha2) && Input.GetKey(KeyCode.Alpha0))
                    {
                        OnSolved();
                    }
                    break;
                case 2:
                    if (Input.GetKey(KeyCode.Z) && Input.GetKey(KeyCode.M) && Input.GetKey(KeyCode.P) && Input.GetKey(KeyCode.Q) && Input.GetKey(KeyCode.Alpha6))
                    {
                        OnSolved();
                    }
                    break;
                case 3:
                    if (Input.GetKey(KeyCode.LeftBracket) && Input.GetKey(KeyCode.U) && Input.GetKey(KeyCode.RightBracket))
                    {
                        OnSolved();
                    }
                    break;

                case 4:
                    if (Input.GetKey(KeyCode.I) && Input.GetKey(KeyCode.H) && Input.GetKey(KeyCode.Alpha8) && Input.GetKey(KeyCode.U))
                    {
                        OnSolved();
                    }
                    break;

            }*/
    }

    public void Init()
    {
        switch (variant)
        {
            case 0:
                text.text = "Press: " + "1 + c + left shift + 0 + n";
                break;
            case 1:
                text.text = "Press: " + "4 + 2 + 0";
                break;
            case 2:
                text.text = "Press: " + "z + m + p + q + 6";
                break;
            case 3:
                text.text = "Press: " + " [ + u + ]";
                break;

            case 4:
                text.text = "Press: " + "i + h + 8 + u";
                break;
        }

    }

    


    public void OnSolved() {
        PopupManager.ClosePopup(popup);
    }



}
