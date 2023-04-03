using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using RDG;


public class shopgameobjectbtn : MonoBehaviour
{
    public GameObject objects;
    public Sprite imageofbuttonwithobject;
    public Sprite imagetochangewhenudonthavelevel;
    public Image image;
    public string objectname;
    public int value;
    public int level;
    public int levelrequired;//set public values only in inspector not here by adding script to button that is in context in shopping canvas
    public TextMeshProUGUI Textofobjectname;
    public TextMeshProUGUI textofvalue;
    public TextMeshProUGUI Textoflevel;
    public TextMeshProUGUI Textofearnings;
    private hub Hub;
    private canvaschanger Canvaschanger;
    public bool czydraguje;
    
    // Start is called before the first frame update
    void Start()
    {
        GameObject obj = GameObject.Find("Menager");
        Hub = obj.GetComponent<hub>();
        Canvaschanger = obj.GetComponent<canvaschanger>();
        image.sprite=imageofbuttonwithobject;
        disablewholeimage();
        disableallvalues();//at the start of game disable all of values and sprites of those buttons
    }

    // Update is called once per frame
    void Update()
    {
        if(Hub.level>=levelrequired)
        {
            setallvalues();//if player has level required or more show those sprites and values of the item in the shop
            enablewholeimage();
        }
    }
    void disablewholeimage()//also changes its image to misterious
    {
        image.sprite = imagetochangewhenudonthavelevel;
        foreach (Transform child in image.transform)
        {
            child.gameObject.SetActive(false);
        }
        
    }
    void enablewholeimage()//also changes its image to misterious
    {
        image.sprite = imageofbuttonwithobject;
        foreach (Transform child in image.transform)
        {
            child.gameObject.SetActive(true);
        }
        
        
    }
    void setallvalues()
    {
        Textoflevel.text=level.ToString();
        Textofobjectname.text=objectname;
        textofvalue.text=value.ToString()+"$";
        Textofearnings.text=(value).ToString()+"$/min";
    }
    void disableallvalues()
    {
        Textoflevel.text="";
        Textofobjectname.text="";
        textofvalue.text="";
        Textofearnings.text="";
    }
    public void takdraguje()//takdraguje(eng.yesdragging)checks if player is dragging the button.
    {
        if(Hub.money>=value)
        {        
        Hub.obiekspawnowania = objects;
        Hub.levelporzebny = levelrequired;
        Hub.cenaobiektu = value;
        Hub.spawnujtak = true;
        }
        
    }

}
