using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UILogic : MonoBehaviour {

    private const string SCORE_TEXT = "Score: ";
    private const string HEALTH_TEXT = "Health: ";

    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private GameObject scoreField;
    [SerializeField] private GameObject healthField;
    [SerializeField] private GameObject itemSlot;
    private PlayerInputActions inputActions;
    private GameObject[] inventory = new GameObject[0];
    
    private int currentSelectedItem = 0;

    void Start() {
        inputActions = new PlayerInputActions();
        inputActions.PlayerDefault.CycleInventory.Enable();
    }

    void Update() {
        float scrollAction = inputActions.PlayerDefault.CycleInventory.ReadValue<float>();
        if (scrollAction != 0) {
            if (scrollAction < 0) {
                scrollAction = -1;
            } else {
                scrollAction = 1;
            }
            UpdateSelectedItem((int)scrollAction);
        }
    }

    private void UpdateSelectedItem(int scrollAction) {
        inventory[currentSelectedItem].GetComponent<TextMeshProUGUI>().color = Color.white;
        currentSelectedItem += scrollAction;
        if (currentSelectedItem == -1) {
            currentSelectedItem = inventory.Length - 1;
        }
        if (currentSelectedItem == inventory.Length) {
            currentSelectedItem = 0;
        }
        inventory[currentSelectedItem].GetComponent<TextMeshProUGUI>().color = Color.red;
    }

    public void UpdateInventory(GameObject[] array) {
        for (int i = 0; i < inventory.Length; i++) {
            Destroy(inventory[i]);
        }
        inventory = new GameObject[array.Length];

        float offset = 0f;
        for (int i = 0; i < array.Length; i++) {
            inventory[i] = Instantiate(itemSlot, new Vector3(itemSlot.transform.position.x + offset, itemSlot.transform.position.y, itemSlot.transform.position.z), itemSlot.transform.rotation, transform.parent);
            if (array[i] != null) {
                inventory[i].GetComponent<TextMeshProUGUI>().text = array[i].GetComponent<GunProperties>().Name;
            } else {
                inventory[i].GetComponent<TextMeshProUGUI>().text = "null";
            }
            offset += 300f;
        }
        UpdateSelectedItem(1);
        UpdateSelectedItem(-1);
    }

    public void UpdateScore(int amount) {
        scoreField.GetComponent<TextMeshProUGUI>().SetText(SCORE_TEXT + amount.ToString());
    }

    public void UpdateHealth(int amount) {
        healthField.GetComponent<TextMeshProUGUI>().SetText(HEALTH_TEXT + amount.ToString());
    }

    public void DisableCycleInventory() {
        inputActions.PlayerDefault.CycleInventory.Disable();
    }

    public void EnableGameOverScreen() {
        gameOverScreen.SetActive(true);
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void RestartGame() {
        SceneManager.LoadScene(0);
    }

    //getters
    public float SelectedItem {
        get { return currentSelectedItem; }
    }
    public GameObject Item(int number) {
        return inventory[number];
    }
}
