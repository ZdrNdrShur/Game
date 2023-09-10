using UnityEngine;

public class WeaponHandler : MonoBehaviour {

    [SerializeField] private GameObject UILogicManager;
    private PlayerInputActions inputActions;
    private InventoryHandler inventoryHandler;
    private bool isShooting = false;

    private void Start() {
        inputActions = new PlayerInputActions();
        inputActions.PlayerDefault.Shoot.Enable();
        inputActions.PlayerDefault.ToggleAuto.Enable();
        inventoryHandler = GetComponent<InventoryHandler>();
        inputActions.PlayerDefault.Shoot.started += ctx => StartShooting();
        inputActions.PlayerDefault.Shoot.canceled += ctx => EndShooting();
    }

    private void Update() {
        if (inventoryHandler.Inventory[UILogicManager.GetComponent<UILogic>().SelectedItem] != null) {
            if (inventoryHandler.Inventory[UILogicManager.GetComponent<UILogic>().SelectedItem].GetComponent<GunProperties>().Auto) {
                if (isShooting) {
                    TryToShoot();
                }
            } else {
                if (inputActions.PlayerDefault.Shoot.triggered) {
                    TryToShoot();
                }
            }
            if (inputActions.PlayerDefault.ToggleAuto.triggered) {
                inventoryHandler.Inventory[UILogicManager.GetComponent<UILogic>().SelectedItem].GetComponent<GunProperties>().ToggleAuto();
            }
        }
    }

    private void StartShooting() {
        isShooting = true;
    }

    private void EndShooting() {
        isShooting = false;
    }

    private void TryToShoot() {
        if (inventoryHandler.Inventory[UILogicManager.GetComponent<UILogic>().SelectedItem] != null) {
            inventoryHandler.Inventory[UILogicManager.GetComponent<UILogic>().SelectedItem].GetComponent<GunProperties>().Shoot(inventoryHandler.Inventory[UILogicManager.GetComponent<UILogic>().SelectedItem]);
        }
    }

    public void DisableInput() {
        inputActions.PlayerDefault.Shoot.Disable();
        inputActions.PlayerDefault.ToggleAuto.Disable();
    }
}
