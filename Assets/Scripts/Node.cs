using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;

public class Node : MonoBehaviour
{
    [SerializeField] private int[] values;

    [SerializeField] private float speed;

    private float realRotation;

    void Start()
    {
        //realRotation = transform.rotation.eulerAngles.z;
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
    }

    private void RotateNodes()
    {
        realRotation -= 90;
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
