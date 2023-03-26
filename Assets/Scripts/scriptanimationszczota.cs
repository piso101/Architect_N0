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
        bool zagrajanimacje = Hub.animszczotka;//checks if variable animszczotka(eng. anim broom) has changed
        if(zagrajanimacje)
        {
            anim.SetBool("zagrajanimacje",true);  //setting bool inside of animator to true zagrajanimacje(eng.play animation)
        }
        else anim.SetBool("zagrajanimacje",false); //set false when needed
    }
}
