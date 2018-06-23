using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTargetTexture : MonoBehaviour {

    public Sprite bGSprite;
    RenderTexture dist;
    private void Awake()
    {
        dist = new RenderTexture(Screen.width, Screen.height, 0);
        var croppedTexture = new Texture2D((int)bGSprite.rect.width, (int)bGSprite.rect.height);
        var pixels = bGSprite.texture.GetPixels((int)bGSprite.rect.x,
                                                (int)bGSprite.rect.y,
                                                (int)bGSprite.rect.width,
                                                (int)bGSprite.rect.height);
        croppedTexture.SetPixels(pixels);
        croppedTexture.Apply();
        Graphics.Blit(croppedTexture, dist);
        if (GetComponent<Camera>())
        {
            GetComponent<Camera>().targetTexture = dist;
        }
        else
            print("something not right");
    }
}
