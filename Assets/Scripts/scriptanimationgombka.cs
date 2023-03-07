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
        bool zagrajanimacje = Hub.animgombka;
        if(zagrajanimacje)
        {
            anim.SetBool("grajanimacjesponge",true);  
        }
        else anim.SetBool("grajanimacjesponge",false); 
         
    }
}
