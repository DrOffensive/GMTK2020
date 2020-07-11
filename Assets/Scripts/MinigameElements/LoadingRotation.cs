using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingRotation : MonoBehaviour
{
    // Start is called before the first frame update
    public float ammount = 180f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0,0,ammount * Time.deltaTime));
    }
}
