using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour {

    private const string playerTag = "Player";
    private const string playerLayerName = "Player";
    private const string groundLayerName = "Ground";

    [SerializeField] private GameObject bullet;

    private NavMeshAgent navMesh;
    private Transform player;

    private LayerMask playerLayer;
    private LayerMask groundLayer;
    private float rayLength;

    private Vector3 walkPoint;
    private bool walkPointSet;
    [SerializeField] private float walkPointRange = 2f;

    [SerializeField] private float sightRange = 10f, attackRange = 6f;
    private bool playerInSightRange, playerInAttackRange;

    [SerializeField] private float timeBetweenAttacks = 1f;
    private bool alreadyAttacked;

    void Start() {
        navMesh = GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag(playerTag).transform;
        playerLayer = LayerMask.GetMask(playerLayerName);
        groundLayer = LayerMask.GetMask(groundLayerName);
        rayLength = GetComponent<CapsuleCollider>().height / 2;
        rayLength += 0.003f;
    }

    void Update() {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, playerLayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, playerLayer);
        if (!playerInSightRange && !playerInAttackRange) {
            Patrol();
        }
        if (playerInSightRange && !playerInAttackRange) {
            ChasePlayer();
        }
        if (playerInSightRange && playerInAttackRange) {
            Attack();
        }
    }

    private void Patrol() {
        if (!walkPointSet) {
            SearchWalkPoint();
        }
        if (walkPointSet) {
            navMesh.SetDestination(walkPoint);
        }

        Vector3 distanceToWalkPoint = transform.position - walkPoint;
        if (distanceToWalkPoint.magnitude < 1f) {
            walkPointSet = false;
        }
    }

    private void SearchWalkPoint() {
        float randomX = Random.Range(-walkPointRange, walkPointRange);
        float randomZ = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
        if (Physics.Raycast(transform.position, Vector3.down, out _, rayLength, groundLayer)) {
            walkPointSet = true;
        }
    }

    private void ChasePlayer() {
        navMesh.SetDestination(player.position);
    }

    private void Attack() {
        navMesh.SetDestination(transform.position);
        transform.LookAt(player);

        if (!alreadyAttacked) {
            GameObject newBullet = Instantiate(bullet, transform.position, transform.rotation);
            newBullet.GetComponent<BulletMovement>().SetGunCarrier(transform.gameObject);
            newBullet.GetComponent<BulletMovement>().SetDirection(transform.forward); //keep everything above this line

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void ResetAttack() {
        alreadyAttacked = false;
    }
}
