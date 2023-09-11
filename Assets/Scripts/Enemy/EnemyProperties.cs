using UnityEngine;

public class EnemyProperties : MonoBehaviour {

    private const string playerTag = "Player";

    [SerializeField] private int maxHealth = 100;
    private float health;
    [SerializeField] private int score = 10;
    [SerializeField] private int collisionDamage = 20;

    private void Start() {
        health = maxHealth;
    }

    public void TakeDamage(int amount) {
        health -= amount;
        if (health <= 0) {
            Destroy(gameObject);
        }
        GetComponentInChildren<EnemyHealthBar>().ReduceHealth(health, maxHealth);
    }

    private void OnCollisionEnter(Collision collision) {
        GameObject hitObject = collision.gameObject;
        if (hitObject.CompareTag(playerTag)) {
            hitObject.GetComponent<PlayerProperties>().TakeDamage(collisionDamage);
        }
    }

    //getters
    public float Health {
        get { return health; }
    }
    public float Score {
        get { return score; }
    }
}
