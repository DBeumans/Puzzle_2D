using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputBehaviour : MonoBehaviour {

    private Vector2 moveInput;
    private bool jumpKey;
    private bool keyE;

    public Vector2 GetMoveInput { get { return moveInput; } }
    public bool GetJumpKey { get { return jumpKey; } }
    public bool GetEKey { get { return keyE; } }

    private KeyCode keycodeJump;
    private KeyCode keycodeE;

    private void Update()
    {
        keycodeJump = KeyCode.Space;
        keycodeE = KeyCode.E;

        moveInput = new Vector2(Input.GetAxis("Horizontal"),0) ;

        jumpKey = Input.GetKeyDown(keycodeJump);
        keyE = Input.GetKeyDown(keycodeE);

    }
}
