using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public GameObject token1, token2, token3;
    private int[,] GameMatrix; // 0 not chosen, 1 player, 2 enemy
    private int[] startPos = new int[2];
    public int[] objectivePos = new int[2];
    public static List<Node> openNodes;
    public static List<Node> closedNodes;
    private List<Vector3> path;

    private void Awake()
    {
        GameMatrix = new int[Calculator.length, Calculator.length];
        openNodes = new List<Node>();
        closedNodes = new List<Node>();
        path = new List<Vector3>();

        for (int i = 0; i < Calculator.length; i++) // fila
        {
            for (int j = 0; j < Calculator.length; j++) // columna
            {
                GameMatrix[i, j] = 0;
            }
        }

        // Randomize initial and objective positions
        startPos[0] = Random.Range(0, Calculator.length);
        startPos[1] = Random.Range(0, Calculator.length);
        SetObjectivePoint(startPos);

        GameMatrix[startPos[0], startPos[1]] = 1;
        GameMatrix[objectivePos[0], objectivePos[1]] = 2;

        InstantiateToken(token1, startPos);
        InstantiateToken(token2, objectivePos);
        ShowMatrix();
        var node = new Node(startPos[0], startPos[1], 0, objectivePos, null);
        closedNodes.Add(node);
        ManagerList(node);
    }

    private void Update()
    {
        if (!EvaluateWin())
        {
            if (openNodes.Count > 0)
            {
                // Sort open nodes by heuristic cost
                openNodes.Sort((nodeA, nodeB) => nodeA.HC.CompareTo(nodeB.HC));

                // Get the node with the lowest heuristic cost
                Node currentNode = openNodes[0];

                // Move the player to the position of the lowest-cost node
                MovePlayer(currentNode.PosX - startPos[0], currentNode.PosY - startPos[1]);

                // Visualize the path to the current node
                InstantiateToken(token1, new int[] { currentNode.PosX, currentNode.PosY });

                // Remove the current node from open nodes
                openNodes.Remove(currentNode);

                // Add current node to closed nodes
                closedNodes.Add(currentNode);

                // Expand the current node
                ManagerList(currentNode);
            }
            else
            {
                Debug.Log("No path found!");
            }
        }
    }

    private void MovePlayer(int deltaX, int deltaY)
    {
        int newX = Mathf.Clamp(startPos[0] + deltaX, 0, Calculator.length - 1);
        int newY = Mathf.Clamp(startPos[1] + deltaY, 0, Calculator.length - 1);

        GameMatrix[startPos[0], startPos[1]] = 0;
        startPos[0] = newX;
        startPos[1] = newY;
        GameMatrix[startPos[0], startPos[1]] = 1;

        // Update player token position
        token1.transform.position = Calculator.GetPositionFromMatrix(startPos);

        // Add position to path
        path.Add(token1.transform.position);
    }

    private bool EvaluateWin()
    {
        if (startPos[0] == objectivePos[0] && startPos[1] == objectivePos[1])
        {
            return true;
        }
        return false;
    }

    private void InstantiateToken(GameObject token, int[] position)
    {
        Instantiate(token, Calculator.GetPositionFromMatrix(position), Quaternion.identity);
    }

    private void SetObjectivePoint(int[] startPos)
    {
        do
        {
            objectivePos[0] = Random.Range(0, Calculator.length);
            objectivePos[1] = Random.Range(0, Calculator.length);
        } while (objectivePos[0] == startPos[0] && objectivePos[1] == startPos[1]);
    }

    private void ShowMatrix()
    {
        string matrix = "";
        for (int i = 0; i < Calculator.length; i++)
        {
            for (int j = 0; j < Calculator.length; j++)
            {
                matrix += GameMatrix[i, j] + " ";
            }
            matrix += "\n";
        }
        Debug.Log(matrix);
    }

    public void ManagerList(Node node)
    {
        openNodes.Add(new Node(node.PosX - 1, node.PosY, Calculator.distance, objectivePos, node)); //<0 >7
        openNodes.Add(new Node(node.PosX + 1, node.PosY, Calculator.distance, objectivePos, node));
        openNodes.Add(new Node(node.PosX, node.PosY - 1, Calculator.distance, objectivePos, node));
        openNodes.Add(new Node(node.PosX, node.PosY + 1, Calculator.distance, objectivePos, node));
    }
}
