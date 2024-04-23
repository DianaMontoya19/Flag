using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer myMixer;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider fxSlider;
    [SerializeField] private Slider masterSlider;

    public void SetMusicVolume()
    {
        float musicSliderValue = musicSlider.value * 10;
        myMixer.SetFloat("Music", musicSliderValue);
    }

    public void SetFxVolume()
    {
        float fxSliderValue = fxSlider.value * 10;
        myMixer.SetFloat("Fx", fxSliderValue);
    }

    public void SetMasterVolume()
    {
        float masterSliderValue = masterSlider.value * 10;
        myMixer.SetFloat("Master", masterSliderValue);
    }
}