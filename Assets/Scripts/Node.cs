using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    public float[] Heuristic { get; set; } = new float[4];
    public float[] Cost { get; set; } = new float[4];
    public ASDW Father { get; set; }
    public Vector2[] Nodes { get; set; }

}
