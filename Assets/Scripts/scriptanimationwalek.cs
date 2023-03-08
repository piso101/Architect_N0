using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptanimationwalek : MonoBehaviour
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
        bool zagrajanimacje = Hub.animmalowanie;
        if(zagrajanimacje)
        {
            anim.SetBool("animuj",true);  
        }
        else anim.SetBool("animuj",false); 
         
    }
}
