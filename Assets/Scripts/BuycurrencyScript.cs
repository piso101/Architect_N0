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
        double temp;
        temp=PlayerPrefs.GetFloat("wallet");
        
        //iftransactionisdone
        temp+=1000;
        PlayerPrefs.SetFloat("wallet", (float)temp); 
    }
    public void hasclickedtoaddmoney5dolar()
    {
        //iftransactionisdone
        double temp;
        temp=PlayerPrefs.GetFloat("wallet");
        temp+=10000;
        PlayerPrefs.SetFloat("wallet", (float)temp); 
    }
    public void hasclickedtoaddmoney10dolar()
    {
        //iftransactionisdone
        double temp;
        temp=PlayerPrefs.GetFloat("wallet");
        temp+=100000;
        PlayerPrefs.SetFloat("wallet", (float)temp); 
    }
}
