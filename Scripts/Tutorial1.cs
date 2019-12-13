using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Tutorial1 : MonoBehaviour
{

    public bool wKey = false;
    public bool dKey = false;
    public bool aKey = false;
    public TextMeshProUGUI wKeyText;
    public TextMeshProUGUI dKeyText;
    public TextMeshProUGUI aKeyText;


    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            wKeyText.text = "";
        }

        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            dKeyText.text = "";
        }

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            aKeyText.text = "";
        }

        if (string.Equals(wKeyText.text, "") && string.Equals(dKeyText.text, "") && string.Equals(aKeyText.text, ""))
        {
            StartCoroutine(Next());
        }
    }

    IEnumerator Next()
    {
        dKeyText.text = "Nice Job!\nNow let's try Glitching";
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
