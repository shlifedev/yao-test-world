using System.Collections.Generic;
using UnityEngine;

public class InteractiveCollision : UnityEngine.MonoBehaviour
{
    public Rigidbody rb;
    public List<IInteractiveObject> interactiveObjects = new List<IInteractiveObject>();
    public HashSet<int> ignoreCache = new HashSet<int>();

    public void OnTriggerEnter(Collider other)
    {
        var hitObj = other.gameObject;
        if(hitObj.layer == 1 << LayerMask.GetMask("Interactable"))
        {
            var behaviour = hitObj.GetComponent<MonoBehaviour>(); 
            // casting optimization
            if (ignoreCache.Contains(other.GetInstanceID()))
                return;
            var interactive = behaviour as IInteractiveObject;
            if (interactive == null)
                ignoreCache.Add(other.GetInstanceID());
            else 
                interactiveObjects.Add(behaviour as IInteractiveObject); 
        }
    }
    public void OnTriggerExit(Collider other)
    {
        var hitObj = other.gameObject;
        if (hitObj.layer == 1 << LayerMask.GetMask("Interactable"))
        {
            var behaviour = hitObj.GetComponent<MonoBehaviour>();
            if (!ignoreCache.Contains(other.GetInstanceID())) {
                interactiveObjects.Remove(behaviour as IInteractiveObject);
            } 
        }
    }

    public void OnDestroy()
    {
        ignoreCache.Clear();
    }
}