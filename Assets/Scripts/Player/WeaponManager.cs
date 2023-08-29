using UnityEngine;

public class WeaponHandler : MonoBehaviour {

    [SerializeField] private GameObject UILogicManager;
    private PlayerInputActions inputActions;
    private InventoryHandler inventoryHandler;

    void Start() {
        inputActions = new PlayerInputActions();
        inputActions.PlayerDefault.Shoot.Enable();
        inventoryHandler = GetComponent<InventoryHandler>();
    }

    void Update() {
        if (inputActions.PlayerDefault.Shoot.triggered) {
            if (inventoryHandler.Inventory[(int)UILogicManager.GetComponent<UILogic>().SelectedItem] != null) {
                inventoryHandler.Inventory[(int)UILogicManager.GetComponent<UILogic>().SelectedItem].GetComponent<GunProperties>().Shoot();
            }
        }
    }

    public void DisableShoot() {
        inputActions.PlayerDefault.Shoot.Disable();
    }
}
