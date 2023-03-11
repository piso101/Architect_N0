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
        if (Input.touchCount == 2&&!Hub.nieruszajkamera)
        {
            Vibration.Vibrate(25,100);
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

            float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;

            cam.fieldOfView += deltaMagnitudeDiff * sensitivity;
            cam.fieldOfView = Mathf.Clamp(cam.fieldOfView, minFOV, maxFOV);
        }
    }
}
