using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Noise  {
    public static float[,] GenerateNoiseMap(int mapHeight, int mapWidth, float scale, int octaves, float persistance, float lacunarity)
    {
        float[,] noiseMap = new float[mapHeight, mapWidth];

        if (scale <= 0f)
        {
            scale = 0.001f;
            
        }

        float maxNoiseHeight = float.MinValue;
        float minNoiseHeight = float.MaxValue;
        
        for (int y = 0; y < mapHeight; y++) {
            for (int x = 0; x < mapWidth; x++) {
                float amplitude = 1;
                float frequency = 1;
                float noiseHeight = 0;
                
                for (int i = 0; i < octaves; i++) {
                    float sampleY = y / scale * frequency;
                    float sampleX = x / scale * frequency;


                    float perlinNoise = Mathf.PerlinNoise(sampleX, sampleY)*2 - 1;

                    noiseHeight += perlinNoise * amplitude;

                    amplitude *= persistance;
                    frequency *= lacunarity;
                    
                }

                if (noiseHeight > maxNoiseHeight) {
                    maxNoiseHeight = noiseHeight;
                }
                else if (noiseHeight < minNoiseHeight) {
                    minNoiseHeight = noiseHeight;
                }
                noiseMap[x, y] = noiseHeight;
                
            }   
        }

        for (int y = 0; y < mapHeight; y++)
        {
            for (int x = 0; x < mapWidth; x++)
            {
                // Linear interpolation :: Normalizes the value of noiseMap[x,y] to x E [0,1]
                noiseMap[x, y] = Mathf.InverseLerp(minNoiseHeight, maxNoiseHeight, noiseMap[x,y]);
            }
        }

        return noiseMap;
    }
}
