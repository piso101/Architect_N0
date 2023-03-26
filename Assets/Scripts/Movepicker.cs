using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movepicker : MonoBehaviour
{
    private hub Hub;
    public bool czysiepojawil=false;
    public GameObject gameobject;
    public Vector3 skalamax;
    public Vector3 skalaimage;
    public Vector3 skalascore;
    public Vector3 skalamin;
    public Vector3 rotacjastatystyk;

    void Start()
    {
        GameObject obj = GameObject.Find("Menager");
        Hub = obj.GetComponent<hub>();  
            gameobject.transform.localScale = skalamin;
            foreach (Transform child in gameobject.transform)
            {
                child.localScale = gameobject.transform.localScale;
            }
    }


    void Update()//this code is shitty i know ... it is meant to show buttons to move furniture but instead of turning them of or on my shitty brain thought about changing their size so here we go ...
    {

        if(Hub.przyciskidoruszania&&!czysiepojawil)//przyciskidoruszania (eng.buttons for moving) czysiepojawil (eng.was it shown?)
        {
            czysiepojawil=true;
            
            gameobject.transform.localScale = skalamax;
            foreach (Transform child in gameobject.transform)
            {
                if(child.gameObject.tag=="imagescale")
                {
                    child.localScale = skalaimage;
                }
                else if (child.gameObject.tag=="scorescale")
                {
                    child.localScale = skalascore;
                }
                else
                {
                    child.localScale = gameobject.transform.localScale;
                }
            }
        }
        else if(!Hub.przyciskidoruszania&&czysiepojawil)//else turn scale of those button to the min so playyer cannot see them
        {

            czysiepojawil=false;
            
            gameobject.transform.localScale = skalamin;
            foreach (Transform child in gameobject.transform)
            {
                child.localScale = gameobject.transform.localScale;
            }
        }
    }

}
