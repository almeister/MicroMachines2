using UnityEngine;
using System.Collections;

public class Vehicle : MonoBehaviour {

    private AudioSource audioSource;
    private AudioClip engineIdleAudioClip;

	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
        engineIdleAudioClip = Resources.Load<AudioClip>("Audio/SFX/Engine Idle");
        audioSource.clip = engineIdleAudioClip;
        audioSource.loop = true;
        audioSource.Play();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
