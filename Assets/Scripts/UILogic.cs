using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UILogic : MonoBehaviour {

    private const string SCORE_TEXT = "Score: ";
    private const string HEALTH_TEXT = "Health: ";

    [SerializeField] private GameObject player;
    [SerializeField] private GameObject item;
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private GameObject scoreField;
    [SerializeField] private GameObject healthField;
    [SerializeField] private GameObject itemSlot;

    private PlayerInputActions inputActions;
    private GameObject[] inventory = new GameObject[0];     //Q: If I move the "= new GameObject[0]" to Start() I get an error. Why(am I not getting error now)?

    [SerializeField] private float distanceBetweenItemSlots = 50f;
    [SerializeField] private float spawnedItemDistanceMultiplyer = 3f;

    private int currentSelectedItem;

    private void Start() {
        inputActions = new PlayerInputActions();
        inputActions.PlayerDefault.CycleInventory.Enable();
        inputActions.PlayerDefault.DropWeapon.Enable();
        currentSelectedItem = 0;
    }

    private void Update() {
        float scrollAction = inputActions.PlayerDefault.CycleInventory.ReadValue<float>();
        if (scrollAction != 0) {
            if (scrollAction < 0) {
                scrollAction = -1;
            } else {
                scrollAction = 1;
            }
            UpdateSelectedItem((int)scrollAction);
        }
        if (inputActions.PlayerDefault.DropWeapon.triggered) {
            if (player.GetComponent<InventoryHandler>().Inventory[currentSelectedItem] != null) {
                GameObject itemInstance = item;
                itemInstance.GetComponent<ItemFunctionality>().SetUpgrade(player.GetComponent<InventoryHandler>().Inventory[currentSelectedItem].GetComponent<GunProperties>().ItemName());
                player.GetComponent<InventoryHandler>().DropItem(currentSelectedItem);
                Vector3 playerPosition = player.transform.position + player.transform.forward * spawnedItemDistanceMultiplyer;      //spawns the item ahead of the player
                Instantiate(itemInstance, playerPosition, player.transform.rotation, player.transform.parent);
            }
        }
    }

    public void UpdateInventory(GameObject[] array) {
        for (int i = 0; i < inventory.Length; i++) {
            Destroy(inventory[i]);
        }
        inventory = new GameObject[array.Length];

        float offset = transform.parent.GetComponent<RectTransform>().rect.width;
        offset -= itemSlot.GetComponent<RectTransform>().rect.width * inventory.Length;
        offset -= distanceBetweenItemSlots * (inventory.Length - 1);
        offset /= 2;
        offset -= itemSlot.GetComponent<RectTransform>().rect.width / 2;

        for (int i = 0; i < array.Length; i++) {
            inventory[i] = Instantiate(itemSlot, new Vector3(offset, itemSlot.transform.position.y, itemSlot.transform.position.z), itemSlot.transform.rotation, transform.parent);
            if (array[i] != null) {
                inventory[i].GetComponent<TextMeshProUGUI>().text = array[i].GetComponent<GunProperties>().Name;
                inventory[i].GetComponentInChildren<Image>().enabled = true;
                inventory[i].GetComponentInChildren<Image>().sprite = array[i].GetComponent<GunProperties>().Sprite;
            } else {
                inventory[i].GetComponent<TextMeshProUGUI>().text = "no item";
                inventory[i].GetComponentInChildren<Image>().enabled = false;

            }
            offset += itemSlot.GetComponent<RectTransform>().rect.width + distanceBetweenItemSlots;
        }
        UpdateSelectedItem(1);
        UpdateSelectedItem(-1);     //refresh
    }

    private void UpdateSelectedItem(int scrollAction) {
        inventory[currentSelectedItem].GetComponent<TextMeshProUGUI>().color = Color.white;
        int oldIndex = currentSelectedItem;
        currentSelectedItem += scrollAction;
        if (currentSelectedItem == -1) {
            currentSelectedItem = inventory.Length - 1;
        }
        if (currentSelectedItem == inventory.Length) {
            currentSelectedItem = 0;
        }
        int newIndex = currentSelectedItem;
        inventory[currentSelectedItem].GetComponent<TextMeshProUGUI>().color = Color.red;
        player.GetComponent<InventoryHandler>().SwitchItem(oldIndex, newIndex);
    }

    public void UpdateScore(int amount) {
        scoreField.GetComponent<TextMeshProUGUI>().SetText(SCORE_TEXT + amount.ToString());
    }

    public void UpdateHealth(float amount, int maxAmount) {
        healthField.GetComponent<Slider>().value = amount / maxAmount;
        healthField.GetComponentInChildren<TextMeshProUGUI>().SetText(HEALTH_TEXT + amount.ToString());
    }

    public void EnableGameOverScreen() {
        gameOverScreen.SetActive(true);
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void RestartGame() {
        SceneManager.LoadScene(0);
    }

    public void DisableInput() {
        inputActions.PlayerDefault.CycleInventory.Disable();
        inputActions.PlayerDefault.DropWeapon.Disable();
    }

    //getters
    public int SelectedItem {
        get { return currentSelectedItem; }
    }
    public GameObject Item(int number) {
        return inventory[number];
    }
}
