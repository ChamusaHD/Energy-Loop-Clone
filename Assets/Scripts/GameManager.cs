using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [System.Serializable]
    public class Puzzle
    {
         public int width;
         public int height;
         public Node[,] nodes;
    }

    public Puzzle puzzle;
    // Start is called before the first frame update
    void Start()
    {
        Vector2 puzzleDimensions = CheckForDimensions();

        puzzle.width = (int)puzzleDimensions.x;
        puzzle.height = (int)puzzleDimensions.y;

        puzzle.nodes = new Node[puzzle.width, puzzle.height];

        foreach (GameObject node in GameObject.FindGameObjectsWithTag("Node"))
        {
            puzzle.nodes[(int)node.transform.position.x, (int)node.transform.position.y] = node.GetComponent<Node>();
        }

        foreach (Node item in puzzle.nodes)
        {
            Debug.Log(item.gameObject.name);
        }
    }

    private Vector2 CheckForDimensions()
    {
        Vector2 dimension = Vector2.zero;
        GameObject[] nodes = GameObject.FindGameObjectsWithTag("Node");

        foreach (GameObject node in nodes) 
        {
            if (node.transform.position.x > dimension.x)
            {
                dimension.x = node.transform.position.x;
            }

            if (node.transform.position.y > dimension.y)
            {
                dimension.y = node.transform.position.y;
            }
        }

        //array starts at index 0 so we need to add 1 so it matches the actual puzzle dimension
        dimension.x++;
        dimension.y++;

        return dimension;
    }
}
