using System.Net;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RDG;
using TMPro;

public class gridsnap : MonoBehaviour
{

    public string furnituretag;
    public Vector3 podnoszeniemebli;
    float holdTime = 0.5f;
    float heldDuration=0f;
    bool czyprzedmiotjestpodniesiony=false;
    public GameObject podniesionyprzedmiot;
    private hub Hub;
    public int polozeniekamery;
    public GameObject kamera;
    public TextMeshProUGUI textnazwaobiektu;
    public TextMeshProUGUI textlevelobiektu;
    public TextMeshProUGUI textzarobekobiekku;
    public float wartoscyrotacjikamery=0f;
    public float poczatkowawartosckamery;
    public float odejmowanieodrotacjikamery=0f;
    public Vector3 wtomstronke;

    void Start()
    {
        GameObject obj = GameObject.Find("Menager");
        Hub = obj.GetComponent<hub>();
        poczatkowawartosckamery = kamera.transform.rotation.y;
        
    }
    void Update()
    {
        if(!(Hub.spawnujtak))
        {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
            if((Physics.Raycast(ray, out hit))&&hit.collider.gameObject.tag == furnituretag&&Input.GetMouseButton(0))
            {
                heldDuration +=Time.deltaTime;
                if(heldDuration>=holdTime&&!czyprzedmiotjestpodniesiony&&podniesionyprzedmiot==null)
                {
                    Hub.przyciskidoruszania=true;
                    czyprzedmiotjestpodniesiony = true;
                    podniesionyprzedmiot=hit.transform.gameObject;
                    podniesionyprzedmiot.transform.position=podniesionyprzedmiot.transform.position+podnoszeniemebli;
                    heldDuration = 0f;
                    Vibration.Vibrate(25, 200);
                    
                    Statystykimebla statystykimebla = podniesionyprzedmiot.GetComponent<Statystykimebla>();
                    
                    textlevelobiektu.text=statystykimebla.rzadkoscprzedmiotu.ToString();
                    //
                    textnazwaobiektu.text=statystykimebla.nazwaobiektu;

                    //statystykimebla.nazwaobiektu
                    textzarobekobiekku.text=((statystykimebla.rzadkoscprzedmiotu)*100).ToString()+"$/min";
                    
                }
                
                else if(heldDuration>=holdTime&&czyprzedmiotjestpodniesiony&&podniesionyprzedmiot!=null)
                {
                    Hub.przyciskidoruszania=false;
                    czyprzedmiotjestpodniesiony = false;
                    podniesionyprzedmiot.transform.position=podniesionyprzedmiot.transform.position-podnoszeniemebli;
                    podniesionyprzedmiot=null;
                    heldDuration = 0f;
                    Vibration.Vibrate(25, 200);
                }
            }
            //polozenie kamery

            wartoscyrotacjikamery = kamera.transform.rotation.y-poczatkowawartosckamery-odejmowanieodrotacjikamery;
            if(wartoscyrotacjikamery>=0f&&wartoscyrotacjikamery<=90f)
            {
                polozeniekamery=1;
                
            }
            else if(wartoscyrotacjikamery>90f&&wartoscyrotacjikamery<=180f)
            {
                polozeniekamery=2;
            }
            else if(wartoscyrotacjikamery>180f&&wartoscyrotacjikamery<=270f)
            {
                polozeniekamery=3;
            }
            else if(wartoscyrotacjikamery>270f&&wartoscyrotacjikamery<=360f)
            {
                odejmowanieodrotacjikamery=360f;
                polozeniekamery=4;
            }
        }
    }
    
