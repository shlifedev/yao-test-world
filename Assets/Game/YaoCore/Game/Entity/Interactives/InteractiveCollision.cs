using System.Collections.Generic;
using UnityEngine;

public class InteractiveCollision : UnityEngine.MonoBehaviour
{
    public Rigidbody rb;
    public List<IInteractiveObject> interactiveObjects = new List<IInteractiveObject>();
    public Dictionary<MonoBehaviour, int> ignoreCache = new Dictionary<MonoBehaviour, int>();

    public void OnTriggerEnter(Collider other)
    {
        var hitObj = other.gameObject;
        if(hitObj.layer == 1 >> LayerMask.GetMask("Interactable"))
        {
            var behaviour = hitObj.GetComponent<MonoBehaviour>(); 
            // casting optimization
            if (ignoreCache.ContainsKey(behaviour))
                return;
            var interactive = behaviour as IInteractiveObject; 
            interactiveObjects.Add(interactive);
        }
    }
    public void OnTriggerExit(Collider other)
    {
        var hitObj = other.gameObject;
        if (hitObj.layer == 1 >> LayerMask.GetMask("Interactable"))
        {
            var interactive = hitObj.GetComponent<IInteractiveObject>();
            interactiveObjects.Add(interactive);
        }
    } 
}