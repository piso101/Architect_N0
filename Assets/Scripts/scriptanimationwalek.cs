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
        bool zagrajanimacje = Hub.animmalowanie;// checks if animmalowanie(eng.animation of paiting) by casting variable zagrajanimacje(eng.playanimation) from hub
        if(zagrajanimacje)
        {
            anim.SetBool("animuj",true);  //in animator anim set bool animuj(eng.animate) to true to turn on animation
        }
        else anim.SetBool("animuj",false); // turn false if needed
    }
}
