using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputBehaviour : MonoBehaviour {

    private Vector2 moveInput;
    private bool jumpKey;

    public Vector2 GetMoveInput { get { return moveInput; } }
    public bool GetJumpKey { get { return jumpKey; } }

    private KeyCode keycodeJump;

    private void Update()
    {
        keycodeJump = KeyCode.Space;
        moveInput = new Vector2(Input.GetAxis("Horizontal"),0) ;

        jumpKey = Input.GetKeyDown(keycodeJump);

    }
}
