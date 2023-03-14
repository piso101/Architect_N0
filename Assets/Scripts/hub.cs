using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class hub : MonoBehaviour
{
    //hub uzywany jest jako miejsce do zmieniania ogolno dostepnych zmiennych
    //uzywane do czyszczenia
    public bool szczotkajestwrece=false;
    public bool animszczotka=false;
    public bool animgombka=false;
    //uzywane do malowania
    public bool animmalowanie=false;
    public bool czykolorjestwrece=false;
    public Color paintcolor;
    public bool malowac=false;
    public bool czykolorzostalwybrany=false;//zmienjaknaprawiszcolorpicker
    public bool nieruszajkamera=false;
    //movingobjects
    public bool przyciskidoruszania=false;
    //inne
    public Color buttoncolor;
    public double money=0;
    public TextMeshProUGUI moneyamount;
    void Start()
    {

    }

    void Update() 
    {

        moneyamount.text=(money/36).ToString("F1")+"$";
    }
}

