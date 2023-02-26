using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialMenager : MonoBehaviour
{
    float timetostartwashing;
    float startTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    Ray ray;
    RaycastHit hit;
    // Update is called once per frame
    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out hit, Mathf.Infinity))//tutaj trzeba bedzie dodac jeszcze ifa do czy posiada miotle w rekach
        {
            if(hit.transform.tag == "dirtywall"&&Input.GetMouseButton(0))
            {
            startTime += Time.deltaTime;
            Debug.Log("czyszce");
            }
        }
        if(Input.GetMouseButton(0)&&((startTime)>3f)&&Physics.Raycast(ray, out hit,Mathf.Infinity))//tutaj trzeba bedzie dodac jeszcze ifa do czy posiada miotle w rekach
        {
            if(hit.transform.tag =="dirtywall")
            {
            //hit.transform.tag="wall";
            Debug.Log("czyszce");
            }
        }
    }
}
