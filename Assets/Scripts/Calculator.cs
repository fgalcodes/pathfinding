using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Calculator
{
    public static float distance = 0.523f;
    public static int length = 8;

    public static Vector3 GetPositionFromMatrix(int[]point)
    {
        return new Vector3(-(length - 1f) * distance + point[1] * 2f * distance,
            (length - 1f) * distance - point[0] * 2f * distance, 0);
    }
    public static float CheckDistanceToObj(int[] point, int[] obj)
    {
        return Vector3.Distance(GetPositionFromMatrix(obj), GetPositionFromMatrix(point));
    }

    public static Vector2[] GetNodesPosition(Vector3 position)
    {
        Vector2[] nodes = new Vector2[4];

        nodes[0] = new Vector2(position.x, position.y + distance * 2f);
        nodes[1] = new Vector2(position.x + distance * 2f, position.y);
        nodes[2] = new Vector2(position.x, position.y - distance * 2f);
        nodes[3] = new Vector2(position.x - distance * 2f, position.y);

        return nodes;
    }
}
