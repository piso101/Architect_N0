using System.Security.Principal;
using System.Threading;
using System.Security.Cryptography;
using System.ComponentModel.Design;
using System.Net;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class currencycontroller : MonoBehaviour
{ 
    private hub Hub;
    double time;
    // Start is called before the first frame update
    void Start()
    {
        GameObject obj = GameObject.Find("Menager");
        Hub = obj.GetComponent<hub>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Hub.multiplyer>1)
        {
                double temp = PlayerPrefs.GetInt("sumarzadkosciprzedmiotow");
                temp=(((temp*100)*Hub.multiplyer)/1440);
                temp+=PlayerPrefs.GetFloat("wallet");
                PlayerPrefs.SetFloat("wallet", (float)temp);
                Hub.multiplyer=1;

        }
        else
        {
            double temp = PlayerPrefs.GetInt("sumarzadkosciprzedmiotow");
            temp=(temp*100)/1440;
            temp+=PlayerPrefs.GetFloat("wallet");
            PlayerPrefs.SetFloat("wallet", (float)temp);
        }
    }
}
