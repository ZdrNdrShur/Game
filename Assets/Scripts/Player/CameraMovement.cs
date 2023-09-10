using UnityEngine;

public class CameraMovement : MonoBehaviour {

    private PlayerInputActions inputActions;

    [SerializeField] private float sensitivity = 0.3f;
    [SerializeField] private float maxVerticalRotationAngle = 75f;
    private Vector3 rotationVector;

    private void Start() {
        inputActions = new PlayerInputActions();
        inputActions.PlayerDefault.Rotate.Enable();
        rotationVector = new Vector3(0f, 0f, 0f);
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update() {
        float mouseX = inputActions.PlayerDefault.Rotate.ReadValue<Vector2>().x;
        float mouseY = inputActions.PlayerDefault.Rotate.ReadValue<Vector2>().y;

        transform.parent.Rotate(mouseX * sensitivity * Vector3.up);     //(Y-rotation) rotate the whole player and with it the camera will also rotate

        Quaternion currentRotation = transform.localRotation;
        Quaternion verticalRotation = Quaternion.Euler(-mouseY * sensitivity, 0, 0);
        Quaternion newRotation = currentRotation * verticalRotation;

        if ((newRotation.eulerAngles.x >= 0f && newRotation.eulerAngles.x < maxVerticalRotationAngle) || (newRotation.eulerAngles.x > (360f - maxVerticalRotationAngle) && newRotation.eulerAngles.x <= 360f)) {
            transform.localRotation = newRotation;      //cap the camera rotation
        }
        rotationVector = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0f);
        transform.eulerAngles = rotationVector;     //(X-rotation) rotate only the camera
    }

    //getters
    public Vector3 CurrentRotation {
        get { return transform.forward; }
    }
}