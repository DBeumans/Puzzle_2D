using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGravity : MonoBehaviour {

    [SerializeField]private float gravityForce;

    Rigidbody2D myRigidbody2D;

    private void Start()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        myRigidbody2D.AddForce(-Vector2.up * gravityForce, ForceMode2D.Force);
        
    }
}
