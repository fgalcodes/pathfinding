using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ASDW
{
    public int Heuristic { get; set; }
    public int Cost { get; set; }
    public ASDW Father { get; set; }

    public ASDW ()
    {
        Debug.Log("Instantiate");
    }
}
