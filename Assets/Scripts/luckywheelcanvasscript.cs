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
    public Sprite normalprize;
    public Sprite goodprize;
    public GameObject prizeinfo;
    public GameObject prizeinfoimage;
    public TextMeshProUGUI prizeinfotext;
    bool isnextspinfree = false;

    void Start()
    {
        prizeinfo.SetActive(false);
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

        if (adwatched)
        {
        wheel.GetComponent<WheelScript>().spinwheel();//this gets wheel to spin by calling to a function that rotates it
        wheelbutton.GetComponent<Button>().interactable = false;//turns of a button for a spining time
        StartCoroutine(CheckWheelSpinning());
        adwatched = false;
        }
        else if (isnextspinfree)
        {
        wheel.GetComponent<WheelScript>().spinwheel();//this gets wheel to spin by calling to a function that rotates it
        wheelbutton.GetComponent<Button>().interactable = false;//turns of a button for a spining time
        StartCoroutine(CheckWheelSpinning());
        isnextspinfree = false;
        }
        else if(hasnotenoughmoney)//checks if player has enough money if not breaks function
        {
        wheel.GetComponent<WheelScript>().spinwheel();//this gets wheel to spin by calling to a function that rotates it
        wheelbutton.GetComponent<Button>().interactable = false;//turns of a button for a spining time
        Hub.money -= Hub.level*Hub.level*1000;
        StartCoroutine(CheckWheelSpinning());
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
            case 0:
                Hub.money += 300;
                prizeinfo.SetActive(true);
                prizeinfoimage.GetComponent<Image>().sprite = normalprize;
                prizeinfotext.text = "300$";
                break;
            case 10://prize 300$
                Hub.money += 300;
                prizeinfo.SetActive(true);
                prizeinfoimage.GetComponent<Image>().sprite = normalprize;
                prizeinfotext.text = "300$";
                break;
            case 1://prize 1000$
                Hub.money += 1000;
                prizeinfo.SetActive(true);
                prizeinfoimage.GetComponent<Image>().sprite = normalprize;
                prizeinfotext.text = "1000$";
                break;
            case 2://prize 1.5x 60sec
                prizeinfo.SetActive(true);
                Hub.multiplyer=1;
                Hub.multiplyer=1.5;
                prizeinfoimage.GetComponent<Image>().sprite = goodprize;
                prizeinfotext.text = "1.5x 60sec";
                break;
            case 3: // 1000$
                Hub.money += 1000;
                prizeinfo.SetActive(true);
                prizeinfoimage.GetComponent<Image>().sprite = normalprize;
                prizeinfotext.text = "1000$";
                break;
            case 4://prize 2x 60sec
                prizeinfo.SetActive(true);
                Hub.multiplyer=1;
                Hub.multiplyer=2;
                prizeinfoimage.GetComponent<Image>().sprite = goodprize;
                prizeinfotext.text = "2x 60sec";
                break;
            case 5://respin
                isnextspinfree = true;
                prizeinfo.SetActive(true);
                prizeinfoimage.GetComponent<Image>().sprite = normalprize;
                prizeinfotext.text = "Respin";
                break;
            case 6://100$
                Hub.money += 100;
                prizeinfo.SetActive(true);
                prizeinfoimage.GetComponent<Image>().sprite = normalprize;
                prizeinfotext.text = "100$";
                break;
            case 7://limited furniture
                prizeinfo.SetActive(true);
                prizeinfoimage.GetComponent<Image>().sprite = goodprize;
                prizeinfotext.text = "Limited furniture";
                break;
            case 8:// 5000$
                Hub.money += 5000;
                prizeinfo.SetActive(true);
                prizeinfoimage.GetComponent<Image>().sprite = normalprize;
                prizeinfotext.text = "5000$";
                break;
            case 9://2x wallet
                Hub.money *= 2;
                prizeinfo.SetActive(true);
                prizeinfoimage.GetComponent<Image>().sprite = goodprize;
                prizeinfotext.text = "2x wallet";
                break;
        }
    }
    public void closepriceinfo()
    {
        prizeinfo.SetActive(false);
    }
}
