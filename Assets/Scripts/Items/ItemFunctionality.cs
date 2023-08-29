using UnityEngine;

public class ItemFunctionality : MonoBehaviour {

    private const string playerTag = "Player";

    [SerializeField] private string upgrade;

    private void OnTriggerEnter(Collider collision) {
        GameObject collidedObject = collision.gameObject;
        if (collidedObject.tag == playerTag) {
            collidedObject.GetComponent<ItemHandler>().ItemManager(upgrade);
            Destroy(gameObject);
        }
    }
}
