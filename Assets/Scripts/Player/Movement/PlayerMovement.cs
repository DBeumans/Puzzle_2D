﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]
public class PlayerMovement : MonoBehaviour {

    private InputBehaviour inputBehaviour;

    [SerializeField]private float movementSpeed;
    [SerializeField]private bool isGrounded;
    [SerializeField]private float jumpPower;
    [SerializeField]
    private int jumpCounter;
    [SerializeField]
    private int maxJumpCount;
    
    [SerializeField]private Transform groundEnd;
    [SerializeField]private Transform dir;

    private Rigidbody2D myRigidbody2D;
    private PlayerTriggerCollision myTriggerCollision;

    [SerializeField]private int myDirection = 0;
    [SerializeField]private bool myWall;

    private void Start ()
    {
        inputBehaviour = FindObjectOfType<InputBehaviour>();
        myRigidbody2D = GetComponent<Rigidbody2D>();
        myTriggerCollision = GetComponent<PlayerTriggerCollision>();
	}

    private void FixedUpdate ()
    {
        CheckRaycast();

        if (inputBehaviour.GetJumpKey)
        {
            if(jumpCounter < maxJumpCount-1)
            {
                jumpCounter++;
                myRigidbody2D.AddForce(Vector2.up * (jumpPower *1000)* Time.deltaTime);
            }
        }
        if(isGrounded)
        {
            jumpCounter--;
        }
        if (jumpCounter < 0)
            jumpCounter = 0;
        
        //myRigidbody2D.velocity = new Vector2(inputBehaviour.GetMoveInput.x * movementSpeed, myRigidbody2D.velocity.y);

        if (inputBehaviour.GetKeyA ) //left
        {
            if(myDirection != -1 )
            {
                myRigidbody2D.velocity = new Vector2(-movementSpeed, myRigidbody2D.velocity.y);
                transform.eulerAngles = new Vector2(0, 0);
                myDirection = -1;
            }     
        }

        else if (inputBehaviour.GetKeyD ) // right
        {
            if(myDirection != 1 )
            {
                if (myWall)
                {
                    myRigidbody2D.AddForce(Vector2.right * 10);
                }
                myRigidbody2D.velocity = new Vector2(movementSpeed, myRigidbody2D.velocity.y);
                transform.eulerAngles = new Vector2(0, 180);
                myDirection = 1;
            }   
        }

        else
        {
            myRigidbody2D.velocity = new Vector2(0, myRigidbody2D.velocity.y);
            myDirection = 0;
        }
    }

    private void CheckRaycast()
    {
        //Checks For the ground.
        isGrounded = Physics2D.Linecast(this.transform.position, groundEnd.position, 1 << LayerMask.NameToLayer("Ground"));

        Debug.DrawLine(this.transform.position, dir.position, Color.green);
        
        //myWall = Physics2D.Linecast(this.transform.position, dir.position, 1 << LayerMask.NameToLayer("Object"));
        myWall = Physics2D.BoxCast(dir.position,this.transform.localScale/4,0, dir.position , 1 , 1 << LayerMask.NameToLayer("Object"));
        
    }
}
