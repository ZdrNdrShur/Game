using UnityEngine;

public class InventoryHandler : MonoBehaviour {

    private const int maxAmountOfInventorySlots = 6;

    [SerializeField] private GameObject UILogicManager;
    private GameObject[] inventory;

    [SerializeField] private int inventorySlots = 3;

    private void Start() {
        inventory = new GameObject[inventorySlots];
        UpdateInventory();
    }

    public void AddItemToInventory(GameObject item) {
        if (inventory[UILogicManager.GetComponent<UILogic>().SelectedItem] != null) {
            item.GetComponentInChildren<MeshRenderer>().enabled = false;        //if you are already holding an item, the new won't be visible
        }
        if (inventory[UILogicManager.GetComponent<UILogic>().SelectedItem] == null) {
            inventory[UILogicManager.GetComponent<UILogic>().SelectedItem] = item;      //it will first try to give the item to the selected slot
        } else {
            for (int i = 0; i < inventory.Length; i++) {
                if (inventory[i] == null) {
                    inventory[i] = item;        //if it fails, it will give it to the first empty slot
                    break;
                }
            }
        }
        UpdateInventory();
    }

    public void DropItem(int inventorySlot) {
        Destroy(inventory[inventorySlot]);
        inventory[inventorySlot] = null;
        UpdateInventory();
    }

    public void SwitchItem(int inventorySlot1, int inventorySlot2) {
        if (inventory[inventorySlot1] != null) {
            inventory[inventorySlot1].GetComponentInChildren<MeshRenderer>().enabled = false;
        }
        if (inventory[inventorySlot2] != null) {
            inventory[inventorySlot2].GetComponentInChildren<MeshRenderer>().enabled = true;
        }
    }

    public bool HasFullInventory() {
        for (int i = 0; i < inventory.Length; i++) {
            if (inventory[i] == null) {
                return false;
            }
        }
        return true;
    }

    private void UpdateInventory() {
        UILogicManager.GetComponent<UILogic>().UpdateInventory(inventory);
    }

    //upgrades
    public void IncreaseInventorySize() {
        if (inventorySlots < maxAmountOfInventorySlots) {
            inventorySlots++;
            GameObject[] oldInventory = inventory;
            inventory = new GameObject[inventorySlots];
            for (int i = 0; i < oldInventory.Length; i++) {
                inventory[i] = oldInventory[i];
            }
            UpdateInventory();
        }
    }

    //getters
    public GameObject[] Inventory {
        get { return inventory; }
    }
}
