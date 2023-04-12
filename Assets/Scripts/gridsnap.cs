using System.Security.AccessControl;
using System.Net;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RDG;
using TMPro;
using System.IO;

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
        if(!(Hub.spawnujtak))//this picks up a furniture
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
        {//this in the future will based on camera location switch movement of a joystick that moves furniture
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
            else if((wartoscdopowtarzaniaprzycisku)&&(!policzone))//slows down movememnt of furniture by a bit
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
        podniesionyprzedmiot.tag = "ruszam";
        Vibration.Vibrate(25, 150);
        Statystykimebla statystykimebla = podniesionyprzedmiot.GetComponent<Statystykimebla>();
        // Check for collisions
        Renderer objectRenderer = podniesionyprzedmiot.GetComponent<Renderer>();
        Vector3 size = ((objectRenderer.bounds.size / 2.8f) * statystykimebla.sizemultiplyier) + statystykimebla.scaleapply;
        Vector3 center = podniesionyprzedmiot.transform.position + statystykimebla.centerapply;
        Quaternion rotation = podniesionyprzedmiot.transform.rotation;
        rotation *= Quaternion.Euler(statystykimebla.rotationaplly);
        // Modify size based on Y-axis rotation angle
        float angle = podniesionyprzedmiot.transform.eulerAngles.y;
        float sin = Mathf.Abs(Mathf.Sin(angle * Mathf.Deg2Rad));
        float cos = Mathf.Abs(Mathf.Cos(angle * Mathf.Deg2Rad));
        float xSize = size.x * cos + size.z * sin;
        float zSize = size.x * sin + size.z * cos;
        size = new Vector3(xSize, size.y, zSize);
        // OverlapBox that fits into the object's convex shape
        Collider[] colliders = Physics.OverlapBox(center, size, rotation);
        foreach (Collider collider in colliders)
        {
            // Check if colliding with wall, furniture, or dirtywall
            if (collider.gameObject.CompareTag("wall") || collider.gameObject.CompareTag("furniture") || collider.gameObject.CompareTag("dirtywall") || collider.gameObject.CompareTag("sceneria"))
            {
                Vibration.Vibrate(100, 100);
                podniesionyprzedmiot.transform.position -= wtomstronke;
                break;
            }
        }
        podniesionyprzedmiot.tag = "furniture";
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

        // Get the original size and center of the object
        Vector3 originalSize = objectRenderer.bounds.size;
        Vector3 originalCenter = objectRenderer.bounds.center;

        // Rotate the size and center based on the object's rotation
        Quaternion objectRotation = podniesionyprzedmiot.transform.rotation;
        Vector3 rotatedSize = objectRotation * originalSize;
        Vector3 rotatedCenter = objectRotation * originalCenter;

        // Scale the size based on the object's scale and size multiplier
        Vector3 scaledSize = (rotatedSize / 2.6f) * statystykimebla.sizemultiplyier + statystykimebla.scaleapply;

        // Calculate the new center based on the scaled size
        Vector3 newCenter = podniesionyprzedmiot.transform.position + rotatedCenter + statystykimebla.centerapply;

        // OverlapBox with the new size and center
        Collider[] colliders = Physics.OverlapBox(newCenter, scaledSize, objectRotation);

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

    public void usunplikzapisany(GameObject podniesionyprzedmiot)
    {
        string pathname = podniesionyprzedmiot.GetComponent<Statystykimebla>().gameobjectstring;
        string path = Application.persistentDataPath + "/" + pathname + ".furnitrue";
        File.Delete(path);
    }

    public void usungo()
    {
        
                usunplikzapisany(podniesionyprzedmiot);
                double tempmoney = PlayerPrefs.GetInt("wallet");
                tempmoney+=(podniesionyprzedmiot.GetComponent<Statystykimebla>().rzadkoscprzedmiotu)*100;
                PlayerPrefs.SetInt("wallet",(int)tempmoney);
                int temp = PlayerPrefs.GetInt("sumarzadkosciprzedmiotow");
                temp-=podniesionyprzedmiot.GetComponent<Statystykimebla>().rzadkoscprzedmiotu;
                PlayerPrefs.SetInt("sumarzadkosciprzedmiotow",temp);
                Destroy(podniesionyprzedmiot);
                Hub.przyciskidoruszania=false;
                czyprzedmiotjestpodniesiony = false;
                podniesionyprzedmiot=null;
                heldDuration = 0f;
                Vibration.Vibrate(100, 250);
    }


}
