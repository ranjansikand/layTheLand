using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAudio : MonoBehaviour
{
    public delegate void AudioEvent(int val, float mod = 1f);
    public static AudioEvent playSound;

    AudioSource audioSource;
    float audioVolume = 0.5f;

    [SerializeField] AudioClip[] clips;


    private void OnEnable() {
        audioSource = GetComponent<AudioSource>();

        playSound += PlaySound;
    }

    private void OnDisable() {
        playSound -= PlaySound;
    }

    private void PlaySound(int val, float mod = 1f) {
        audioSource.pitch = Random.Range(0.9f, 1.1f);
        audioSource.PlayOneShot(clips[val], audioVolume * mod);
    }
}
