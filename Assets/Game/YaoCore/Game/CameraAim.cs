using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAim : MonoBehaviour
{
    [SerializeField] int maskLayer;
    [SerializeField] float distance;
    public void Raycast()
    {
        int layerMask = 1 << 8; 
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 12, layerMask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.green);
            
        }
    }

}
