using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WriteTheAnswerPopup : Minigame
{
    string question = "";
    string answer = "placeholder";

    public TextMeshProUGUI question_text;
    public TextMeshProUGUI wrong_answer;
    public TMP_InputField input;

    public Button submit;


    

    public int error_counter = 3;

    // Start is called before the first frame update
    void Start()
    {       
        PopupManager.AssignPopup(popup);
        if (!question.Equals(""))
            question_text.text = question;
        error_counter = 3;   
    }

    public void OnInputChange() {
        if (input.text.Equals(""))
            submit.interactable = false;
        else
            submit.interactable = true;
    }


    public void OnSubmit() {
        if (input.text.Equals(answer))
            OnSolution();
        else
            DecreaseCounter();
    }

    public void DecreaseCounter()
    {
        if (!wrong_answer.gameObject.activeInHierarchy) { wrong_answer.gameObject.SetActive(true); }
        error_counter--;
        if (error_counter <= 0)
            OnSolution();
    }

    public void OnSolution()
    {
        PopupManager.ClosePopup(popup);
    }

   
}
