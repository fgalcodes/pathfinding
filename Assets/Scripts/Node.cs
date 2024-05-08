using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    public float Heuristic { get; set; } 
    public float Cost { get; set; } 
    public Node Father { get; set; }
    public int PosX { get; set; }
    public int PosY { get; set; }

    public float HC { get; set; }


    public Node (int posX, int posY, float cost, int[] objectivePos, Node parent)
    {
        PosX = posX;
        PosY = posY;

        Cost = cost;    

        Heuristic = Calculator.CheckDistanceToObj(new int[] { posX, posY }, objectivePos);

        HC = Cost + Heuristic;
        Father = parent;
    }
}
