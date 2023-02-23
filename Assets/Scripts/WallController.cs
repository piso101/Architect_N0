using System.Threading;
using System;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour
{
    public float wallRadius = 0.25f;
    private List<GameObject> nearbyWalls = new List<GameObject>();
    void Update()
    {
        
        CheckWalls();
    }

    void CheckWalls()
    {
        
        Collider[] colliders = Physics.OverlapSphere(transform.position, wallRadius);
        // Add any new walls to the nearbyWalls list
            if (!nearbyWalls.Contains(GetComponent<Collider>().gameObject))
            {
                nearbyWalls.Add(GetComponent<Collider>().gameObject);
            }
            foreach (GameObject wall in nearbyWalls)
            {
                if ((Vector3.Distance (wall.transform.position, Camera.main.transform.position) > 7.5))
                {
                wall.GetComponent<Renderer>().enabled = true;
                }
            }
            foreach (GameObject wall in nearbyWalls)
            {
                if (Vector3.Distance (wall.transform.position, Camera.main.transform.position) < 7.5)
                {
                wall.GetComponent<Renderer>().enabled = false;
                }
            }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, wallRadius);
    }
}

