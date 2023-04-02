using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Levelskilltree : MonoBehaviour
{
    private hub Hub;
    public Sprite level1;
    public Sprite level2;
    public Sprite level3;
    public Sprite level4;
    public Sprite level5;
    public Image background;
    // Start is called before the first frame update
    void Start()
    {
        GameObject obj = GameObject.Find("Menager");
        Hub = obj.GetComponent<hub>();
    }

    // Update is called once per frame
    void Update()//based on level that player is curently on swiches background of a skilltree
    {
        int level = PlayerPrefs.GetInt("level");
        switch (level)
        {
            case 1:
            {
                background.sprite = level1;
                break;
            }
            case 2:
            {
                background.sprite = level2;
                break;
            }
            case 3:
            {
                background.sprite = level3;
                break;
            }
            case 4:
            {
                background.sprite = level4;
                break;
            }
            case 5:
            {
                background.sprite = level5;
                break;
            }
        }
    }
}
