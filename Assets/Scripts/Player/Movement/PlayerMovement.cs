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

    private void Update ()
    {
        CheckRaycast();

        if (inputBehaviour.GetJumpKey)
        {
            if(jumpCounter < maxJumpCount-1)
            {
                jumpCounter++;
                myRigidbody2D.AddForce(Vector2.up * jumpPower );
                //myRigidbody2D.MovePosition(Vector2.up * jumpPower * Time.fixedDeltaTime);
            }
        }
        if(isGrounded)
        {
            jumpCounter--;
        }
        if (jumpCounter < 0)
            jumpCounter = 0;

        Vector2 movement = new Vector2(inputBehaviour.GetMoveInput.x, 0) * movementSpeed * Time.deltaTime;
        myRigidbody2D.MovePosition(myRigidbody2D.position + movement);

    }

    private void CheckRaycast()
    {
        //Checks For the ground.
        isGrounded = Physics2D.Linecast(this.transform.position, groundEnd.position, 1 << LayerMask.NameToLayer("Ground"));
        
    }
}
