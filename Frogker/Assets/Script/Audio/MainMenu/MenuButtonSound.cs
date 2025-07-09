using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuButtonSound : MonoBehaviour, ISelectHandler
{
    public AudioClip hoverSound;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GameObject.Find("ButtonSoundMixer").GetComponent<AudioSource>();
    }

    public void OnSelect(BaseEventData eventData)
    {
        if (hoverSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(hoverSound);
        }
    }
}
