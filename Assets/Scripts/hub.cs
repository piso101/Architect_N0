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
            spawnuj(obiekspawnowania,false,levelporzebny);
        }
        moneyamount.text=(money).ToString("F1")+"$";
        moneyamoutskilltree.text=(money).ToString("F1")+"$";
        moneyshop.text=(money).ToString("F1")+"$";
    }
    bool wasitspawned=false;
    public void spawnuj(GameObject obiektdozespawnowania,bool zespawnuj,int levelrequired)
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
                                    wasitspawned=true;
                                }
                                else
                                {
                                    zespawowanyobiekt.transform.position =(hit.point+new Vector3(0f,0.8f,0f));
                                }
                            }
                        }
                    }
                    else if (Input.touchCount<1)
                    {
                        zespawowanyobiekt=null;
                        zespawnuj=false;
                        spawnujtak=false;
                    }
                    
                    
                }
            
            
        }
        
    }
}

