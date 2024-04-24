using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ASDW
{
    public int Heuristic { get; set; }
    public int Cost { get; set; }
    public ASDW Father { get; set; }
    public Vector2[] Nodes { get; set; }

    public ASDW (Vector3 position)
    {
        Debug.Log("Instantiate");

        Nodes = Calculator.GetNodesPosition (position);

        foreach (var item in Nodes)
        {
            Debug.Log(item);
            
        }
    }
}
