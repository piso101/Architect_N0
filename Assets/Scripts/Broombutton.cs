using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Broombutton : MonoBehaviour
{
    private hub Hub;
    public Button Buttonbtn;
    public bool czyszczotka = false;    
    // Start is called before the first frame update
    void Start()
    {
       Broombutton broombutton = new Broombutton();
        GameObject obj = GameObject.Find("Menager");
        Hub = obj.GetComponent<hub>();
        broombutton.Buttonbtn = Buttonbtn;
    }

    // Update is called once per frame
    void Update()
    {
        if(czyszczotka)
        {
        GameObject buttonObj = GameObject.FindGameObjectWithTag("Buttonbtn");
        Buttonbtn.GetComponent<Image>().color = Color.blue;
        }
        else
        {

        }
    }
    public void TurnBroom()
    {
        czyszczotka = Hub.szczotkajestwrece;
        
        if(czyszczotka)
        {
            Hub.szczotkajestwrece=false;
        }
        else
        {
            Hub.szczotkajestwrece = true;
        }
    }
}
