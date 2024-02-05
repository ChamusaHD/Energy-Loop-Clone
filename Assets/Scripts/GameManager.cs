using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject canvas;

    [System.Serializable]
    public class Puzzle
    {
        public int conectionsToWin;
        public int currentConections;

        public int width;
        public int height;
        public Node[,] nodes;
        public GameObject prefab;
    }

    public Puzzle puzzle;
   
    public static GameManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
       // GenerateGrid();

        canvas.SetActive(false);


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

        Shuffle();

        puzzle.conectionsToWin = GetConectionsToWin();
        print(puzzle.conectionsToWin);

        puzzle.currentConections = Sweep();

    }

    private void Shuffle()
    {
        foreach (Node node in puzzle.nodes) 
        {
            int randomRotation = Random.Range(0, 3);

            for (int i = 0; i < randomRotation; i++)
            {
                node.RotateNodes();
            }
        }
    }

    public int Sweep()
    {
        int value = 0;

        //for each collumn check its line 
        for (int h = 0;h < puzzle.height;h++)
            for (int w = 0;w < puzzle.width; w++)
            {
                //Compare Top and Bottom conections
                if (h != puzzle.height - 1)
                    if (puzzle.nodes[w, h].values[0] == 1 && puzzle.nodes[w, h + 1].values[2] == 1)
                        value++;

                //Compare Left and Right conections
                if (w != puzzle.width - 1)
                    if (puzzle.nodes[w, h].values[1] == 1 && puzzle.nodes[w +1, h].values[3] == 1)
                        value++;
            }

        return value;
    }

    private int GetConectionsToWin()
    {
        int winValue = 0;

        foreach(Node node in puzzle.nodes)
        {
            foreach(int value in node.values)
            {
                winValue += value;
            }
        }

        //this gives the number of exits but we wnat the number of conections so we divede by 2
        winValue /= 2;

        return winValue;
    }

    private void GenerateGrid()
    {
        for (int x = 0; x < puzzle.width; x++)
        {
            for(int y = 0; y < puzzle.height; y++)
            {
                var node = Instantiate(puzzle.prefab, new Vector2(x, y), Quaternion.identity);
            }
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

    public void CheckPuzzleCompletion()
    {
        canvas.SetActive(true);
    }
}
