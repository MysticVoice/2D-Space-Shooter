using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Boid))]
public class BoidEditor : Editor
{
    Boid boid;
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        if(boid == null) boid = (target as Boid);
        if (GUILayout.Button("Spawn boid")) boid.spawnBoid(); ;
    }
}
