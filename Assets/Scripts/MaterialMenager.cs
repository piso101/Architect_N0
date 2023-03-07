using System.Diagnostics;
using UnityEngine;

public class MaterialMenager : MonoBehaviour
{
    private hub Hub;
    private Movingcleaninganim movingcleaninganim;
    float holdTime = 2f;
    float heldDuration = 0f;
    public Material Material1;
    private scriptanimationgombka Scriptanimationgombka;
    private scriptanimationszczota Scriptanimationszczota;

    void Start()
    {
        GameObject obj = GameObject.Find("Menager");
        Hub = obj.GetComponent<hub>();
        GameObject movecleaninganim = GameObject.Find("Szczotagombkaparent");
        movingcleaninganim = movecleaninganim.GetComponent<Movingcleaninganim>();
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
                    heldDuration += Time.deltaTime;
                    
                    if (heldDuration >= holdTime&&czyszczotka)
                    {
                        hit.collider.gameObject.tag = "wall";
                        Renderer renderer = hit.collider.GetComponent<Renderer>();
                        if (renderer != null)
                        {
                            renderer.material = Material1;
                        }
                    }
                }
                else
                {
                    heldDuration = 0f;
                        Hub.animszczotka = false;
                        Hub.animgombka = false;
                }
            }
        }
        else
        {
            Hub.animszczotka = false;
            Hub.animgombka = false;
            heldDuration = 0f;
        }
    }
}

