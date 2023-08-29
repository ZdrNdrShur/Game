using UnityEngine;

public class MovementProperties : MonoBehaviour {

    private const string groundLayerName = "Ground";

    private AudioHandler playerAudio;

    private LayerMask groundLayer;
    private float rayLength;

    [SerializeField] private float speedXZ = 5f;
    [SerializeField] private float speedY = 4f;
    [SerializeField] private int maxAmountOfJumps = 1;
    private int currentNumberOfJumps;

    void Start() {
        playerAudio = GetComponent<AudioHandler>();
        groundLayer = LayerMask.GetMask(groundLayerName);
        rayLength = GetComponent<CapsuleCollider>().height / 2;
        rayLength += 0.003f;
        Ground();
    }

    public void Ground() {
        currentNumberOfJumps = 0;
    }

    private void Jump() {
        currentNumberOfJumps++;
    }

    public bool CanJump() {
        if (IsGrounded()) {
            Jump();
            playerAudio.Jump();
            return true;
        } else {
            if (currentNumberOfJumps == 0) {
                Jump();
            }
            if (currentNumberOfJumps < maxAmountOfJumps) {
                Jump();
                playerAudio.Jump();
                return true;
            }
        }
        return false;
    }

    private bool IsGrounded() {
        if (Physics.Raycast(transform.position, Vector3.down, out _, rayLength, groundLayer)) {
            Ground();
            return true;
        }
        return false;
    }

    //upgrades
    public void IncreaseMaxAmountOfJumps() {
        maxAmountOfJumps++;
    }

    //getters
    public float SpeedXZ {
        get { return speedXZ; }
    }
    public float SpeedY {
        get { return speedY; }
    }
}
