using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class islandchooserscirpt : MonoBehaviour
{
    public int islandnumber;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void switchtofirstisland()
    {
        if(islandnumber != 1)
        {
        islandnumber = 1;
        }
    }
    public void switchtosecondisland()
    {
        if(islandnumber != 2)
        {
        islandnumber = 2;
        }

    }
    public void switchtothirdisland()
    {
        if(islandnumber != 3)
        {
        islandnumber = 3;
        }
    }
    public void switchtofourthisland()
    {
        if(islandnumber != 4)
        {
        islandnumber = 4;
        }
    }
    public void switchtofifthisland()
    {
        if(islandnumber != 5)
        {
        islandnumber = 5;
        }
    }
}
