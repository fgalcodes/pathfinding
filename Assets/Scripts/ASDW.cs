using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ASDW
{
    public float[] Heuristic { get; set; } = new float[4];
    public float[] Cost { get; set; } = new float[4];
    public ASDW Father { get; set; }
    public Vector2[] Nodes { get; set; }

    public ASDW (Vector3 position)
    {
        Debug.Log("Instantiate");

        Nodes = Calculator.GetNodesPosition(position);

        foreach (var item in Nodes)
        {
            Debug.Log(item);
            int[] itemParse = { (int)item.x, (int)item.y};
            Debug.Log(Calculator.GetPositionFromMatrix(itemParse));
            Debug.Log("culo");
            
        }
    }
}
