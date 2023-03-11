using System.Threading;
using System;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour
{
    public float wallRadius = 0.25f;
    public Vector3 przesuwaniescian;
    private List<GameObject> nearbyWalls = new List<GameObject>();
    void Update()
    {
        CheckWalls();
    }

    void CheckWalls()
    {
        
        Collider[] colliders = Physics.OverlapSphere(transform.position, wallRadius);
            if (!(nearbyWalls.Contains(GetComponent<Collider>().gameObject))&&((GetComponent<Collider>().gameObject.tag =="wall")||GetComponent<Collider>().gameObject.tag =="dirtywall"))
            {
                nearbyWalls.Add(GetComponent<Collider>().gameObject);
            }
            foreach (GameObject wall in nearbyWalls)
            {
                if ((Vector3.Distance ((wall.transform.position-przesuwaniescian), Camera.main.transform.position) > 7.5))
                {
                    wall.layer=LayerMask.NameToLayer("Default");
                wall.GetComponent<Renderer>().enabled = true;
                }
            }
            foreach (GameObject wall in nearbyWalls)
            {
                if (Vector3.Distance (wall.transform.position, Camera.main.transform.position) < 7.5)
                {
                wall.layer=LayerMask.NameToLayer("Ignore Raycast");
                wall.GetComponent<Renderer>().enabled = false;
                }
            }
    }

}

