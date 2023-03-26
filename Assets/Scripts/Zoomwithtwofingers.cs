using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RDG;

public class Zoomwithtwofingers : MonoBehaviour
{
    public float minFOV = 60f;
    public float maxFOV = 120f;
    public float sensitivity = 0.01f;
    private hub Hub;
    private Camera cam;

    private void Start()
    {
        cam = GetComponent<Camera>();
        GameObject obj = GameObject.Find("Menager");
        Hub = obj.GetComponent<hub>();  
    }

    private void Update()
    {
        if (Input.touchCount == 2&&!Hub.nieruszajkamera)//if there are two fingers on screen and function nieruszajkamera(eng.dontmovecamera) is off 
        {
            Vibration.Vibrate(25,100);//function to vibrate phone
            Touch touchZero = Input.GetTouch(0);//get location of touches
            Touch touchOne = Input.GetTouch(1);

            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;//yurn those positions to vector2
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;//calculate based on previous trouches what user is intending to do zoom in or zoom out
            float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

            float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;

            cam.fieldOfView += deltaMagnitudeDiff * sensitivity;
            cam.fieldOfView = Mathf.Clamp(cam.fieldOfView, minFOV, maxFOV);//clamp those values betweenn min and max to get a bit of control how much player can zoom
        }
    }
}
