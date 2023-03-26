using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Statystykimebla : MonoBehaviour
{
    private hub Hub;
    public int rzadkoscprzedmiotu;
    public string nazwaobiektu;
    public bool czymebeljestaktywny=true;// values for each furnitrue should be applied only in inspector!!!
    public float sizemultiplyier;
    public Vector3 rotationaplly;
    void Start() 
    {
        GameObject obj = GameObject.Find("Menager");
        Hub = obj.GetComponent<hub>();//cast to hub script
    }
    void Update()
    {
        
        
        if(czymebeljestaktywny==true)//czymebeljestaktywny(eng.isfurnitureactive)
        {

                Hub.money+=rzadkoscprzedmiotu*0.028; //add to the whole money count of money rzadkoscprzedmiotu(eng.rarityofitem)multiplied by 0.028 so it is for example 100$/min
        }
        
    }
}
