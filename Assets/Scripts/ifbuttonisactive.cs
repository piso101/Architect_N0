using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ifbuttonisactive : MonoBehaviour
{
    public bool isbuttonclicked=false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void buttonwasclicked()
    {
        if(isbuttonclicked)
        {
            GetComponent<RawImage>().color = Color.white;
            isbuttonclicked=false;
        }
        else
        {
            GetComponent<RawImage>().color = Color.green;
            isbuttonclicked=false;
        }
    }
}
