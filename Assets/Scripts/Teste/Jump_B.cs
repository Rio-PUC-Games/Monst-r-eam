﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump_B : MonoBehaviour
{

    private Rigidbody2D rd;
    private CapsuleCollider2D coll2d;

    public float jumpforce = 600f;

    public float FloorDetectionRayDistance = 0.05f;

    public AudioSource tempJumpSound;

    // Start is called before the first frame update
    void Start()
    {
        rd = GetComponent<Rigidbody2D>();
        //capsule collider?
        coll2d = GetComponent<CapsuleCollider2D>();

        //adds try to jump function to press callback
        //function TryToJump will be called every time "button is pressed", for all platforms
        //PlayerInput.OnPress += TryToJump;
        //Debug.Log("Jumps" + PlayerInput.OnPress.GetInvocationList().GetLength(0));
    }

    // Update is called once per frame
    void Update()
    {
        
        if(PlayerInput.IsPressed())
        {
            TryToJump();
        }
    }

    private void TryToJump()
    {
        //faz raycasting pra checar se o lemming pode pular
        //TO-DO: implementar delayzinho

        int layerMask = LayerMask.GetMask("Default");
        float collsize = (coll2d.size.y / 2) * transform.lossyScale.y;
        Vector3 rayStartingPosition = new Vector3(transform.position.x, transform.position.y - collsize, transform.position.z);
        RaycastHit2D hit = Physics2D.Raycast(rayStartingPosition, Vector2.down, FloorDetectionRayDistance, layerMask);
        if((rd.velocity.y <= 0.1f ) && hit.collider != null)
        {
            //estamos usando add force, por hora. Por enquanto tem ido bem 
            rd.AddForce(new Vector2(0f, jumpforce), ForceMode2D.Force);
            if(tempJumpSound) tempJumpSound.Play();
        }
    }
}
