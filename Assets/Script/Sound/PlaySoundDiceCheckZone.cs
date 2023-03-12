using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundDiceCheckZone : MonoBehaviour
{
    private AudioSource AudioS;
    void Start()
    {
        AudioS = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter()
    {
        //Here sound
        if (!AudioS.isPlaying)
            AudioS.Play();
    }
}
