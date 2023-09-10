using UnityEngine;

public class ItemBobbing : MonoBehaviour {

    [SerializeField] private float maxBobbingMove = 0.5f;
    [SerializeField] private float bobbingSpeedMove = 0.03f;
    [SerializeField] private float bobbingSpeedRotate = 9f;
    private float currentBobbingMove;
    private float currentBobbingRotate;

    private void Start() {
        currentBobbingMove = 0f;
        currentBobbingRotate = 0f;
    }

    private void FixedUpdate() {
        if (currentBobbingMove <= -maxBobbingMove || currentBobbingMove >= maxBobbingMove) {
            bobbingSpeedMove = -bobbingSpeedMove;
        }
        currentBobbingMove += bobbingSpeedMove;
        currentBobbingRotate += bobbingSpeedRotate;

        transform.position = new Vector3(transform.position.x, transform.position.y + bobbingSpeedMove, transform.position.z);
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, currentBobbingRotate, transform.eulerAngles.z);
    }
}
