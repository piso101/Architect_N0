using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Colourpicker : MonoBehaviour
{
    private hub Hub;
    public bool czysiepojawil=false;
    public GameObject gameobject;
    public Vector3 skalamax;
    public Vector3 skalaimage;
    public Vector3 skalaslider;
    public Vector3 skalamin;
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
        if(Hub.czykolorjestwrece&&!czysiepojawil)
        {
            czysiepojawil=true;
            Hub.nieruszajkamera=true;
            gameobject.transform.localScale = skalamax;
            foreach (Transform child in gameobject.transform)
            {
                if(child.gameObject.tag=="slider")
                {
                    child.localScale = skalaslider;
                }
                else if(child.gameObject.tag=="imagescale")
                {
                    child.localScale = skalaimage;
                }
                else
                {
                    child.localScale = gameobject.transform.localScale;
                }

                

            }
            
        }
        else if(!Hub.czykolorjestwrece&&czysiepojawil)
        {
            czysiepojawil=false;
            Hub.nieruszajkamera=false;
            gameobject.transform.localScale = skalamin;
                        foreach (Transform child in gameobject.transform)
            {
                child.localScale = gameobject.transform.localScale;
            }
        }
    }
}
