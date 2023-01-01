using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class CropsEntity : Entity
{
    public UnityEngine.Events.UnityEvent OnHarvestableEvent;
    public float remain = 0.0f;
    public void Update()
    {
        var previousRemain = remain;
        var currentRemain  = remain -= Time.deltaTime;
        if(previousRemain >= 0)
        {
            remain = -1;
            if(currentRemain <= 0)
            {
                OnHarvestableEvent?.Invoke();
            }
        }

    }
}
