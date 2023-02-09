using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeballController : MonoBehaviour
{

    [SerializeField] private float movespeed, direction, distance;
    private float startPos, currentPos;
 
    void Awake()
    {
        startPos = transform.position.x;
    }
   
    
    void Update()
    {
        transform.Translate(movespeed * direction * Time.deltaTime, 0,0);

        if (transform.position.x >= startPos + distance || transform.position.x <= startPos - distance)
        {
            direction = -direction;  
        }
/*
        Vector3 Scale = transform.localScale;
        Scale.x = direction;
        transform.localScale = Scale;*/
    }
}
