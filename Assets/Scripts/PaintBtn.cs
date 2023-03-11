using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RDG;

public class PaintBtn : MonoBehaviour
{
    private hub Hub;
    public Button Paintbtn;
    private Color btncolor;
    int licznik=3;
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
        
        switch(licznik)
        {
            case(1):
            Vibration.Vibrate(50, 150);
            Paintbtn.GetComponent<RawImage>().color = Color.white;
            Hub.czykolorjestwrece = false;
            Hub.malowac=false;
            licznik=3;
            break;
        
            case(2):
            Vibration.Vibrate(50, 150);
            Paintbtn.GetComponent<RawImage>().color = btncolor;
            Hub.czykolorjestwrece = false;//pokazuje colorpicker
            Hub.malowac=true;
            licznik=1;
            break;
        
            case(3):
            Vibration.Vibrate(50, 150);
            Paintbtn.GetComponent<RawImage>().color = btncolor;
            Hub.czykolorjestwrece = true;//pokazuje colorpicker
            Hub.malowac=true;
            licznik=2;
            break;
        }
    }
}