    float iksint;
    public void iks(float i)
    {
        iksint =i;
    }
    float igryk;
    public void igrek(float i)
    {
        igryk =i;
    }
    float zet;
    public void zent(float i)
    {
        zet =i;
    }
    bool wartoscdopowtarzaniaprzycisku;
    int licz =0;
    bool policzone=false;
    public void zmien(bool zmien)
    {
        wartoscdopowtarzaniaprzycisku=zmien;
    }
        private void FixedUpdate() 
        {
            switch(polozeniekamery)
            {
                case 1:
                {
                    wtomstronke = new Vector3(iksint, igryk, zet);
                    break;
                }
                case 2:
                {
                    wtomstronke = new Vector3(zet, igryk, iksint);
                    break;
                }
                case 3:
                {
                    wtomstronke = new Vector3(-iksint, igryk, -zet);
                    break;
                }
                case 4:
                {
                    wtomstronke = new Vector3(-zet, igryk, -iksint);
                    break;
                }

            }
            if((wartoscdopowtarzaniaprzycisku)&&(policzone))
            {
            ruszaj(wtomstronke);
            policzone= false;
            }
            else if((wartoscdopowtarzaniaprzycisku)&&(!policzone))
            {
                if(licz<20)
                {
                    licz++;
                }
                else 
                {
                    licz=20;
                    policzone=true;
                }
            }
        
        }

    
    public void ruszaj(Vector3 wtomstronke)
    {
        // Move the object
        podniesionyprzedmiot.transform.position += wtomstronke;
        podniesionyprzedmiot.tag ="ruszam";
        Vibration.Vibrate(25, 150);
        Statystykimebla statystykimebla = podniesionyprzedmiot.GetComponent<Statystykimebla>();
        // Check for collisions
        Renderer objectRenderer = podniesionyprzedmiot.GetComponent<Renderer>();
        Vector3 size = (objectRenderer.bounds.size / 2.8f)*statystykimebla.sizemultiplyier;
        Vector3 center = podniesionyprzedmiot.transform.position;
        Quaternion rotation = podniesionyprzedmiot.transform.rotation;
        rotation *= Quaternion.Euler(statystykimebla.rotationaplly);
        // OverlapBox that fits into the object's convex shape
        Collider[] colliders = Physics.OverlapBox(center, size, rotation );
        foreach (Collider collider in colliders)
        {
            // Check if colliding with wall, furniture, or dirtywall
            if (collider.gameObject.CompareTag("wall") || collider.gameObject.CompareTag("furniture") || collider.gameObject.CompareTag("dirtywall")||collider.gameObject.CompareTag("sceneria"))
            {
                Vibration.Vibrate(100, 100);
                podniesionyprzedmiot.transform.position -= wtomstronke;
                break;
            }
        }

        podniesionyprzedmiot.tag ="furniture";
    }


    public void obracajmnie()
    {
        //Rotating Object
        Vector3 wtomstronke = new Vector3(0f, 0f, 90f);
        Quaternion rotation = Quaternion.Euler(wtomstronke);
        GameObject makapaka = new GameObject();
        makapaka.transform.rotation = podniesionyprzedmiot.transform.rotation;
        podniesionyprzedmiot.transform.rotation *= rotation;
        podniesionyprzedmiot.tag = "ruszam";
        Vibration.Vibrate(25, 150);
        //creating colliderbox
        Statystykimebla statystykimebla = podniesionyprzedmiot.GetComponent<Statystykimebla>();
        Renderer objectRenderer = podniesionyprzedmiot.GetComponent<Renderer>();
        Vector3 size = (objectRenderer.bounds.size / 2.6f)*statystykimebla.sizemultiplyier;
        Vector3 center = podniesionyprzedmiot.transform.position;
        Quaternion rotationcube = podniesionyprzedmiot.transform.rotation;
        Collider[] colliders = Physics.OverlapBox(center, size, rotationcube );
        foreach (Collider collider in colliders)
        {
            if(collider.gameObject.CompareTag("wall") || collider.gameObject.CompareTag("furniture")||collider.gameObject.CompareTag("dirtywall")||collider.gameObject.CompareTag("sceneria"))
            {
                Vibration.Vibrate(100, 100);
                podniesionyprzedmiot.transform.rotation = makapaka.transform.rotation;
                
            }
        }
        podniesionyprzedmiot.tag = "furniture";
    }



    public void usungo()
    {
        
        Hub.money+=(podniesionyprzedmiot.GetComponent<Statystykimebla>().rzadkoscprzedmiotu)*100;
                Destroy(podniesionyprzedmiot);
                Hub.przyciskidoruszania=false;
                czyprzedmiotjestpodniesiony = false;
                podniesionyprzedmiot=null;
                heldDuration = 0f;
                Vibration.Vibrate(100, 250);
    }


}
