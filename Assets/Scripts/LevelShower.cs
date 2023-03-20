using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelShower : MonoBehaviour
{
    private hub Hub;
    public Texture2D odznaka1;
    public Texture2D odznaka2;
    public Texture2D odznaka3;
    public Texture2D odznaka4;
    public Texture2D odznaka5;
    public RawImage ramkanaodznaki;
    // Start is called before the first frame update
    void Start()
    {
        GameObject obj = GameObject.Find("Menager");
        Hub = obj.GetComponent<hub>();  
    }

    // Update is called once per frame
    void Update()
    {
        int levelshower = Hub.level;
        if(levelshower == 1)
        {
        ramkanaodznaki.texture=odznaka1;
        }
        else if (levelshower == 2)
        {
         ramkanaodznaki.texture=odznaka2;
        }
        else if (levelshower == 3)
        {
        ramkanaodznaki.texture=odznaka3;
        }
        else if (levelshower == 4)
        {
        ramkanaodznaki.texture=odznaka4;
        }
        else if (levelshower == 5)
        {
        ramkanaodznaki.texture=odznaka5;
        }
    }
}

