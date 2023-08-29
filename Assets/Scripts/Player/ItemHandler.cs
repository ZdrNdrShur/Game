using UnityEngine;

public class ItemHandler : MonoBehaviour {

    [SerializeField] private GameObject gun;

    private InventoryHandler inventoryHandler;
    private MovementProperties movementProperties;

    void Start() {
        inventoryHandler = GetComponent<InventoryHandler>();
        movementProperties = GetComponent<MovementProperties>();
    }

    public void ItemManager(string modifier) {  //UPGRADE|SINGLEUSE|WEAPON|COLLECTIBLE
        switch (modifier) {
            case "UPGRADEIncreaseMaxAmountOfJumps":
            movementProperties.IncreaseMaxAmountOfJumps();
            break;
            case "WEAPONBasicGun":
            inventoryHandler.AddItemToInventory(Instantiate(gun, transform));
            break;
            default:
            Debug.Log("Modifier Error - " + modifier);
            break;
        }
    }
}
