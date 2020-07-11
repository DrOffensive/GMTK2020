using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MultiChoicePopup : BasePopup
{
    const string BUTTON_PREFAB = "elements/MultiChoiceButton";
    MultiChoiceButton[] buttons;
    int correctAnswer;
    [SerializeField] TextMeshProUGUI bodyText;
    [SerializeField] RectTransform buttonGroup;


    public override void Close()
    {
        PopupManager.ClosePopup(this);
    }

    public override void Error()
    {
    }

    public override void Setup(BasePopup_Data popupData)
    {
        base.Setup(popupData);
        MultiChoicePopup_Data data = (MultiChoicePopup_Data)popupData ?? null;
        if (data != null)
        {
            bodyText.text = data.body;
            GenerateButtons(data.buttons);
            correctAnswer = data.correctAnswer;
        }
        Show();
    }

    void GenerateButtons (string[] buttons)
    {
        this.buttons = new MultiChoiceButton[buttons.Length];
        for(int i = 0; i < buttons.Length; i++)
        {
            this.buttons[i] = CreateButton(buttons[i], i);
        }
    }

    MultiChoiceButton CreateButton (string text, int index)
    {
        MultiChoiceButton prefab = Resources.Load<MultiChoiceButton>(BUTTON_PREFAB);
        MultiChoiceButton instance = Instantiate(prefab, buttonGroup);
        instance.Text = text;
        instance.Button.onClick.AddListener(() => { Answer(index); });
        return instance;
    }

    void Answer (int answer)
    {
        if (answer == correctAnswer)
            Close();
        else
            Error();
    }
}
