using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelNumber : MonoBehaviour {

    public TextMeshPro levelNumber;

    // Start is called before the first frame update
    void Awake() {
        levelNumber = GetComponent<TextMeshPro>();
    }
}
