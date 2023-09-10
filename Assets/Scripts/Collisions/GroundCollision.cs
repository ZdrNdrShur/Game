using UnityEngine;

public class GroundCollision : MonoBehaviour {

    private const string playerTag = "Player";

    private void OnCollisionEnter(Collision collision) {
        GameObject collidedObject = collision.gameObject;
        if (collidedObject.CompareTag(playerTag)) {
            collidedObject.GetComponent<MovementProperties>().Ground();
        }
    }
}
