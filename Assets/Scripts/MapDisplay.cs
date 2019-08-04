using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapDisplay : MonoBehaviour
{
    public Renderer textureRenderer;

    public void DrawTexture(Texture2D texture)
    {
     // To preview maps without entering game mode -> use textureRenderer.Material
     textureRenderer.sharedMaterial.mainTexture = texture;
     textureRenderer.transform.localScale = new Vector3(texture.width, 1, texture.height);
    }
}
