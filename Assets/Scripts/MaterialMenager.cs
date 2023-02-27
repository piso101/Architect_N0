using System.Diagnostics;
using UnityEngine;

public class MaterialMenager : MonoBehaviour
{
    private hub Hub;
    float holdTime = 2f;
    float heldDuration = 0f;
    public Material Material1;
    void Start()
    {
        GameObject obj = GameObject.Find("Menager");
        Hub = obj.GetComponent<hub>();
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
                    heldDuration += Time.deltaTime;
                    bool czyszczotka = Hub.szczotkajestwrece;
                    if (heldDuration >= holdTime&&czyszczotka)
                    {
                        hit.collider.gameObject.tag = "wall";
                                        Renderer renderer = hit.collider.GetComponent<Renderer>();
                        if (renderer != null)
                        {
                            renderer.material = Material1;
                        }
                        //UnityEngine.Debug.Log("Zmieniono tag na wall"+ hit.collider.gameObject.name);
                    }
                }
                else
                {
                    heldDuration = 0f;
                }
            }
        }
        else
        {
            heldDuration = 0f;
        }
    }
}

