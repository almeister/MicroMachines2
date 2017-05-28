using UnityEngine;
using System.Collections;

public class Vehicle : MonoBehaviour
{

    AudioSource audioSource;
    AudioClip engineIdleAudioClip;
    PlayerController playerController;
    float audioSourceStartingPitch;
    float audioSourceMaxPitch;
    float audioSourceRampUpTime = 2.0f;
    float audioSourceMaxPitchMultiplier = 5.0f;
    float audioSourceRampDownTime = 0.5f;
    float reverseAudioMaxPitchMultiplier = 3.0f;
    float reverseAudioMaxPitch;


    void Start()
    {
        playerController = GetComponent<PlayerController>();
        audioSource = GetComponent<AudioSource>();
        engineIdleAudioClip = Resources.Load<AudioClip>("Audio/SFX/Engine Idle");
        audioSource.clip = engineIdleAudioClip;
        audioSource.loop = true;
        audioSource.Play();
        audioSourceStartingPitch = audioSource.pitch;
        audioSourceMaxPitch = audioSourceMaxPitchMultiplier * audioSourceStartingPitch;
        reverseAudioMaxPitch = reverseAudioMaxPitchMultiplier * audioSourceStartingPitch;
    }

    void Update()
    {
        if (playerController.isControllerEnabled())
        {
            if (Input.GetButton("A"))
            {
                if (audioSource.pitch <= audioSourceMaxPitch)
                    audioSource.pitch += Time.deltaTime * audioSource.pitch / (audioSourceRampUpTime / audioSourceMaxPitchMultiplier);

                return;
            }

            if (Input.GetButton("B"))
            {
                if (audioSource.pitch <= reverseAudioMaxPitch)
                    audioSource.pitch += Time.deltaTime * audioSource.pitch / (audioSourceRampUpTime / reverseAudioMaxPitchMultiplier);

                return;
            }

            {
                if (audioSource.pitch > audioSourceStartingPitch)
                    audioSource.pitch -= Time.deltaTime * audioSource.pitch / audioSourceRampDownTime;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "OutOfBounds")
        {
            playerController.disable();
        }
    }
}
