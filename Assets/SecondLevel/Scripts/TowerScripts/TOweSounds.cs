using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TOweSounds : MonoBehaviour
{
    private AudioSource audio;
    public AudioClip sound;
    void Start()
    {
        audio = GetComponent<AudioSource>();
        StartCoroutine(Timer());
    }

 
    IEnumerator Timer()
    {
        audio.PlayOneShot(sound);
        yield return new WaitForSeconds(8);
        StartCoroutine(Timer());
    }
}
