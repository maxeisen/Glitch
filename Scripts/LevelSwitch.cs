using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelSwitch : MonoBehaviour {
    public bool levelComplete;
    public GameObject levelCompletePanel;
    public GameObject playerDeadPanel;
    public AudioSource levelCompleteSound;

    public TextMeshProUGUI levelCompleteText;
    public bool gameHasEnded = false;
    public float restartDelay = 1f;
    public bool levelSoundPlaying = false;

    private float collisionDuration = 0f;
    private readonly float maxCollisionDuration = 1.5f;
    private bool startCountingTrigger = false;
    void Start() {
        levelCompletePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update() {
        if (startCountingTrigger) {
            collisionDuration += Time.deltaTime;
            levelComplete |= collisionDuration >= maxCollisionDuration;
        }

        if (levelComplete && !levelSoundPlaying) {
            levelCompletePanel.SetActive(true);
            FindObjectOfType<Movement>().enabled = false;
            levelCompleteSound.Play();
            levelSoundPlaying = true;
        }
        if (Input.GetKeyDown("c") && levelComplete)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    private void OnCollisionEnter(Collision collision) {
        startCountingTrigger |= collision.gameObject.CompareTag("FinalPlatform");
    }


    private void OnCollisionExit(Collision collision) {
        if (collision.gameObject.CompareTag("FinalPlatform")) {
            collisionDuration = 0f;
            startCountingTrigger = false;
        }
    }

    public void PlayerDied() {
        if (!gameHasEnded) {
            if (playerDeadPanel != null) {
                playerDeadPanel.SetActive(true);
            }
            gameHasEnded = true;
            FindObjectOfType<Movement>().enabled = false;
            Invoke("Restart", restartDelay);
        }
    }

    private void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}