using UnityEngine;

public class PlayerProperties : MonoBehaviour {

    [SerializeField] private GameObject UILogicManager;
    private AudioHandler playerAudio;

    [SerializeField] private int maxHealth = 100;
    private float health;
    private int score;

    private void Start() {
        playerAudio = GetComponent<AudioHandler>();
        health = maxHealth;
        score = 0;
        UILogicManager.GetComponent<UILogic>().UpdateScore(score);
        UILogicManager.GetComponent<UILogic>().UpdateHealth(health, maxHealth);
    }

    public void TakeDamage(int amount) {
        health -= amount;
        UILogicManager.GetComponent<UILogic>().UpdateHealth(health, maxHealth);
        if (health <= 0) {
            gameObject.GetComponent<PlayerMovement>().DisableInput();
            gameObject.GetComponent<WeaponHandler>().DisableInput();
            UILogicManager.GetComponent<UILogic>().DisableInput();
            UILogicManager.GetComponent<UILogic>().EnableGameOverScreen();
        }
        if (health <= 0) {
            playerAudio.Death();
        } else if (amount >= 0) {
            playerAudio.Damage();
        } else {
            //todo heal
        }
    }

    public void AddScore(int amount) {
        score += amount;
        UILogicManager.GetComponent<UILogic>().UpdateScore(score);
    }

    //getters
    public float Health {
        get { return health; }
    }
    public float Score {
        get { return score; }
    }
}
