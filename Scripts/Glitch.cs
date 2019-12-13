using UnityEngine;

public class Glitch : MonoBehaviour
{

    public GameObject player;
    public GameObject ground;
    public GameObject[] normalPlatforms;
    public GameObject[] glitchPlatforms;
    public GameObject finalPlatform;
    public Camera cam;
    public Material pSkin1;
    public Material pSkin2;
    public AudioSource glitchSound;

    private readonly Color mainColor = new Color(245f/255f, 245f/255f, 245f/255f);
    private readonly Color glitchColor = Color.black;
    private readonly Color mainBackgroundColor = new Color(0.1560609f, 0.1724146f, 0.1981132f, 0f);

    private bool isGlitched = false;
    private readonly KeyCode glitchKey = KeyCode.Space;

    private void Start()
    {
        pSkin1 = Resources.Load("StandardPlayerSkin", typeof(Material)) as Material;
        pSkin2 = Resources.Load("GlitchedPlayerSkin", typeof(Material)) as Material;
        cam = GetComponent<Camera>();
        //cam.clearFlags = CameraClearFlags.SolidColor;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(glitchKey))
        {
            glitchSound.Play(0);
            GlitchComponents();
        }
    }


    private void GlitchComponents()
    {
        // Change background colour
        cam.backgroundColor = isGlitched ? mainBackgroundColor : mainColor;
        // Change player colour
        player.GetComponent<Renderer>().material = isGlitched ? pSkin1 : pSkin2;
        // Change ground colour
        ground.GetComponent<Renderer>().material.color = isGlitched ? mainColor : glitchColor;
        // Change platform colours
        foreach (GameObject platform in normalPlatforms) {
            platform.GetComponent<Renderer>().material.color = isGlitched ? glitchColor : Color.white;
            platform.SetActive(!isGlitched);
        }

        foreach (GameObject platform in glitchPlatforms) {
            platform.GetComponent<Renderer>().material.color = isGlitched ? glitchColor : Color.white;
            platform.SetActive(isGlitched);
        }

        isGlitched = !isGlitched;
    }
}
