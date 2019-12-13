using UnityEngine;

public class CameraMovement : MonoBehaviour {
    public Transform player;
    public Vector3 offset;

    private void Start() {
        transform.position = player.position + offset;
    }

    // Update is called once per frame
    void Update() {
        transform.position = player.position + offset;
    }
}
