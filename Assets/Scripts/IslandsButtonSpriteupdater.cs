using System.Net.Mime;
using System.ComponentModel.Design;
using System.Net;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IslandsButtonSpriteupdater : MonoBehaviour
{
    public Sprite landimage;
    public Sprite questionmark;
    private hub Hub;
    public Image islandbtnimage;
    public int levelrequired;
    // Start is called before the first frame update
    void Start()
    {
        Hub = GameObject.Find("Menager").GetComponent<hub>();
    }

    // Update is called once per frame
    void Update()
    {
    if(Hub.level >=levelrequired)
    {
        islandbtnimage.sprite = landimage;
    }   
    else
    {
        islandbtnimage.sprite = questionmark;
    }
    }
}
