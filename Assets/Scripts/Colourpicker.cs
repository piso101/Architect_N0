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
    public Slider Redslider;
    public Slider Greenslider;
    public Slider Blueslider;
    public GameObject currentcolor;
    //historiafarb:
    public GameObject[] historiafarb;
    public Color[] historiafarbkolory;
    private int licznikhistorii=0;
    int ktoryprzycisk;

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
    {   //shows a colour picker

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
            if(Hub.czykolorzostalwybrany)//update historii colorow
            {
                if(licznikhistorii==5)
                {
                    licznikhistorii=0;
                }
                
            
            RawImage colorraw = historiafarb[licznikhistorii].GetComponent<RawImage>();
            if (colorraw != null&&Hub.paintcolor!=null) 
            {
                historiafarbkolory[licznikhistorii]=Hub.paintcolor;
                colorraw.color = Hub.paintcolor;
            }
                
                licznikhistorii++;
                //Hub.czykolorzostalwybrany=false;
            }
            czysiepojawil=false;
            Hub.nieruszajkamera=false;
            gameobject.transform.localScale = skalamin;
            foreach (Transform child in gameobject.transform)
            {
                child.localScale = gameobject.transform.localScale;
            }
        }
    }
    public void hassliderchanged()//if slider has changed the colour picked is changing based on position of sliders
    {
            Color newColor = new Color(Redslider.value / 255f, Greenslider.value / 255f, Blueslider.value / 255f);
            Hub.paintcolor = newColor;
            RawImage currentColorRawImage = currentcolor.GetComponent<RawImage>();
            if (currentColorRawImage != null) 
            {
                currentColorRawImage.color = newColor;
            }
            Hub.czykolorzostalwybrany=true;
    }
    public void buttonisclicked(GameObject butoon)//taking the history of colours
    {
            RawImage buttonRawImage = butoon.GetComponent<RawImage>();
            if (buttonRawImage != null) 
            {
                //showcasecolor
                RawImage currentColorRawImage = currentcolor.GetComponent<RawImage>();
                if (currentColorRawImage != null) 
                {
                currentColorRawImage.color = historiafarbkolory[ktoryprzycisk];
                }
                //globalcolor
                Hub.paintcolor = historiafarbkolory[ktoryprzycisk];
                //sliders
                Redslider.value=(Hub.paintcolor.r*255f);
                Greenslider.value=(Hub.paintcolor.g*255f);
                Blueslider.value=(Hub.paintcolor.b*255f);
                Hub.czykolorzostalwybrany=true;
            }
    }
    public void ktorykolorbracie(int i)
    {
        ktoryprzycisk=i;
    }
}
