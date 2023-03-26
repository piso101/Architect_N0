using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptanimationbucket : MonoBehaviour
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
        bool zagrajanimacje = Hub.animmalowanie;//checking if variable animmalowanie(eng.anim paitning) has changed
        if(zagrajanimacje)
        {
            anim.SetBool("animuj",true);  //csetin animuj inside of animator anim to true
        }
        else anim.SetBool("animuj",false); 
    }
}
