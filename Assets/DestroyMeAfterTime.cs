using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMeAfterTime : MonoBehaviour
{
    public float time;
    // Start is called before the first frame update
    void Awake()
    {
        StartCoroutine(DestroyMeAfterSec(time));
    }

   

    IEnumerator DestroyMeAfterSec(float time) {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}
