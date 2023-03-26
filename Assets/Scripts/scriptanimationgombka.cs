using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptanimationgombka : MonoBehaviour
{
    private hub Hub;
    public Animator anim;
    void Start()
    {
        GameObject obj = GameObject.Find("Menager");
        Hub = obj.GetComponent<hub>();
    }
    void Update() 
    {
        bool zagrajanimacje = Hub.animgombka;// always checking if variable has changed
        if(zagrajanimacje)
        {
            anim.SetBool("grajanimacjesponge",true);  //same shit there just turn on or off bool grajanimacjesponge(eng. play animation sponge) 
        }
        else anim.SetBool("grajanimacjesponge",false); 
         
    }
}
