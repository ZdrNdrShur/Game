using UnityEngine;

public class ItemFunctionality : MonoBehaviour {

    private const string playerTag = "Player";

    [SerializeField] private string upgrade;
    private int itemType;

    private void Start() {
        if (upgrade.Contains("UPGRADE")) {
            itemType = 0;
        }
        if (upgrade.Contains("SINGLEUSE")) {
            itemType = 1;
        }
        if (upgrade.Contains("WEAPON")) {
            itemType = 2;
        }
        if (upgrade.Contains("COLLECTIBLE")) {
            itemType = 3;
        }
    }

    private void OnTriggerEnter(Collider collision) {
        GameObject collidedObject = collision.gameObject;
        if (collidedObject.CompareTag(playerTag)) {
            if (!(collidedObject.GetComponent<InventoryHandler>().HasFullInventory() && itemType == 2)) {
                collidedObject.GetComponent<ItemHandler>().ItemManager(upgrade);
                Destroy(gameObject);
            }
        }
    }

    public void SetUpgrade(string upgrade) {
        this.upgrade = upgrade;
    }
}
