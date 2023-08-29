using UnityEngine;

public class EnemyProperties : MonoBehaviour {

    private const string playerTag = "Player";

    [SerializeField] private int health = 100;
    [SerializeField] private int score = 10;
    [SerializeField] private int damage = 20;

    public void TakeDamage(int amount) {
        health -= amount;
        if (health <= 0) {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision) {
        GameObject hitObject = collision.gameObject;
        if (hitObject.tag == playerTag) {
            hitObject.GetComponent<PlayerProperties>().TakeDamage(damage);
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
