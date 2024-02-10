using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class Node : MonoBehaviour
{
    public int[] values;

    [SerializeField] private float speed;

    private float realRotation;

    private GameManager gameManager;

    private SpriteRenderer spriteRenderer;

    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip clip;

    void Start()
    {
        //realRotation = transform.rotation.eulerAngles.z;

        gameManager = GameObject.FindObjectOfType<GameManager>().GetComponent<GameManager>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if(transform.rotation.eulerAngles.z!= realRotation)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0,0,realRotation), speed);
        }
    }

    private void OnMouseDown()
    {

        Handheld.Vibrate();
        source.PlayOneShot(clip);

        int diference = -gameManager.QuickSweep((int)transform.position.x,(int)transform.position.y); //QuickSweep before rotating

        RotateNode();

        diference += gameManager.QuickSweep((int)transform.position.x, (int)transform.position.y); //QuickSweep after rotating

       // gameManager.puzzle.currentConections = gameManager.Sweep();
        gameManager.puzzle.currentConections += diference;

        if (gameManager.puzzle.currentConections == gameManager.puzzle.conectionsToWin )
        {
            gameManager.PuzzleCompletion();

            LevelManager.Instance.UnlockNewLevel();
            //Invoke();

        } 
    }

    public void RotateNode()
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
}
