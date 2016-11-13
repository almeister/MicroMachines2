using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    private float drivePower = 10;
    private float maxSpeed = 20;
    private float turningPower = 5;
    private float friction = 3;
    private Vector2 currentSpeed;
    private Rigidbody2D rigidBody;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.gravityScale = 0;
    }

    void FixedUpdate()
    {
        currentSpeed = new Vector2(rigidBody.velocity.x, rigidBody.velocity.y);

        if (currentSpeed.magnitude > maxSpeed)
        {
            currentSpeed = currentSpeed.normalized;
            currentSpeed *= maxSpeed;
        }

        if (Input.GetButton("A"))
        {
            rigidBody.AddForce(transform.up * drivePower);
            rigidBody.drag = friction;
        }
        if (Input.GetButton("B"))
        {
            rigidBody.AddForce(-(transform.up) * (drivePower / 2));
            rigidBody.drag = friction;
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            transform.Rotate(Vector3.forward * turningPower);
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            transform.Rotate(Vector3.forward * -turningPower);
        }

        noGas();
    }

    void noGas()
    {
        bool gas;
        if (Input.GetButton("A") || Input.GetButton("B"))
        {
            gas = true;
        }
        else
        {
            gas = false;
        }

        if (!gas)
        {
            rigidBody.drag = friction * 2;
        }
    }
}
