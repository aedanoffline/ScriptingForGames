using UnityEngine;
using UnityEngine.UI;

public class MusicVolumeControl : MonoBehaviour
{
    public AudioSource musicSource;
    public Slider musicVolumeSlider;
    private void Start()
    {
        // Set initial value
        musicVolumeSlider.value = musicSource.volume;
        // Adding some sort of updater method named "AdjustVolume"
        musicVolumeSlider.onValueChanged.AddListener(AdjustVolume);
    }

    public void AdjustVolume(float newvolume)
    {
        // Listener that accepts an external value from the slider and assigns that value to the musicSource volume
        musicSource.volume = newvolume;
    }
}
