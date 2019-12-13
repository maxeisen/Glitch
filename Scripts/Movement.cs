using UnityEngine;

public class Movement : MonoBehaviour
{

    // Player
    public Rigidbody rb;

    public float horizontalSpeed = 2000f;
    public float verticalSpeed = 500f;
    public Vector3 jump = new Vector3(0.0f, 2.0f, 0.0f);

    private bool grounded = true;
    private bool didLeaveGround = false;
    private bool didDie = false;
    public AudioSource jumpSound;
    public AudioSource deathSound;

    // Interaction keys
    private readonly KeyCode rightKey = KeyCode.D;
    private readonly KeyCode alternateRightKey = KeyCode.RightArrow;
    private readonly KeyCode leftKey = KeyCode.A;
    private readonly KeyCode alternateLeftKey = KeyCode.LeftArrow;
    private readonly KeyCode jumpKey = KeyCode.W;
    private readonly KeyCode alternateJumpKey = KeyCode.UpArrow;


    public GameObject[] hazards;

    void Awake() {
        rb = GetComponent<Rigidbody>();
        //hazards = GameObject.FindGameObjectsWithTag("Hazard");
    }

    // Update is called once per frame
    void FixedUpdate() {
        if (Input.GetKey(rightKey) || Input.GetKey(leftKey) || Input.GetKey(alternateRightKey) || Input.GetKey(alternateLeftKey)) {
            int direction = Input.GetKey(rightKey) || Input.GetKey(alternateRightKey) ? 1 : -1;
            rb.AddForce(direction * horizontalSpeed * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (rb.position.y < -1f) {
            deathSound.Play();
            FindObjectOfType<LevelSwitch>().PlayerDied();
        }
    }

    private void Update() {
        if (grounded) {
            if (Input.GetKeyDown(jumpKey) || Input.GetKey(alternateJumpKey)) {
                jumpSound.Play();
                rb.AddForce(jump * verticalSpeed, ForceMode.Impulse);
                grounded = false;
            }
        }
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Plane") || collision.gameObject.CompareTag("FinalPlatform") || collision.gameObject.CompareTag("Button")) {
            if (!didLeaveGround) {
                // show spikes
                if (hazards.Length != 0) {
                    foreach (GameObject hazard in hazards) {
                        hazard.SetActive(true);
                    }
                }
                didLeaveGround = true;
            }
            grounded = true;
        } else {
            if (collision.gameObject.CompareTag("Hazard")) { // collide with spikes
                if (didLeaveGround && !didDie) {
                    didDie = true;
                    deathSound.Play();
                    FindObjectOfType<LevelSwitch>().PlayerDied();
                }
            } else grounded |= collision.gameObject.CompareTag("Ground");
        }
    }
}
