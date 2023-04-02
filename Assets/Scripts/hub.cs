using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using RDG;

public class hub : MonoBehaviour
{
    //hub uzywany jest jako miejsce do zmieniania ogolno dostepnych zmiennych
    //uzywane do czyszczenia
    public bool szczotkajestwrece=false;
    public bool animszczotka=false;
    public bool animgombka=false;
    //uzywane do malowania
    public bool animmalowanie=false;
    public bool czykolorjestwrece=false;
    public Color paintcolor;
    public bool malowac=false;
    public bool czykolorzostalwybrany=false;//zmienjaknaprawiszcolorpicker
    public bool nieruszajkamera=false;
    //movingobjects
    public bool przyciskidoruszania=false;
    //inne
    
    public int level=1;
    public Color buttoncolor;
    public double money=0;
    public TextMeshProUGUI moneyamount;
    public TextMeshProUGUI moneyamoutskilltree;
    public TextMeshProUGUI moneyshop;
    private canvaschanger Canvaschanger;
    public bool spawnujtak;
    public GameObject obiekspawnowania;
    public int levelporzebny;
    GameObject zespawowanyobiekt;
    public int cenaobiektu;
    public double multiplyer=1;
    void Start()
    {
        GameObject obj = GameObject.Find("Menager");
        Canvaschanger = obj.GetComponent<canvaschanger>();

    }

    void Update() 
    {
        if(spawnujtak) 
        {
            
            spawnuj(obiekspawnowania,true,levelporzebny);
        }
        else
        {
            wasitspawned = false;
            spawnuj(obiekspawnowania,false,levelporzebny);
        }
        moneyamount.text=(money).ToString("F1")+"$";
        moneyamoutskilltree.text=(money).ToString("F1")+"$";
        moneyshop.text=(money).ToString("F1")+"$";
    }
    bool wasitspawned=false;
    public void spawnuj(GameObject obiektdozespawnowania,bool zespawnuj,int levelrequired)//this script basicly spawns object dragged from shop and checks if can be placed
    {
        if(money>=cenaobiektu)
        {
            if(zespawnuj)
            {
                if(level>=levelrequired)
                {
                        if(Input.touchCount==1)
                        {
                            Canvaschanger.switchtodefaultcanvas();
                            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                            RaycastHit hit;
                            if(Physics.Raycast(ray, out hit))
                            {
                                if(hit.transform.GetComponent<Collider>().tag == "floor")
                                {
                                    if(!wasitspawned)
                                    {
                                        
                                        zespawowanyobiekt = Instantiate(obiektdozespawnowania, (hit.point+new Vector3(0f,0.8f,0f)), obiektdozespawnowania.transform.rotation);
                                        //this has a bug in which object is not spawned and game basicly freeze
                                        wasitspawned=true;
                                        zespawowanyobiekt.tag ="ruszam";
                                        money-=cenaobiektu;
                                        Vibration.Vibrate(25, 150);
                                        Statystykimebla statystykimebla = zespawowanyobiekt.GetComponent<Statystykimebla>();
                                        statystykimebla.czymebeljestaktywny=true;
                                        Renderer objectRenderer = zespawowanyobiekt.GetComponent<Renderer>();
                                        Vector3 size = (objectRenderer.bounds.size / 3f)*statystykimebla.sizemultiplyier;
                                        Vector3 center = zespawowanyobiekt.transform.position;
                                        Quaternion rotation = zespawowanyobiekt.transform.rotation;
                                        Collider[] colliders = Physics.OverlapBox(center, size, rotation );
                                        foreach (Collider collider in colliders)
                                        {
                                            if (collider.gameObject.CompareTag("wall") || collider.gameObject.CompareTag("furniture") || collider.gameObject.CompareTag("dirtywall")||collider.gameObject.CompareTag("sceneria"))
                                            {
                                                
                                                Vibration.Vibrate(100, 100);
                                                Destroy(zespawowanyobiekt);
                                                zespawowanyobiekt=null;
                                                money+=cenaobiektu;
                                                wasitspawned=false;
                                                break;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Vector3 wtomstronke =(hit.point+new Vector3(0f,0.8f,0f));
                                        Vector3 temp = zespawowanyobiekt.transform.position;
                                        zespawowanyobiekt.transform.position = wtomstronke;
                                        
                                        Vibration.Vibrate(25, 150);
                                        Statystykimebla statystykimebla = zespawowanyobiekt.GetComponent<Statystykimebla>();
                                        // Check for collisions
                                        Renderer objectRenderer = zespawowanyobiekt.GetComponent<Renderer>();
                                        Vector3 size = (objectRenderer.bounds.size / 3f)*statystykimebla.sizemultiplyier;
                                        Vector3 center = zespawowanyobiekt.transform.position;
                                        Quaternion rotation = zespawowanyobiekt.transform.rotation;
                                        rotation *= Quaternion.Euler(statystykimebla.rotationaplly);
                                        // OverlapBox that fits into the object's convex shape
                                        Collider[] colliders = Physics.OverlapBox(center, size, rotation );
                                        foreach (Collider collider in colliders)
                                        {
                                            // Check if colliding with wall, furniture, or dirtywall
                                            if (collider.gameObject.CompareTag("wall") || collider.gameObject.CompareTag("furniture") || collider.gameObject.CompareTag("dirtywall")||collider.gameObject.CompareTag("sceneria"))
                                            {
                                                Vibration.Vibrate(100, 100);
                                                zespawowanyobiekt.transform.position = temp;
                                                break;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else if (Input.touchCount<1)
                        {
                            zespawowanyobiekt.tag ="furniture";
                            zespawowanyobiekt=null;
                            zespawnuj=false;
                            wasitspawned=false;
                            spawnujtak=false;
                        }
                }
            }
        }
    }
}

