using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialMenager : MonoBehaviour
{
    float timeithasstartedcountingfrom;
    float startTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    Ray ray;
    RaycastHit hit;
    public int counthowlong =0;
    // Update is called once per frame
    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out hit, Mathf.Infinity))//tutaj trzeba bedzie dodac jeszcze ifa do czy posiada miotle w rekach
        {
            
            if(hit.transform.tag == "dirtywall"&&Input.GetMouseButton(0))
            {
            
            counthowlong++;
            Debug.Log("czyszce"+counthowlong);
            }
        }
        if((Input.GetMouseButton(0))&&(counthowlong>120)&&(Physics.Raycast(ray, out hit,Mathf.Infinity)))//tutaj trzeba bedzie dodac jeszcze ifa do czy posiada miotle w rekach
        {
            if(hit.transform.tag =="dirtywall")
            {
            hit.transform.tag="wall";
            counthowlong=0;
            Debug.Log("wyczyszczone");
            }
        }
    }
}
