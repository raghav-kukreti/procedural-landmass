using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public int mapHeight;
    public int mapWidth;
    public float scale;

    public void GenerateMap()
    {
        float[,] noiseMap = Noise.GenerateNoiseMap(mapHeight, mapWidth, scale);

        MapDisplay display = FindObjectOfType<MapDisplay>();
        display.DrawNoiseMap(noiseMap);
    }
}
