using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnityEngine;
using UnityEngine.Events;

public class Crops : UnityEngine.MonoBehaviour
{
    private float remainTime = 300;
    private bool isGrowing = false;
    public UnityAction OnGrowthComplete; 
    public float RemainTime => remainTime;
    public void FixedUpdate()
    {
        if (isGrowing)
        {
            remainTime -= Time.fixedDeltaTime;
            if (remainTime < 0)
            {
                isGrowing = false;
                OnGrowthComplete?.Invoke();
            }
        }
    }
     
}
