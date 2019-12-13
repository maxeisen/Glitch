using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public static bool tutorialComplete = false;
    public AudioSource bgMusic;

    private void Awake()
    {
        if (!BackgroundAudio.audioStatus)
        {
            bgMusic.Play();
            BackgroundAudio.audioStatus = true;
            DontDestroyOnLoad(bgMusic.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            if (tutorialComplete) {
                SceneManager.LoadScene("Level01");
            } else {
                SceneManager.LoadScene("Tutorial1");
            }
        }

        if (Input.GetKeyDown(KeyCode.C)) {
            SceneManager.LoadScene("Credits");
        }
    }
}
