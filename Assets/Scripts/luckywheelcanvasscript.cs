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
    private hub Hub;
    public GameObject wheeltarget;

    void Start()
    {
        Hub = GameObject.Find("Menager").GetComponent<hub>();
    }

    void Update()
    {
        vallettext.text = Hub.money.ToString("F1") + "$";
    }

    public void spinwheel()
    {
        wheel.GetComponent<WheelScript>().spinwheel();
        wheelbutton.GetComponent<Button>().interactable = false;
        Hub.money -= 1000;
        StartCoroutine(CheckWheelSpinning());
    }

    public IEnumerator CheckWheelSpinning()
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
        wheelbutton.GetComponent<Button>().interactable = true;
    }

    void CheckPrice()
    {
        float angle = wheeltarget.transform.eulerAngles.z;
        // Round the angle to the nearest 45 degrees to determine the prize.
        int prizeIndex = Mathf.RoundToInt(angle / 36.0f) % 8;
        switch (prizeIndex)
        {
            
            case 0:
                Debug.Log("You won prize 1");
                break;
            case 1:
                Debug.Log("You won prize 2");
                break;
            case 2:
                Debug.Log("You won prize 3");
                break;
            case 3: 
                Debug.Log("You won prize 4");
                break;
            case 4:
                Debug.Log("You won prize 5");
                break;
            case 5:
                Debug.Log("You won prize 6");
                break;
            case 6:
                Debug.Log("You won prize 7");
                break;
            case 7:
                Debug.Log("You won prize 8");
                break;
            case 8:
                Debug.Log("You won prize 9");
                break;
            case 9:
                Debug.Log("You won prize 10");
                break;
        }
    }
}
