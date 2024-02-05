using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;

public class Node : MonoBehaviour
{
    public int[] values;

    [SerializeField] private float speed;

    private float realRotation;

    private GameManager gameManager;

    void Start()
    {
        //realRotation = transform.rotation.eulerAngles.z;

        gameManager = GameObject.FindObjectOfType<GameManager>().GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.rotation.eulerAngles.z!= realRotation)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0,0,realRotation), speed);
        }
    }

    private void OnMouseDown()
    {
        RotateNodes();

        gameManager.puzzle.currentConections = gameManager.Sweep();

        if (gameManager.puzzle.currentConections == gameManager.puzzle.conectionsToWin )
        {
            gameManager.CheckPuzzleCompletion();
        }
    }

    public void RotateNodes()
    {
        realRotation += 90;
        //transform.rotation = Quaternion.Euler(0, 0, realRotation);

        if (realRotation == 360)
            realRotation = 0;

        RotateValues();
    }

    private void RotateValues()
    {
        int aux = values[0];

        for (int i = 0; i < values.Length-1; i++)
        {
            values[i] = values[i + 1];
        }

        values[3] = aux;
    }

    /*public int GetValues()
    {
        return values[1];
    }*/
}
