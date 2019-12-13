using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level5 : MonoBehaviour
{

    public GameObject hazard;
    public AudioSource buttonSound;
    public GameObject button;
    public Color buttonColor;

    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Button"))
        {
            buttonColor = button.GetComponent<Renderer>().material.color;
            buttonColor.a = 0.5f;
            button.GetComponent<Renderer>().material.color = buttonColor;
            buttonSound.Play();
            hazard.SetActive(false);
        }
    }
}
