using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider masterSlider;
    [SerializeField] private Slider musicSlider;

    private void Start()
    {
        // Escuchar cambios de los sliders
        masterSlider.onValueChanged.AddListener(SetMasterVolume);
        musicSlider.onValueChanged.AddListener(SetMusicVolume);
    }
    public void SetMasterVolume(float volume)
    {
        if (volume <= 0.0001f)
        {
            audioMixer.SetFloat("MasterVolume", -80f);  // Silencio total
        }
        else
        {
            audioMixer.SetFloat("MasterVolume", Mathf.Log10(volume) * 20);
        }
    }

    public void SetMusicVolume(float volume)
    {
        //audioMixer.SetFloat("MusicVolume", Mathf.Log10(volume) * 20);
        if (volume <= 0.0001f)
        {
            audioMixer.SetFloat("MusicVolume", -80f);  // Silencio total
        }
        else
        {
            audioMixer.SetFloat("MusicVolume", Mathf.Log10(volume) * 20);
        }
    }
}

