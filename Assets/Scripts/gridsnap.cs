using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gridsnap : MonoBehaviour
{
    public string furnituretag;
    public Vector3 podnoszeniemebli;
    float holdTime = 0.5f;
    float heldDuration=0f;
    bool czyprzedmiotjestpodniesiony=false;
    public GameObject podniesionyprzedmiot;
    private hub Hub;

    void Start()
    {
        GameObject obj = GameObject.Find("Menager");
        Hub = obj.GetComponent<hub>();
    }
    void Update()
    {
    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    RaycastHit hit;
        if((Physics.Raycast(ray, out hit))&&hit.collider.gameObject.tag == furnituretag&&Input.GetMouseButton(0))
        {
            heldDuration +=Time.deltaTime;
            if(heldDuration>=holdTime&&!czyprzedmiotjestpodniesiony)
            {
                Hub.przyciskidoruszania=true;
                czyprzedmiotjestpodniesiony = true;
                podniesionyprzedmiot=hit.transform.gameObject;
                hit.transform.position=hit.transform.position+podnoszeniemebli;
                heldDuration = 0f;
            }
            else if(heldDuration>=holdTime&&czyprzedmiotjestpodniesiony)
            {
                Hub.przyciskidoruszania=false;
                czyprzedmiotjestpodniesiony = false;
                hit.transform.position=hit.transform.position-podnoszeniemebli;
                podniesionyprzedmiot=null;
                heldDuration = 0f;
            }
        }
    }
    float iksint;
    public void iks(float i)
    {
        iksint =i;
    }
    float igryk;
        public void igrek(float i)
    {
        igryk =i;
    }
    float zet;
        public void zent(float i)
    {
        zet =i;
    }
    public void polaczdoruszania()
    {
        Vector3 wtomstronke = new Vector3(iksint, igryk, zet);
        ruszaj(wtomstronke);
    }
    
    public void ruszaj(Vector3 wtomstronke)
    {
        

        // Move the object
        podniesionyprzedmiot.transform.position += wtomstronke;
        podniesionyprzedmiot.tag ="ruszam";

        // Check for collisions
        Renderer objectRenderer = podniesionyprzedmiot.GetComponent<Renderer>();
        float radius = objectRenderer.bounds.size.magnitude / 3f;
        Vector3 center = podniesionyprzedmiot.transform.position;
        Collider[] colliders = Physics.OverlapSphere(center, radius);
        foreach (Collider collider in colliders)
        {
            if (collider.gameObject.CompareTag("wall") || collider.gameObject.CompareTag("furniture")||collider.gameObject.CompareTag("dirtywall"))
            {
                podniesionyprzedmiot.transform.position-= wtomstronke;
            }
        }
        podniesionyprzedmiot.tag ="furniture";
    
    }
    public void obracajmnie()
{
    Vector3 wtomstronke = new Vector3(0f, 0f, 90f);

    // Rotate the object
    Quaternion rotation = Quaternion.Euler(wtomstronke);
    podniesionyprzedmiot.transform.rotation *= rotation;
    podniesionyprzedmiot.tag = "ruszam";

    // Check for collisions
    Renderer objectRenderer = podniesionyprzedmiot.GetComponent<Renderer>();
    float radius = objectRenderer.bounds.size.magnitude / 3f;
    Vector3 center = podniesionyprzedmiot.transform.position;
    Collider[] colliders = Physics.OverlapSphere(center, radius);
    foreach (Collider collider in colliders)
    {
        if (collider.gameObject.CompareTag("wall") || collider.gameObject.CompareTag("furniture")||collider.gameObject.CompareTag("dirtywall"))
        {
            // Rotate the object back if there is a collision
            podniesionyprzedmiot.transform.rotation *= Quaternion.Euler(-wtomstronke);
        }
    }
    podniesionyprzedmiot.tag = "furniture";
}
    public void usungo()
    {
                Destroy(podniesionyprzedmiot);
                Hub.przyciskidoruszania=false;
                czyprzedmiotjestpodniesiony = false;
                podniesionyprzedmiot=null;
                heldDuration = 0f;
    }


}
