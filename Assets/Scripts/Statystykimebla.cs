using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Statystykimebla : MonoBehaviour
{
    private hub Hub;
    public int rzadkoscprzedmiotu;
    public string nazwaobiektu;
    public bool czymebeljestaktywny = true; // values for each furnitrue should be applied only in inspector!!!
    public float sizemultiplyier;
    public Vector3 rotationaplly;
    public Vector3 positionapply;
    public Vector3 centerapply;
    public Vector3 scaleapply;
    public double time;
    public double timetosave;
    //saving data 
    public Vector3 position;
    public Vector3 rotation;
    public GameObject prefab;
    public string gameobjectstring;
    private currencycontroller Currencycontroller;

    void Start()
    {
        GameObject obj = GameObject.Find("Menager");
        Hub = obj.GetComponent<hub>(); //cast to hub script
        if (czymebeljestaktywny == true)
        {
            int temp = PlayerPrefs.GetInt("sumarzadkosciprzedmiotow");
            temp += rzadkoscprzedmiotu;
            PlayerPrefs.SetInt("sumarzadkosciprzedmiotow", temp);
        }

        gameobjectstring = gameObject.name;
    }

    void Update()
    {Savingandloadingfurniture.SaveFurniture(this);


        position = transform.position;
        rotation = transform.rotation.eulerAngles;

        if (Hub.multiplyer > 1)
        {
            if (time < 60)
            {
                time += Time.deltaTime;
            }
            else
            {
                Hub.multiplyer = 1;
                time = 0;
            }
        }
    }
}

