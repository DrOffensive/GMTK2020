using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ClickCorrectButtonPopup : Minigame
{

    public Button lbutton;
    public Button rbutton;
    public TextMeshProUGUI ltext;
    public TextMeshProUGUI rtext;
    public TextMeshProUGUI desctext;
    public int current;

    

    public int correctanswer;
    // Start is called before the first frame update
    void Start()
    {
        current = -1;
        Shuffle();
        PopupManager.AssignPopup(popup);
    }

  

    public void Shuffle() {

        ColorBlock cb;

        int result = Random.Range(0, 3);
        while(result == current)
            result = Random.Range(0, 3);

        current = result;

        switch (result) {
            case 0:
                correctanswer = 2;
                desctext.text = "RED";
                desctext.color = Color.red;
                ltext.text = "Red";
                ltext.color = Color.black;
                rtext.text = "Blue";
                rtext.color = Color.red;
                cb = lbutton.colors;

                cb.normalColor = Color.red;
                cb.highlightedColor = Color.red;
                cb.pressedColor = Color.red;
                cb.selectedColor = Color.red;
                lbutton.colors = cb;

                cb = rbutton.colors;
                cb.normalColor = Color.blue;
                cb.highlightedColor = Color.blue;
                cb.pressedColor = Color.blue;
                cb.selectedColor = Color.blue;
                rbutton.colors = cb;
               

                break;
            case 1:
                correctanswer = 2;
                desctext.text = "BLUE";
                desctext.color = Color.blue;
                ltext.text = "Blue";
                ltext.color = Color.black;
                rtext.text = "Red";
                rtext.color = Color.blue;
                cb = lbutton.colors;

                cb.normalColor = Color.blue;
                cb.highlightedColor = Color.blue;
                cb.pressedColor = Color.blue;
                cb.selectedColor = Color.blue;
                lbutton.colors = cb;

                cb = rbutton.colors;
                cb.normalColor = Color.red;
                cb.highlightedColor = Color.red;
                cb.pressedColor = Color.red;
                cb.selectedColor = Color.red;
                rbutton.colors = cb;




                break;
            case 2:


                correctanswer = 1;
                desctext.text = "GREEN";
                desctext.color = Color.green;
                ltext.text = "Blue";
                ltext.color = Color.green;
                rtext.text = "Red";
                rtext.color = Color.black;
                cb = lbutton.colors;

                cb.normalColor = Color.blue;
                cb.highlightedColor = Color.blue;
                cb.pressedColor = Color.blue;
                cb.selectedColor = Color.blue;
                lbutton.colors = cb;

                cb = rbutton.colors;
                cb.normalColor = Color.green;
                cb.highlightedColor = Color.green;
                cb.pressedColor = Color.green;
                cb.selectedColor = Color.green;
                rbutton.colors = cb;
                break;
        }
    }



    public void Clicked(int i)
    {
        if (i == correctanswer)
            OnSolve();
        else
            OnWrong();
    }


    public void OnSolve()
    {
        PopupManager.ClosePopup(popup);
    }


    public void OnWrong() {
        Shuffle();
    }


}
