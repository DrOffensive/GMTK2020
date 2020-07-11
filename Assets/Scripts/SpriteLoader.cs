using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SpriteLoader 
{
    public static Sprite LoadSprite (string spritePath)
    {
        Debug.Log(spritePath);
        Texture2D resource = Resources.Load<Texture2D>(spritePath);
        if (resource == null)
            Debug.LogError("Couldn't load texture");
            
        Sprite sprite = Sprite.Create(resource, new Rect(0, 0, resource.width, resource.height), Vector2.one * .5f);
        return sprite;
    }
}
