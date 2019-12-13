using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Tutorial2 : MonoBehaviour
{

    public bool spaceKey = false;
    public TextMeshProUGUI spaceKeyText;
    public AudioSource levelCompleteSound;
    public bool levelSoundPlaying = false;


    // Update is called once per frame
    void Update()
    {
        spaceKey = Input.GetKeyDown("space");

        if (spaceKey) {
            spaceKeyText.text = "Get to the checkered platform";
        }

        if (Menu.tutorialComplete)
        {
            StartCoroutine(Next());
        }
    }

    IEnumerator Next()
    {
        yield return new WaitForSeconds(2);
        FinishTutorial();
    }

    void FinishTutorial()
    {
        StopCoroutine(Next());
        if (!levelSoundPlaying)
        {
            levelCompleteSound.Play();
            levelSoundPlaying = true;
        }
        spaceKeyText.text = "Tutorial Complete\nPress <C> to continue";
        if (Input.GetKeyDown("c"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("FinalPlatform"))
        {
            Menu.tutorialComplete = true;
            spaceKeyText.text = "Stay on the platform for 2 seconds";
        }
    }
}
