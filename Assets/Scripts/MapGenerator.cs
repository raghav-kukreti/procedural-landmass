using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public int mapHeight;
    public int mapWidth;
    public float scale;


    public int octaves;
    public float persistance;
    public float lacunarity;
    public void GenerateMap()
    {
        float[,] noiseMap = Noise.GenerateNoiseMap(mapHeight, mapWidth, scale, octaves, persistance, lacunarity);

        MapDisplay display = FindObjectOfType<MapDisplay>();
        display.DrawNoiseMap(noiseMap);
    }
}
