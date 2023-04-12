using System.Numerics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Classforsavingdatafurnitures
{
    public float[] position;
    public float[] rotation;
    public string nameofprefab;
    public string nameofobject;
    public Classforsavingdatafurnitures(Statystykimebla statystykimebla)
    {
        position = new float[3];
        position[0] = statystykimebla.position.x;
        position[1] = statystykimebla.position.y;
        position[2] = statystykimebla.position.z;
        rotation = new float[3];
        rotation[0] = statystykimebla.rotation.x;
        rotation[1] = statystykimebla.rotation.y;
        rotation[2] = statystykimebla.rotation.z;
        nameofprefab = statystykimebla.prefab.name;
        nameofobject = statystykimebla.gameobjectstring;
    }
}
