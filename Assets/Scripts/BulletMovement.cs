using UnityEngine;

public class BulletMovement : MonoBehaviour {

    private const string playerTag = "Player";
    private const string enemyTag = "Enemy";
    private const string wallTag = "Wall";

    private Rigidbody rigidBody;
    private GameObject gunCarrier;

    [SerializeField] private float damage = 50f;
    [SerializeField] private float speed = 10f;
    [SerializeField] private float maxDistance = 500f;
    private Vector3 direction;
    private Vector3 initialPosition;

    void Start() {
        rigidBody = GetComponent<Rigidbody>();
    }

    void Update() {
        if (initialPosition != null) {
            if (Vector3.Distance(initialPosition, transform.position) < maxDistance) {
                rigidBody.velocity = direction * speed;
                Debug.Log(Vector3.Distance(initialPosition, transform.position));
            } else {
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter(Collider collision) {
        GameObject hitObject = collision.gameObject;
        if (hitObject.CompareTag(playerTag) && !gunCarrier.CompareTag(playerTag)) {
            hitObject.GetComponent<PlayerProperties>().TakeDamage((int)damage);
            Destroy(gameObject);
        }
        if (hitObject.CompareTag(enemyTag) && !gunCarrier.CompareTag(enemyTag)) {
            if (hitObject.GetComponent<EnemyProperties>().Health <= damage) {
                gunCarrier.GetComponent<PlayerProperties>().AddScore((int)hitObject.GetComponent<EnemyProperties>().Score);
            }
            hitObject.GetComponent<EnemyProperties>().TakeDamage((int)damage);
            Destroy(gameObject);
        }
        if (hitObject.CompareTag(wallTag)) {
            Destroy(gameObject);
        }
    }

    //setters
    public void SetDirection(Vector3 vector) {
        direction = vector;
    }
    public void SetInitialPosition(Vector3 vector) {
        initialPosition = vector;
    }
    public void SetGunCarrier(GameObject player) {
        gunCarrier = player;
    }
}
