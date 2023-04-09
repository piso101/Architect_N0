using System.Runtime.CompilerServices;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using RDG;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

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

    void load()
        {
        string[] files = Directory.GetFiles(Application.persistentDataPath, "*.furniture");

                foreach (string file in files)
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    FileStream stream = new FileStream(file, FileMode.Open);
                    Classforsavingdatafurnitures data = formatter.Deserialize(stream) as Classforsavingdatafurnitures;
                    stream.Close();

                    // Create game object from prefab
                    GameObject prefab = Resources.Load<GameObject>(data.nameofprefab);
                    if (prefab != null)
                    {
                        GameObject obj = Instantiate(prefab, new Vector3(data.position[0], data.position[1], data.position[2]), Quaternion.Euler(data.rotation[0], data.rotation[1], data.rotation[2]));
                        obj.name = data.nameofobject;
                        // You can customize the instantiated game object further, such as setting its properties or adding components
                    }
                    else
                    {
                       Vibration.Vibrate(25, 150);
                    }
                }

        }
    void Start()
    {
        load();
        GameObject obj = GameObject.Find("Menager");
        Canvaschanger = obj.GetComponent<canvaschanger>();
    }

    void Update() 
    {
        int temp = PlayerPrefs.GetInt("level");
        money=PlayerPrefs.GetFloat("wallet");
        if(temp>level)
        {
            level=temp;
        }
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
                    Canvaschanger.switchtodefaultcanvas();
                        if(Input.touchCount==1)
                        {
                            
                            
                            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                            RaycastHit hit;
                            if(Physics.Raycast(ray, out hit))
                            {
                                if(hit.transform.GetComponent<Collider>().tag == "floor")
                                {
                                    Statystykimebla statystykimeblaprzedspawnowaniem = obiektdozespawnowania.GetComponent<Statystykimebla>();
                                    if(!wasitspawned)
                                    {
                                        
                                        zespawowanyobiekt = Instantiate(obiektdozespawnowania, (hit.point+new Vector3(0f,0.8f,0f)+statystykimeblaprzedspawnowaniem.positionapply), obiektdozespawnowania.transform.rotation);
                                        //this has a bug in which object is not spawned and game basicly freeze
                                        wasitspawned=true;
                                        zespawowanyobiekt.tag ="ruszam";
                                        money-=cenaobiektu;
                                        PlayerPrefs.SetFloat("wallet",(float)money);
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
                                                PlayerPrefs.SetFloat("wallet",(float)money);
                                                wasitspawned=false;
                                                break;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Vector3 wtomstronke =(hit.point+new Vector3(0f,0.8f,0f)+statystykimeblaprzedspawnowaniem.positionapply);
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

