using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Statystykimebla : MonoBehaviour
{
    private hub Hub;
    public int rzadkoscprzedmiotu;
    public string nazwaobiektu;
    public bool czymebeljestaktywny=true;
    public float sizemultiplyier;
    public Vector3 rotationaplly;
    void Start() 
    {
        GameObject obj = GameObject.Find("Menager");
        Hub = obj.GetComponent<hub>();
    }
    void Update()
    {
        
        
        if(czymebeljestaktywny==true)
        {
            Hub.money+=(rzadkoscprzedmiotu);
        }
        
    }
}
