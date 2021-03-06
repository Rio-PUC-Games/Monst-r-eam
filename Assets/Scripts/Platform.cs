﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public float Velocidade = 3.5f;
    public bool Horizontal;
    public bool Vertical;
    public float distancia = 10f;
    private float MaxPosX;
    private float MaxPosY;
    private float PosX;
    private float PosY;
    private bool movH;
    private bool movV;

    public bool invert;

    // Start is called before the first frame update
    void Start()
    {
        if (invert)
        {
            distancia = -distancia;
        }
        PosX = transform.position.x;
        PosY = transform.position.y;
        MaxPosX = transform.position.x + distancia;
        MaxPosY = transform.position.y + distancia;
    }

    // Update is called once per frame
    void Update()
    {
        if(!invert) 
        {
            if(Horizontal == true)
            {
                if (transform.position.x >= MaxPosX)
                {
                    movH = false;
                }
                if(transform.position.x <= PosX)
                {
                    movH = true;
                }
                if(movH == true)
                {
                    transform.position += Vector3.right * Velocidade * Time.deltaTime;
                }
                else
                {
                    transform.position += Vector3.right * -Velocidade * Time.deltaTime;
                }
            }
            if(Vertical == true)
            {
                if (transform.position.y >= MaxPosY)
                {
                    movV = false;
                }
                if (transform.position.y <= PosY)
                {
                    movV = true;
                }
                if (movV == true)
                {
                    transform.position += Vector3.up * Velocidade * Time.deltaTime;
                }
                else
                {
                    transform.position += Vector3.up * -Velocidade * Time.deltaTime;
                }
            }
        }
        else 
        {
            if(Horizontal == true)
            {
                if (transform.position.x <= MaxPosX)
                {
                    movH = false;
                }
                if(transform.position.x >= PosX)
                {
                    movH = true;
                }
                if(movH == true)
                {
                    transform.position -= Vector3.right * Velocidade * Time.deltaTime;
                }
                else
                {
                    transform.position -= Vector3.right * -Velocidade * Time.deltaTime;
                }
            }
            if(Vertical == true)
            {
                if (transform.position.y <= MaxPosY)
                {
                    movV = false;
                }
                if (transform.position.y >= PosY)
                {
                    movV = true;
                }
                if (movV == true)
                {
                    transform.position -= Vector3.up * Velocidade * Time.deltaTime;
                }
                else
                {
                    transform.position -= Vector3.up * -Velocidade * Time.deltaTime;
                }
            }
        }
    }

    void OnDrawGizmos(){
        Gizmos.color = Color.red;
        Vector3 dir = Vector3.zero;
        if(Horizontal) dir += Vector3.right;
        if(Vertical) dir += Vector3.up;
        if(invert) dir *= -1;
        Gizmos.DrawRay(transform.position, distancia * dir);
    }
}
