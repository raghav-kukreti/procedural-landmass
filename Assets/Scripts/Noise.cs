using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Noise  {
    public static float[,] GenerateNoiseMap(int mapHeight, int mapWidth, float scale)
    {
        float[,] noiseMap = new float[mapHeight, mapWidth];

        if (scale <= 0f)
        {
            scale = 0.001f;
            
        }
        
        for (int y = 0; y < mapHeight; y++)
        {
            for (int x = 0; x < mapWidth; x++)
            {
                float sampleY = y / scale;
                float sampleX = x / scale;


                float perlinNoise = Mathf.PerlinNoise(sampleX, sampleY);

                noiseMap[x, y] = perlinNoise;
            }   
        }
        
        return noiseMap;
    }
}
