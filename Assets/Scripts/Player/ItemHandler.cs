using UnityEngine;

public class ItemHandler : MonoBehaviour {

    [SerializeField] private GameObject pistol;
    [SerializeField] private GameObject rifle;

    private InventoryHandler inventoryHandler;
    private MovementProperties movementProperties;

    private void Start() {
        inventoryHandler = GetComponent<InventoryHandler>();
        movementProperties = GetComponent<MovementProperties>();
    }

    public void ItemManager(string modifier) {  //UPGRADE|SINGLEUSE|WEAPON|COLLECTIBLE
        switch (modifier) {
            case "UPGRADEIncreaseMaxAmountOfJumps":
            movementProperties.IncreaseMaxAmountOfJumps();
            break;
            case "UPGRADEIncreaseInventorySize":
            inventoryHandler.IncreaseInventorySize();
            break;
            case "WEAPONPistol":
            inventoryHandler.AddItemToInventory(Instantiate(pistol, transform));
            break;
            case "WEAPONRifle":
            inventoryHandler.AddItemToInventory(Instantiate(rifle, transform));
            break;
            default:
            Debug.Log("Modifier Error - " + modifier);
            break;
        }
    }
}
