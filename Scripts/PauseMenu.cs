using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public static bool isPaused = false;
    public GameObject pauseLevelUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)) {
            if (isPaused) {
                Resume();
            } else {
                Pause();
            }
        } else if (Input.GetKeyDown(KeyCode.Q)) {
            Application.Quit();
        } else if (Input.GetKeyDown(KeyCode.M)) {
            SceneManager.LoadScene("Menu");
            Resume();
        }
    }

    void Resume() {
        isPaused = false;
        Time.timeScale = 1;
        pauseLevelUI.SetActive(false);

    }

    void Pause() {
        isPaused = true;
        Time.timeScale = 0;
        pauseLevelUI.SetActive(true);
    }
}
