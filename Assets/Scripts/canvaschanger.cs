using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RDG;

public class canvaschanger : MonoBehaviour
{
    public GameObject defaultcanvas;
    public GameObject skilltree;
    public GameObject shopcanvas;
    private hub Hub;
    // Start is called before the first frame update
    void Start()
    {
        defaultcanvas.SetActive(true);
        skilltree.SetActive(false);
        shopcanvas.SetActive(false);
        GameObject obj = GameObject.Find("Menager");
        Hub = obj.GetComponent<hub>();
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    void levelupodczucie()
    {
        Vibration.Vibrate(100, 100);
        Vibration.Vibrate(50, 100);//jakasmuzyczka czy jakas animacja fajna by byla tu
        Vibration.Vibrate(150, 50);
    }
    public void upgradebtn()
    {
      if(Hub.level==1)
      {
        if(Hub.money >= 1000)
        {
            Hub.level = 2;
            Hub.money-=1000;
            levelupodczucie();
        }
      }
      else if(Hub.level==2)
      {
        if(Hub.money >= 10000)
        {
            Hub.level =3;
            levelupodczucie();
            Hub.money-=10000;
        }
      }
      else if(Hub.level==3)
      {
        if(Hub.money >= 100000)
        {
            Hub.level = 4;
            levelupodczucie();
            Hub.money-=100000;
        }
      }
      else if(Hub.level==4)
      {
        if(Hub.money >= 1000000)
        {
            Hub.level = 5;
            levelupodczucie();
            Hub.money-=1000000;
        }
      }
    }
    public void switchtoskilltree()
    {
        defaultcanvas.SetActive(false);
        skilltree.SetActive(true);
        shopcanvas.SetActive(false);

    }
    public void switchtodefaultcanvas()
    {
        defaultcanvas.SetActive(true);
        skilltree.SetActive(false);
        shopcanvas.SetActive(false);
    }
    public void switchtoshopcanvas()
    {
        defaultcanvas.SetActive(false);
        skilltree.SetActive(false);
        shopcanvas.SetActive(true);
    }
}
