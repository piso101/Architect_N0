using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject target;
    private float speedMod = 1.0f;
    private Vector3 point;
        private hub Hub;
 
    void Start () 
    {
        point = target.transform.position;
        transform.LookAt(point);
        GameObject obj = GameObject.Find("Menager");
        Hub = obj.GetComponent<hub>(); 
    }
 
    void Update () 
    {        if (Input.GetMouseButton(0)&&!Hub.nieruszajkamera)
        {
            float horizontal = Input.GetAxis("Mouse X") * speedMod;
            transform.RotateAround (target.transform.position, Vector3.up, horizontal);  
        }

        
    }
}



