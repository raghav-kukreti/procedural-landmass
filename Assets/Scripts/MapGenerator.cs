using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public int mapHeight;
    public int mapWidth;
    public float scale;


    public int octaves;
    [Range(0,1)]
    public float persistance;
    public float lacunarity;

    public int seed;
    public Vector2 offset;
    public void GenerateMap()
    {
        float[,] noiseMap = Noise.GenerateNoiseMap(mapHeight, mapWidth, seed, scale, octaves, persistance, lacunarity, offset);

        MapDisplay display = FindObjectOfType<MapDisplay>();
        display.DrawNoiseMap(noiseMap);
    }

    private void OnValidate() {
        if (mapWidth < 1 ) {
            mapWidth = 1;
        }

        if (mapHeight < 1) {
            mapHeight = 1;
        }

        if (lacunarity < 1) {
            lacunarity = 1;
        }

        if (octaves < 0) {
            octaves = 0;
        }
        
    }
}
