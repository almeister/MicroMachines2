using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    private const float drivePower = 10;
    private const float brakePower = 2;
    private const float reversePower = 5;
    private const float turningPower = 5;
    private const float brakeRestTime = 0.3f;

    private Rigidbody2D rigidBody;
    private float friction = 3;
    private float previousSpeed = 0.0f;
    private float timeAtRest = 0.0f;
    private bool isResting = false;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.gravityScale = 0;
    }

    void FixedUpdate()
    {
        if (Input.GetButton("A"))
        {
            rigidBody.AddForce(transform.up * drivePower);
            rigidBody.drag = friction;
        }

        if (Input.GetButton("B"))
        {
            float currentSpeed = transform.InverseTransformDirection(rigidBody.velocity).y;

            if (previousSpeed > 0 && currentSpeed <= 0 || isResting)
            {
                timeAtRest += Time.deltaTime;
                isResting = true;

                if (timeAtRest >= brakeRestTime)
                {
                    timeAtRest = 0.0f;
                    isResting = false;
                }
            }

            if (isResting)
            {
                // Resting... wait
            }
            else if (currentSpeed > 0)
                rigidBody.AddForce(-(transform.up) * (brakePower));
            else
                rigidBody.AddForce(-(transform.up) * (reversePower));

            rigidBody.drag = friction;
            previousSpeed = currentSpeed;
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
        bool gas = false;
        if (Input.GetButton("A") || Input.GetButton("B"))
        {
            gas = true;
        }

        if (!gas)
        {
            rigidBody.drag = friction * 1.5f;
        }
    }
}
