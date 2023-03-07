using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptanimationszczota : MonoBehaviour
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
        bool zagrajanimacje = Hub.animszczotka;
        if(zagrajanimacje)
        {
            anim.SetBool("zagrajanimacje",true);  
        }
        else anim.SetBool("zagrajanimacje",false); 
    }
}
