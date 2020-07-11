using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MultiChoiceButton : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI buttonText;
    public string Text { get => buttonText.text; set => buttonText.text = value; }
    public Button Button => GetComponent<Button>();
}
