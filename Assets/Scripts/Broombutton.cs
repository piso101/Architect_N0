using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RDG;


public class Broombutton : MonoBehaviour
{
    private hub Hub;
    public Button Buttonbtn;  
    private Color btncolor;
    // Start is called before the first frame update
    void Start()
    {
        GameObject obj = GameObject.Find("Menager");
        Hub = obj.GetComponent<hub>();
        btncolor=Hub.buttoncolor;       
    }
    // Update is called once per frame
    void Update()
    {
        if(Hub.czykolorjestwrece)
        {
            Buttonbtn.GetComponent<RawImage>().color = Color.white;
            Hub.szczotkajestwrece=false;
        }

    }
    public void TurnBroom()
    {
        if(Hub.szczotkajestwrece)
        {
            Buttonbtn.GetComponent<RawImage>().color = Color.white;
            Hub.szczotkajestwrece=false;
            Vibration.Vibrate(50, 150);
        }
        else
        {
            Vibration.Vibrate(50, 150);
            Hub.szczotkajestwrece = true;
            Buttonbtn.GetComponent<RawImage>().color = btncolor;
        }
    }
}
