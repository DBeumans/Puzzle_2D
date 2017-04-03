using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]
public class PlayerMovement : MonoBehaviour {

    private InputBehaviour inputBehaviour;

    [SerializeField]private float oldMovementSpeed;
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
        oldMovementSpeed = movementSpeed;
	}

    private void Update ()
    {
        CheckRaycast();

        
        if(isGrounded)
        {
            jumpCounter--;
        }
        if (jumpCounter < 0)
            jumpCounter = 0;

        if (inputBehaviour.GetJumpKey)
        {
            print("jump");
            if (jumpCounter < maxJumpCount - 1)
            {
                jumpCounter++;
                //myRigidbody2D.AddForce(Vector2.up * (jumpPower *1000)* Time.deltaTime);
                myRigidbody2D.AddForce(new Vector2(0, jumpPower));
            }
        }

        //myRigidbody2D.velocity = new Vector2(inputBehaviour.GetMoveInput.x * movementSpeed, myRigidbody2D.velocity.y);

        if (inputBehaviour.GetKeyA ) //left
        {
            myDirection = -1;
            myRigidbody2D.velocity = new Vector2(-movementSpeed, myRigidbody2D.velocity.y);
            transform.eulerAngles = new Vector2(0, 0);
        }

        else if (inputBehaviour.GetKeyD ) // right
        {
            myDirection = 1;
            
            myRigidbody2D.velocity = new Vector2(movementSpeed, myRigidbody2D.velocity.y);
            transform.eulerAngles = new Vector2(0, 180);
        }
        

        else if (myWall && isGrounded== false && Mathf.Abs(myDirection) > .1f )
        {
            movementSpeed = 0;
            //myRigidbody2D.velocity = new Vector2(0, myRigidbody2D.velocity.y);
        }

        else
        {
            myRigidbody2D.velocity = new Vector2(0, myRigidbody2D.velocity.y);
            myDirection = 0;
            movementSpeed = oldMovementSpeed;
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
