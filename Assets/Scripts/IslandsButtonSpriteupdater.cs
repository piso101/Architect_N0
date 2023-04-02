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
    if(Hub.level >=levelrequired)//if player has enough level to unlock island switch sprite to land
    {
        islandbtnimage.sprite = landimage;
        //set button to interactable true   
        islandbtnimage.GetComponent<Button>().interactable = true;
    }   
    else//if player doesnt have enough level to unlock island switch sprite to questionmark
    {
        islandbtnimage.sprite = questionmark;
        //set button to interactable false
        islandbtnimage.GetComponent<Button>().interactable = false;
    }
    }
}
