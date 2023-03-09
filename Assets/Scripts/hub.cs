using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public bool czykolorzostalwybrany=false;//zmienjaknaprawiszcolorpicker
    public bool nieruszajkamera=false;
    //movingobjects
    public bool przyciskidoruszania=false;
    //inne
    public Color buttoncolor;
    void Start()
    {

    }

    void Update() 
    {

    }
}

