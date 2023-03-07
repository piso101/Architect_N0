using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PaintBtn : MonoBehaviour
{
    private hub Hub;
    public Button Paintbtn;
    private Color btncolor;
    void Start()
    {
        GameObject obj = GameObject.Find("Menager");
        Hub = obj.GetComponent<hub>();  
        btncolor=Hub.buttoncolor;    
    }

    // Update is called once per frame
    void Update()
    {
        if(Hub.szczotkajestwrece)
        {
            Paintbtn.GetComponent<RawImage>().color = Color.white;
            Hub.czykolorjestwrece = false;
        }
    }
    public void turnpaint()
    {
        if(Hub.czykolorjestwrece)
        {
            Paintbtn.GetComponent<RawImage>().color = Color.white;
            Hub.czykolorjestwrece = false;
        }
        else
        {
            Paintbtn.GetComponent<RawImage>().color = btncolor;
            Hub.czykolorjestwrece = true;
        }
    }
}
