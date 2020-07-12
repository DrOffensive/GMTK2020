using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RadioQuestion : Minigame
{
    //this we need set
    public int ammountofanswers;
    public int correct_answer;
    public string[] answers;
    public string question;

    public TextMeshProUGUI question_text;
    public GameObject vertical_group;
    public int chosen = 0;
    public Button submit;
    public GameObject toggle_prefab;
    public List<GameObject> toggles;
   

    public GameObject wrong;
    int counter = 3;

    // Start is called before the first frame update
    void Awake()
    {
        PopupManager.AssignPopup(popup);
        ammountofanswers = answers.Length;
        question_text.text = question;
        toggles = new List<GameObject>();

        for (int i = 0; i < ammountofanswers; i++) {
           

            GameObject created = Instantiate(toggle_prefab);
            Toggle toggle = created.GetComponent<Toggle>();
            
            toggles.Add(created);
            if (i == 0)
                toggle.isOn = true;
            created.transform.SetParent(vertical_group.transform);
            created.transform.GetChild(1).GetComponent<Text>().text = answers[i];
            vertical_group.GetComponent<ToggleGroup>().RegisterToggle(toggle);
            toggle.group = vertical_group.GetComponent<ToggleGroup>();
        }
    }

  

    public void OnSubmit() {
       for(int i = 0; i < ammountofanswers; i++)
        {
            if (toggles[i].GetComponent<Toggle>().isOn)
                chosen = i;
        }
        if (chosen == correct_answer)
            OnSolve();
        else
            OnWrong();

    }

    public void OnSolve()
    {
        PopupManager.ClosePopup(popup);

    }

    public void OnWrong() {
        counter--;
        if (counter <= 0)
            OnSolve();

        if (!wrong.activeInHierarchy)
            wrong.SetActive(true);
    }

    

    
}
