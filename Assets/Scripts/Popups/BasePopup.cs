using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BasePopup : MonoBehaviour
{

    public abstract void Show();
    public abstract void Error();
    public abstract void Close();
}
