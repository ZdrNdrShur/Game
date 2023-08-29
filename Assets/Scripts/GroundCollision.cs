using UnityEngine;

public class GroundCollision : MonoBehaviour {

    private const string playerTag = "Player";

    private void OnCollisionEnter(Collision collision) {
        GameObject collidedObject = collision.gameObject;
        if (collidedObject.tag == playerTag) {
            collidedObject.GetComponent<MovementProperties>().Ground();
        }
    }
}
