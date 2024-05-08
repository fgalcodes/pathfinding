using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public GameObject token1, token2, token3;
    private int[,] GameMatrix; //0 not chosen, 1 player, 2 enemy
    private int[] startPos = new int[2];
    public int[] objectivePos = new int[2];

    private int[] test = { 1, 1 };

    private Vector3[] nodesTablePosition = new Vector3[4];
    public static List<Node> openNodes;
    public static List<Node> closedNodes;

    public void ManagerList(Node node)
    {
        openNodes.Add(new Node(node.PosX - 1, node.PosY, Calculator.distance, objectivePos, node)); //<0 >7
        openNodes.Add(new Node(node.PosX +1, node.PosY, Calculator.distance, objectivePos, node));
        openNodes.Add(new Node(node.PosX, node.PosY-1, Calculator.distance, objectivePos, node));
        openNodes.Add(new Node(node.PosX , node.PosY+1, Calculator.distance, objectivePos, node));
        //ordenas la lista por el que tenga HC mas bajo
        //has acabado? que el nodo lista[0] heuristica = 0
        //ManagerList(openNodes[0];
    }
    private void Awake()
    {
        GameMatrix = new int[Calculator.length, Calculator.length];

        for (int i = 0; i < Calculator.length; i++) //fila
            for (int j = 0; j < Calculator.length; j++) //columna
                GameMatrix[i, j] = 0;

        //randomitzar pos final i inicial;
        var rand1 = Random.Range(0, Calculator.length);
        var rand2 = Random.Range(0, Calculator.length);
        startPos[0] = rand1;
        startPos[1] = rand2;
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

    private void Start()
    {
        //ASDW nodesPos = new ASDW(Calculator.GetPositionFromMatrix(startPos));

        //Instantiate(token3, nodesPos.Nodes[0], Quaternion.identity);
        //Instantiate(token3, nodesPos.Nodes[1], Quaternion.identity);
        //Instantiate(token3, nodesPos.Nodes[2], Quaternion.identity);
        //Instantiate(token3, nodesPos.Nodes[3], Quaternion.identity);

        //for (int i = 0; i < nodesPos.Nodes.Length; i++)
        //{
        //    nodesTablePosition = Calculator.GetPositionFromMatrix(nodesPos.Nodes[i]);
        //}
    }
    private void InstantiateToken(GameObject token, int[] position)
    {
        Instantiate(token, Calculator.GetPositionFromMatrix(position),
            Quaternion.identity);
    }
    private void SetObjectivePoint(int[] startPos) 
    {
        var rand1 = Random.Range(0, Calculator.length);
        var rand2 = Random.Range(0, Calculator.length);
        if (rand1 != startPos[0] || rand2 != startPos[1])
        {
            objectivePos[0] = rand1;
            objectivePos[1] = rand2;
        }
    }

    private void ShowMatrix() //fa un debug log de la matriu
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
    //EL VOSTRE EXERCICI COMENÇA AQUI
    private void Update()
    {
        if(!EvaluateWin())
        {

        }
    }
    private bool EvaluateWin()
    {
        return false;
    }
}
