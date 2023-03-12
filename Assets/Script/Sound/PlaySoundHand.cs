using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundHand : MonoBehaviour
{
    private AudioSource AudioS;
    public static bool PlaySound = false;
    void Start()
    {
        AudioS = this.gameObject.GetComponent<AudioSource>();
    }

    void Update()
    {
        if (PlaySound)
        {
            AudioS.Play();
            PlaySound = false;
        }
    }
}
