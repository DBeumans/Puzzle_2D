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

    private Rigidbody2D myRigidbody2D;

    [SerializeField]private Transform groundEnd;
    
	private void Start ()
    {
        inputBehaviour = FindObjectOfType<InputBehaviour>();
        myRigidbody2D = GetComponent<Rigidbody2D>();
	}

    private void Update ()
    {
        CheckRaycast();

        if (inputBehaviour.GetJumpKey)
        {
            if(jumpCounter < maxJumpCount-1)
            {
                jumpCounter++;
                myRigidbody2D.AddForce(Vector2.up * jumpPower);
            }
        }
        if(isGrounded)
        {
            jumpCounter--;
        }
        if (jumpCounter < 0)
            jumpCounter = 0;

        transform.Translate((new Vector2(inputBehaviour.GetMoveInput.x ,0)* movementSpeed ) * Time.deltaTime); 

    }

    private void CheckRaycast()
    {
        //Checks For the ground.
        isGrounded = Physics2D.Linecast(this.transform.position, groundEnd.position, 1 << LayerMask.NameToLayer("Ground"));
        
    }
}
