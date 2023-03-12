using System.Threading;
using System;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour
{
    public float wallRadius = 0.5f;
    public Vector3 przesuwaniescian;
    private List<GameObject> nearbyWalls = new List<GameObject>();
    void Update()
    {
        CheckWalls();
    }

    void CheckWalls()
    {
        
        Collider[] colliders = Physics.OverlapSphere(transform.position, wallRadius);
            if (!(nearbyWalls.Contains(GetComponent<Collider>().gameObject))&&((GetComponent<Collider>().gameObject.tag =="wall")||GetComponent<Collider>().gameObject.tag =="dirtywall"||GetComponent<Collider>().gameObject.tag =="wallaleniemaluj"))
            {
                nearbyWalls.Add(GetComponent<Collider>().gameObject);
            }
            foreach (GameObject wall in nearbyWalls)
            {
                if ((Vector3.Distance ((wall.transform.position-przesuwaniescian), Camera.main.transform.position) > 7.5))
                {
                    wall.layer=LayerMask.NameToLayer("Default");
                wall.GetComponent<Renderer>().enabled = true;
        if (wall != null) 
        {
           // Loop through all child objects in "wall"
           foreach (Transform child in wall.transform) 
           {
              // Make sure that the child is a valid GameObject
              if (child != null && child.gameObject != null) 
              {
                  // Set the child's layer to "Default"
                  child.gameObject.layer = LayerMask.NameToLayer("Default");
            
                  // Enable the child's Renderer component if it has one
                   Renderer renderer = child.gameObject.GetComponent<Renderer>();
                  if (renderer != null) 
                   {
                       renderer.enabled = true;
                    }
                }
          }
        }
                }
            }
            foreach (GameObject wall in nearbyWalls)
            {
                if (Vector3.Distance (wall.transform.position, Camera.main.transform.position) < 7.5)
                {
                wall.layer=LayerMask.NameToLayer("Ignore Raycast");
                wall.GetComponent<Renderer>().enabled = false;
                        if (wall != null) 
                {
                 // Loop through all child objects in "wall"
                    foreach (Transform child in wall.transform) 
                 {
                     // Make sure that the child is a valid GameObject
                    if (child != null && child.gameObject != null) 
                    {
                        // Set the child's layer to "Default"
                       child.gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
                 
                        // Enable the child's Renderer component if it has one
                        Renderer renderer = child.gameObject.GetComponent<Renderer>();
                       if (renderer != null) 
                        {
                               renderer.enabled = false;
                            }
                    }
                    }
                }
            }
    }

}}

