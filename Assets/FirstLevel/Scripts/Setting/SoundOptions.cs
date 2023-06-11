using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundOptions : MonoBehaviour
{
    [SerializeField] private AudioMixer Mixer;
    [SerializeField] private AudioSource AudioSource;
    [SerializeField] private Text ValueText;
    [SerializeField] private AudioMixMode MixMode;
    public float _Value = 1;
    public static SoundOptions instanceSound;

    private void Start()
    {
        instanceSound = this;
        ValueText.text = "100";
    }

    public void OnChangeSlider(float Value)
    {
        ValueText.text = (Value * 100).ToString("000");
        _Value = Value;

        switch(MixMode)
        {
            case AudioMixMode.LinearAudioSourceVolume:
                AudioSource.volume = Value;
                break;
            case AudioMixMode.LinearMixerVolume:
                Mixer.SetFloat("Volume", (-80 + Value * 100));
                break;
            case AudioMixMode.LogrithmicMixerVolume:
                Mixer.SetFloat("Volume",Mathf.Log10(Value) * 20);
                break;
        }
    }

    public enum AudioMixMode
    {
        LinearAudioSourceVolume,
        LinearMixerVolume,
        LogrithmicMixerVolume
    }
}
