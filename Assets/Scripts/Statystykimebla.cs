using System.Net;
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
    public Vector3 positionapply;
    public double time;
    private currencycontroller Currencycontroller;
    void Start() 
    {
        GameObject obj = GameObject.Find("Menager");
        Hub = obj.GetComponent<hub>();//cast to hub script
        if(czymebeljestaktywny == true)
        {
            int temp = PlayerPrefs.GetInt("sumarzadkosciprzedmiotow");
            temp += rzadkoscprzedmiotu;
            PlayerPrefs.SetInt("sumarzadkosciprzedmiotow", temp);
        }
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
    }
}
