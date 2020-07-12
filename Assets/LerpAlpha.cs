using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpAlpha : MonoBehaviour
{
    public SpriteRenderer spriteto_lerp;
    public float time = 360;

    void Awake() {
        StartCoroutine(StartFade(spriteto_lerp, time, 0));

    }
    // Start is called before the first frame update
    public static IEnumerator StartFade(SpriteRenderer sprite, float duration, float targetAlpha)
    {
        float currentTime = 0;
        Color color = sprite.color;
        float start = sprite.color.a;  
        

        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            color.a  = Mathf.Lerp(start, targetAlpha, currentTime / duration);
            sprite.color = color;
            yield return null;
        }
        yield break;
    }
}
