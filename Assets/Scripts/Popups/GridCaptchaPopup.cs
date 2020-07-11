using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridCaptchaPopup : MonoBehaviour
{

    public List<int> correct;
    List<int> correct_clicked;

    public List<Button> buttons;
    public Sprite image_tocut;




    // E.g. for using the center of the image
    // but half of the size


    // Create the sprite
    Sprite sprite;


    // Start is called before the first frame update
    void Start()
    {
        //sprite = image_tocut.rect = new Vector4();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
