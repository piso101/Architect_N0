using System.ComponentModel.Design;
using System.Net;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO.Enumeration;
using RDG;

public class luckywheelcanvasscript : MonoBehaviour
{
    public GameObject wheel;
    public GameObject wheelbutton;
    public TextMeshProUGUI vallettext;
    public TextMeshProUGUI costtext;
    private hub Hub;
    public GameObject wheeltarget;
    public TextMeshProUGUI prize;
    public bool adwatched = false;

    void Start()
    {
        Hub = GameObject.Find("Menager").GetComponent<hub>();
    }

    void Update()
    {
        vallettext.text = ("Wallet: ")+Hub.money.ToString("F1") + "$";
        costtext.text = ("Cost: ")+Hub.level*Hub.level*1000 + "$";//updating wallet and cost of spin after opening canvas of luckyspin
    }

    public void spinwheel()
    {   
        bool hasnotenoughmoney = Hub.money >= Hub.level*Hub.level*1000;
        if(!hasnotenoughmoney)//checks if player has enough money if not breaks function
        {
        wheel.GetComponent<WheelScript>().spinwheel();//this gets wheel to spin by calling to a function that rotates it
        wheelbutton.GetComponent<Button>().interactable = false;//turns of a button for a spining time
        Hub.money -= Hub.level*Hub.level*1000;
        StartCoroutine(CheckWheelSpinning());
        }
        else if (adwatched)
        {
        wheel.GetComponent<WheelScript>().spinwheel();//this gets wheel to spin by calling to a function that rotates it
        wheelbutton.GetComponent<Button>().interactable = false;//turns of a button for a spining time
        StartCoroutine(CheckWheelSpinning());
        adwatched = false;
        }
    }

    public IEnumerator CheckWheelSpinning()//checks if animation is done
    {
        bool isSpinning = true;
        while (isSpinning)
        {
            isSpinning = wheel.GetComponent<WheelScript>().isSpinning;
            yield return null;
        }
        EnableButton();
        CheckPrice();
    }

    void EnableButton()
    {
        wheelbutton.GetComponent<Button>().interactable = true;//turn on functions of a button
    }

    void CheckPrice()//checks what price has player done
    {
        float angle = wheel.transform.rotation.eulerAngles.z;
        // Round the angle to the nearest 45 degrees to determine the prize.
        int prizeIndex = Mathf.RoundToInt(angle / 36.0f) % 310;
        switch (prizeIndex)
        {
            case 10:
                prize.text = "You won prize 1";
                break;
            case 1:
                prize.text = "You won prize 2";
                break;
            case 2:
                prize.text = "You won prize 3";
                break;
            case 3: 
                prize.text = "You won prize 4";
                break;
            case 4:
                prize.text = "You won prize 5";
                break;
            case 5:
                prize.text = "You won prize 6";
                break;
            case 6:
                prize.text = "You won prize 7";
                break;
            case 7:
                prize.text = "You won prize 8";
                break;
            case 8:
                prize.text = "You won prize 9";
                break;
            case 9:
                prize.text = "You won prize 10";
                break;
        }
    }
}
