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
    public double time;
    void Start() 
    {
        GameObject obj = GameObject.Find("Menager");
        Hub = obj.GetComponent<hub>();//cast to hub script
    }
    void Update()
    {
        if(Hub.multiplyer>1)
        {
            if(time<60)
            {
                time+=Time.deltaTime;
            }
            else 
            {
                Hub.multiplyer=1;
                time=0;
            }
        }
        
        if(czymebeljestaktywny==true)//czymebeljestaktywny(eng.isfurnitureactive)
        {

                Hub.money+=rzadkoscprzedmiotu*0.028*Hub.multiplyer; //add to the whole money count of money rzadkoscprzedmiotu(eng.rarityofitem)multiplied by 0.028 so it is for example 100$/min
        }
        
    }
}
