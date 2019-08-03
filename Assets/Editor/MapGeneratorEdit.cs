using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor (typeof (MapGenerator))]
public class MapGeneratorEdit : Editor {

    public override void OnInspectorGUI() {
        MapGenerator mapGen = (MapGenerator)target;

        DrawDefaultInspector();

        if (GUILayout.Button("Generate"))
        {
            mapGen.GenerateMap();
        }
    }
}