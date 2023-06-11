using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundGameController : MonoBehaviour
{
    private AudioSource[] sesKaynaklari;
    public static SoundGameController instanceSoundControl;
    float sesSeviyesi = 1;

    private void Start()
    {
        if (instanceSoundControl != null)
        {
            Destroy(this.gameObject);
            return;
        }
        DontDestroyOnLoad(this.gameObject);
        instanceSoundControl = this;
    }

    private void Update()
    {
        sesKaynaklari = FindObjectsOfType<AudioSource>();
        
        // Ses seviyesini güncelle
        if (SoundOptions.instanceSound != null)
        {
            sesSeviyesi = SoundOptions.instanceSound._Value;

        }
        foreach (AudioSource kaynak in sesKaynaklari)
        {
            kaynak.volume = sesSeviyesi;
        }
    }
}
