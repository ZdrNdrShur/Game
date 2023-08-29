using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private PlayerInputActions inputActions;
    private Rigidbody rigidBody;
    private Camera playerCamera;
    private MovementProperties movementProperties;

    private float currentMoveX;
    private float currentMoveY;
    private float currentMoveZ;
    private Vector3 movementVector;

    void Start() {
        inputActions = new PlayerInputActions();
        inputActions.PlayerDefault.Move.Enable();
        inputActions.PlayerDefault.Jump.Enable();
        rigidBody = GetComponent<Rigidbody>();
        playerCamera = GetComponentInChildren<Camera>();
        movementProperties = GetComponent<MovementProperties>();
        currentMoveX = 0f;
        currentMoveY = 0f;
        currentMoveZ = 0f;
        movementVector = new Vector3(0f, 0f, 0f);
    }

    void Update() {
        currentMoveX = inputActions.PlayerDefault.Move.ReadValue<Vector2>().y;
        currentMoveY = rigidBody.velocity.y;
        currentMoveZ = -inputActions.PlayerDefault.Move.ReadValue<Vector2>().x;

        if (inputActions.PlayerDefault.Jump.triggered) {
            if (movementProperties.CanJump()) {
                float downwardVelocity = -rigidBody.velocity.y;
                currentMoveY += movementProperties.SpeedY + downwardVelocity;
            }
        }

        Vector3 cameraForward = playerCamera.transform.forward;
        Vector3 cameraRight = playerCamera.transform.right;
        cameraForward.y = 0f;
        cameraRight.y = 0f;
        Vector3 moveDirection = (cameraForward * currentMoveX - cameraRight * currentMoveZ).normalized;

        moveDirection.x *= movementProperties.SpeedXZ;
        moveDirection.y = currentMoveY;
        moveDirection.z *= movementProperties.SpeedXZ;
        movementVector = moveDirection;

        rigidBody.velocity = movementVector;
    }

    public void DisableMovement() {
        inputActions.PlayerDefault.Move.Disable();
        inputActions.PlayerDefault.Jump.Disable();
    }
}
