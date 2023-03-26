using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movingcleaninganim : MonoBehaviour
{
    public GameObject objectToMove;
    private Transform targetObject;
    public Vector3 positionOffset;
    public Vector3 rotationOffset;
    
    // Update is called once per frame
    void Update()
    {
        if (targetObject != null)
        {
            objectToMove.transform.position = targetObject.transform.position + positionOffset;
            objectToMove.transform.rotation = targetObject.transform.rotation * Quaternion.Euler(rotationOffset);
            
            foreach (Transform child in objectToMove.transform)
            {
                child.position = objectToMove.transform.position;
                child.rotation = objectToMove.transform.rotation;//move cleaning animation to wall that is being clean rn
            }
        }
    }
    
    public void SetTargetObject(GameObject target)
    {
        targetObject = target.transform;
    }
}
