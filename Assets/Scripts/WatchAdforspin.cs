using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WatchAdforspin : MonoBehaviour
{
    public GameObject luckywheelcall;
    private luckywheelcanvasscript luckywheelcanvasscript;
    // Start is called before the first frame update
    void Start()
    {
        luckywheelcanvasscript = luckywheelcall.GetComponent<luckywheelcanvasscript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void buttonforadpressed()
    {
        //show ad
        //if ad is watched
        luckywheelcanvasscript.adwatched = true;//spin the wheel
    }
}
