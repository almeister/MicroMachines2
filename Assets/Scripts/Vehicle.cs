using UnityEngine;
using System.Collections;

public class Vehicle : MonoBehaviour {

    private AudioSource audioSource;
    private AudioClip engineIdleAudioClip;
    private float audioSourceStartingPitch;
    private float audioSourceMaxPitch;
    private float audioSourceRampUpTime = 2.0f;
    private float audioSourceMaxPitchMultiplier = 5.0f;
    private float audioSourceRampDownTime = 0.5f;
    private float reverseAudioMaxPitchMultiplier = 3.0f;
    private float reverseAudioMaxPitch;

    // Use this for initialization
    void Start () {
        audioSource = GetComponent<AudioSource>();
        engineIdleAudioClip = Resources.Load<AudioClip>("Audio/SFX/Engine Idle");
        audioSource.clip = engineIdleAudioClip;
        audioSource.loop = true;
        audioSource.Play();
        audioSourceStartingPitch = audioSource.pitch;
        audioSourceMaxPitch = audioSourceMaxPitchMultiplier * audioSourceStartingPitch;
        reverseAudioMaxPitch = reverseAudioMaxPitchMultiplier * audioSourceStartingPitch;
    }

    // Update is called once per frame
    void Update () {
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
