using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

public static class Noise  {
    public static float[,] GenerateNoiseMap(int mapHeight, int mapWidth, int seed, float scale, int octaves, float persistance, float lacunarity, Vector2 offset)
    {
        System.Random prng = new System.Random(seed);
        Vector2[] octaveOffsets = new Vector2[octaves];

        for (int i = 0; i < octaves; i++) {
            float offsetX = prng.Next(-100000, 100000) + offset.x;
            float offsetY = prng.Next(-100000, 100000) + offset.y;
            
            Vector2 tmpOffset = new Vector2(offsetX, offsetY);
            octaveOffsets[i] = tmpOffset;
            
        }
        
        float[,] noiseMap = new float[mapHeight, mapWidth];

        if (scale <= 0f) {
            scale = 0.001f;
        }

        float maxNoiseHeight = float.MinValue;
        float minNoiseHeight = float.MaxValue;

        float halfWidth = mapWidth / 2f;
        float halfHeight = mapHeight / 2f;
        
        for (int y = 0; y < mapHeight; y++) {
            for (int x = 0; x < mapWidth; x++) {
                float amplitude = 1;
                float frequency = 1;
                float noiseHeight = 0;
                
                for (int i = 0; i < octaves; i++) {
                    float sampleY = y / scale * frequency + octaveOffsets[i].x;
                    float sampleX = x / scale * frequency + octaveOffsets[i].y;


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
