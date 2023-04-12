using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


[System.Serializable]
public class SceneData
{
    public string sceneName;
    public int buildIndex;

    public SceneData(string name, int index)
    {
        sceneName = name;
        buildIndex = index;
    }
}
public class islandchooserscirpt : MonoBehaviour
{
    public int islandnumber;
    private canvaschanger Canvaschanger;

    // Start is called before the first frame update
    void Start()
    {
        GameObject obj = GameObject.Find("Menager");
        Canvaschanger = obj.GetComponent<canvaschanger>();
    }

    void Update()
    {

    }

    public void switchtofirstisland()
    {
        if(islandnumber != 1)
        {
            Canvaschanger.switchtodefaultcanvas();
            SceneManager.LoadScene("1island");
        }
    }

    public void switchtosecondisland()
    {
        if(islandnumber != 2)
        {
            Canvaschanger.switchtodefaultcanvas();
            SceneManager.LoadScene("2island");
            
        }
    }

    public void switchtothirdisland()
    {
        if(islandnumber != 3)
        {
            Canvaschanger.switchtodefaultcanvas();
            SceneManager.LoadScene("3island");

            
        }
    }

    public void switchtofourthisland()
    {
        if(islandnumber != 4)
        {
            Canvaschanger.switchtodefaultcanvas();
            SceneManager.LoadScene("4island");

            
        }
    }

    public void switchtofifthisland()
    {
        if(islandnumber != 5)
        {
            Canvaschanger.switchtodefaultcanvas();
            SceneManager.LoadScene("5island");
        }
    }
}
