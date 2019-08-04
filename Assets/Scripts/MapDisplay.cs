using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapDisplay : MonoBehaviour
{
    public Renderer textureRenderer;

    public void DrawNoiseMap(float[,] noiseMap)
    {
        int width = noiseMap.GetLength(0);
        int height = noiseMap.GetLength(1);
        
        Texture2D texture = new Texture2D(width, height);
        
        /*
         * It's faster to generate all the the noise values at the start instead of generating them pixel by pixel.
         */
        Color[] colorMap = new Color[width * height];

        for (int y = 0; y < height; y++) {
            for (int x = 0; x < width; x++)
            {
                colorMap[x + y*width] = Color.Lerp(Color.black, Color.white, noiseMap[x,y]);
            }
        }
        
        texture.SetPixels(colorMap);
        texture.Apply();
        
     // To preview maps without entering game mode -> use textureRenderer.Material

     
     textureRenderer.sharedMaterial.mainTexture = texture;
     textureRenderer.transform.localScale = new Vector3(width, 1, height);
    }
}
