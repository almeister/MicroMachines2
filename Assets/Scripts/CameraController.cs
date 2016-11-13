using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    private Transform player1Transform;
    private Vector3 offset;

    // Use this for initialization
    void Start () {
        GameObject player1 = GameObject.Find("Player1");

        if(!player1)
            Debug.LogError("CameraController::Start no player1 found.");

        this.player1Transform = player1.transform;
        offset.Set(0f, 0.5f, -10f);
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(player1Transform.position.x + offset.x, player1Transform.position.y + offset.y, offset.z);
    }
}
