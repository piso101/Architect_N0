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
    //public gameObject wyswietlaczstatystyk;
    public Vector3 rotacjastatystyk;
    //historiafarb:

    // Start is called before the first frame update
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

    // Update is called once per frame
    void Update()
    {

        if(Hub.przyciskidoruszania&&!czysiepojawil)
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
        else if(!Hub.przyciskidoruszania&&czysiepojawil)
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
