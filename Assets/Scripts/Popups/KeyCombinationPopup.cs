using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KeyCombinationPopup : Minigame
{
    public int variant = 0;
    public TextMeshProUGUI text;
    

    void Start()
    {
        PopupManager.AssignPopup(popup);
        variant = Random.Range(0, 5);
        Init();
    }

    void Update() {

       

            switch (variant)
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

            }
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
