using UnityEngine;

public class InventoryHandler : MonoBehaviour {

    [SerializeField] private GameObject UILogicManager;
    private GameObject[] inventory;

    [SerializeField] private int inventorySlots = 3;

    void Start() {
        inventory = new GameObject[inventorySlots];
        UpdateInventory();
    }

    public void AddItemToInventory(GameObject item) {
        if (inventory[(int)UILogicManager.GetComponent<UILogic>().SelectedItem] == null) {
            inventory[(int)UILogicManager.GetComponent<UILogic>().SelectedItem] = item;
        } else {
            for (int i = 0; i < inventory.Length; i++) {
                if (inventory[i] == null) {
                    inventory[i] = item;
                    break;
                }
            }
        }
        UpdateInventory();
    }

    public void UpdateInventory() {
        UILogicManager.GetComponent<UILogic>().UpdateInventory(inventory);
    }

    //getters
    public GameObject[] Inventory {
        get { return inventory; }
    }
}
