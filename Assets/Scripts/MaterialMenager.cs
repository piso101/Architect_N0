using System.Runtime.ExceptionServices;
using System.Transactions;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;
using System.Security.Cryptography;
using System.ComponentModel.Design;
using System.Net;
using System.Diagnostics;
using UnityEngine;
using RDG;

public class MaterialMenager : MonoBehaviour
{
    private hub Hub;
    private Movingcleaninganim movingcleaninganim;
    private Movingcleaninganim movingpainting;
    public GameObject movewhenanimoff;
    float holdTime = 2f;
    float heldDuration = 0f;
    //
    float paintholdTime = 2f;
    float paintheldDuration = 0f;
    //
    public Material Material1;
    private scriptanimationgombka Scriptanimationgombka;
    private scriptanimationszczota Scriptanimationszczota;

    void Start()
    {
        GameObject obj = GameObject.Find("Menager");
        Hub = obj.GetComponent<hub>();
        GameObject movecleaninganim = GameObject.Find("Szczotagombkaparent");
        movingcleaninganim = movecleaninganim.GetComponent<Movingcleaninganim>();
        GameObject movepaintinganim = GameObject.Find("Farba i wiadro");
        movingpainting = movepaintinganim.GetComponent<Movingcleaninganim>();
    }
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit)&&hit.collider.gameObject.tag == "dirtywall"&& hit.collider.gameObject.GetComponent<MeshRenderer>().enabled)
            {
                if (hit.collider.gameObject.tag == "dirtywall")
                {
                    bool czyszczotka = Hub.szczotkajestwrece;
                    
                        if(heldDuration==0&&czyszczotka)
                    {
                        
                        movingcleaninganim.SetTargetObject(hit.collider.gameObject);
                        Hub.animszczotka = true;
                        Hub.animgombka = true;

                    }
                    Vibration.Vibrate(20,250);
                    heldDuration += Time.deltaTime;
                    
                    if (heldDuration >= holdTime&&czyszczotka)
                    {
                        hit.collider.gameObject.tag = "wall";
                        Renderer renderer = hit.collider.GetComponent<Renderer>();
                        if (renderer != null)
                        {
                            Vibration.Vibrate(100,150);
                            renderer.material = Material1;
                        }
                    }
                }
                else
                {
                    heldDuration = 0f;
                        Hub.animszczotka = false;
                        Hub.animgombka = false;
                        movingcleaninganim.SetTargetObject(movewhenanimoff);
                }
            }//malowanie sciany////////////////////////////////////////////////////////////////////////////////////
            else if (Physics.Raycast(ray, out hit)&&hit.collider.gameObject.tag == "wall"&& hit.collider.gameObject.GetComponent<MeshRenderer>().enabled)
            {
                if (hit.collider.gameObject.tag == "wall")
                {
                        if(paintheldDuration==0&&Hub.czykolorzostalwybrany&&!Hub.animszczotka&&!Hub.animgombka)
                    {
                        Hub.animmalowanie = true; 
                        movingpainting.SetTargetObject(hit.collider.gameObject);
                    }
                    paintheldDuration += Time.deltaTime;
                    Vibration.Vibrate(20,100);
                    if (paintheldDuration >= paintholdTime&&Hub.czykolorzostalwybrany)
                    {
                        Renderer renderer = hit.collider.GetComponent<Renderer>();
                        if (renderer != null)
                        {
                            renderer.material.color = Hub.paintcolor;
                            Vibration.Vibrate(100,200);
                            
                        }
                    }
                }
                else
                {
                    paintheldDuration = 0f;
                    Hub.animmalowanie = false; 
                    movingpainting.SetTargetObject(movewhenanimoff);
                }
            }
        }
        else
        {
            movingpainting.SetTargetObject(movewhenanimoff);
            movingcleaninganim.SetTargetObject(movewhenanimoff);
            Hub.animmalowanie = false; 
            Hub.animszczotka = false;
            Hub.animgombka = false;
            heldDuration = 0f;
            paintheldDuration=0f;
        }
    }
}

