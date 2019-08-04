using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TextureGenerator {
    public static Texture2D TextureFromColorMap(Color[] colorMap, int height, int width) {
        Texture2D texture = new Texture2D(width, height);
        texture.filterMode = FilterMode.Point;
        texture.wrapMode = TextureWrapMode.Clamp;
        texture.SetPixels(colorMap);
        texture.Apply();

        return texture;
    }

    public static Texture2D TextureFromHeightMap(float [,] heightMap) {
        int width = heightMap.GetLength(0);
        int height = heightMap.GetLength(1);
        
        
        /*
         * It's faster to generate all the the noise values at the start instead of generating them pixel by pixel.
         */
        Color[] colorMap = new Color[width * height];

        for (int y = 0; y < height; y++) {
            for (int x = 0; x < width; x++)
            {
                colorMap[x + y*width] = Color.Lerp(Color.black, Color.white, heightMap[x,y]);
            }
        }
        
        return TextureFromColorMap(colorMap, width, height);
    }
}
