using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YaoWorldGrid : MonoBehaviour
{
    public Grid gr; 

    public void OnDrawGizmos()
    {  
        var xSize = gr.cellSize.x;
        var zSize = gr.cellSize.z; 

        for(int y = 0; y < zSize; y++)
        {
            for (int x = 0; x < xSize; x++)
            {
                Gizmos.DrawCube(new Vector3(x, 0, y), new Vector3(1,0.1f,1));
            }
        }

        var v2 = gr.GetCellCenterLocal(new Vector3Int(2,0, 2));

        var v3 = gr.GetCellCenterWorld(new Vector3Int(2,0, 2));

        Gizmos.color = Color.red;
        Gizmos.DrawCube(v2, new Vector3(1, 0.1f, 1));
        Gizmos.color = Color.green;
        Gizmos.DrawCube(v3, new Vector3(1, 0.1f, 1));
    }

    public void Update()
    { 
        
    }
}
