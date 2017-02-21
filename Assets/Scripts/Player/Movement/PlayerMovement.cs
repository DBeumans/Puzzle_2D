using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private Rigidbody2D myRigidbody2D;

	private void Start ()
    {
        inputBehaviour = FindObjectOfType<InputBehaviour>();
        myRigidbody2D = GetComponent<Rigidbody2D>();
	}

    private void FixedUpdate ()
    {
        CheckRaycast();

        if (inputBehaviour.GetJumpKey)
        {
            if(jumpCounter < maxJumpCount-1)
            {
                jumpCounter++;
                myRigidbody2D.AddForce(Vector2.up * jumpPower *10* Time.deltaTime);
                //myRigidbody2D.MovePosition(Vector2.up * jumpPower * Time.fixedDeltaTime);
            }
        }
        if(isGrounded)
        {
            jumpCounter--;
        }
        if (jumpCounter < 0)
            jumpCounter = 0;

        myRigidbody2D.velocity = new Vector2(inputBehaviour.GetMoveInput.x * movementSpeed, myRigidbody2D.velocity.y);

        //Vector2 movement = new Vector2(inputBehaviour.GetMoveInput.x, 0) * movementSpeed * Time.fixedDeltaTime;
        //myRigidbody2D.MovePosition(myRigidbody2D.position + movement);

        // transform.Translate(new Vector2(inputBehaviour.GetMoveInput.x,0)*movementSpeed *Time.deltaTime) ;

    }

    private void CheckRaycast()
    {
        //Checks For the ground.
        isGrounded = Physics2D.Linecast(this.transform.position, groundEnd.position, 1 << LayerMask.NameToLayer("Ground"));
        
    }
}
