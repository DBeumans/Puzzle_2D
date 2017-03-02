using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputBehaviour : MonoBehaviour {

    private Vector2 moveInput;
    private bool jumpKey;
    private bool keyE;

    private bool keyA;
    private bool keyD;

    private bool mouseLeft;
    private bool mouseRight;

    public bool GetMouseLeft { get { return mouseLeft; } }
    public bool GetMouseRight { get { return mouseRight; } }

    public bool GetKeyA { get { return keyA; } }
    public bool GetKeyD { get { return keyD; } }

    public Vector2 GetMoveInput { get { return moveInput; } }
    public bool GetJumpKey { get { return jumpKey; } }
    public bool GetEKey { get { return keyE; } }

    private KeyCode keycodeJump;
    private KeyCode keycodeE;

    private KeyCode keycodeA;
    private KeyCode keycodeD;

    private KeyCode keycodeMouseLeft;
    private KeyCode keycodeMouseRight;

    private void Update()
    {
        keycodeJump = KeyCode.Space;
        keycodeE = KeyCode.E;

        keycodeA = KeyCode.A;
        keycodeD = KeyCode.D;

        keycodeMouseLeft = KeyCode.Mouse0;
        keycodeMouseRight = KeyCode.Mouse1;

        moveInput = new Vector2(Input.GetAxis("Horizontal"),0) ;

        jumpKey = Input.GetKeyDown(keycodeJump);
        keyE = Input.GetKeyDown(keycodeE);

        keyA = Input.GetKey(keycodeA);
        keyD = Input.GetKey(keycodeD);

        mouseLeft = Input.GetKeyDown(keycodeMouseLeft);
        mouseRight = Input.GetKeyDown(keycodeMouseRight);

    }
}
