using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BuycurrencyScript : MonoBehaviour
{
    private hub Hub;
    public TextMeshProUGUI walletvalue;
    // Start is called before the first frame update
    void Start()
    {
        GameObject obj = GameObject.Find("Menager");
        Hub = obj.GetComponent<hub>();
    }

    // Update is called once per frame
    void Update()
    {
        walletvalue.text = Hub.money.ToString();
    }
    public void hasclickedtoaddmoney1dolar()
    {
        
        //iftransactionisdone
        Hub.money+=1000;
    }
    public void hasclickedtoaddmoney5dolar()
    {
        //iftransactionisdone
        Hub.money+=10000;
        
    }
    public void hasclickedtoaddmoney10dolar()
    {
        //iftransactionisdone
        Hub.money+=500000;
        
    }
}
