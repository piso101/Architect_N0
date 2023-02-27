using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hub : MonoBehaviour
{
    public bool szczotkajestwrece=false;
    // Start is called before the first frame update
    void Start()
    {
        
    }
        void OnGUI()
    {
        // Define the position(y,x) and size of the button
        Rect buttonRect = new Rect(500,300, 100, 50);

        // Draw the button
        if (GUI.Button(buttonRect, "Szczotka"))
        {
            // Do something when the button is clicked
           if(szczotkajestwrece)
           {
            szczotkajestwrece=false;
           }
           else
           {
            szczotkajestwrece=true;
           }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
