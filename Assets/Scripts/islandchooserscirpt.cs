using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        SceneManager.LoadScene("1island");
        }
    }
    public void switchtosecondisland()
    {
        if(islandnumber != 2)
        {
        SceneManager.LoadScene("2island");
        }
    }
    public void switchtothirdisland()
    {
        if(islandnumber != 3)
        {
        SceneManager.LoadScene("3island");
        }
    }
    public void switchtofourthisland()
    {
        if(islandnumber != 4)
        {
        SceneManager.LoadScene("4island");
        }
    }
    public void switchtofifthisland()
    {
        if(islandnumber != 5)
        {
        SceneManager.LoadScene("5island");
        }
    }
}
