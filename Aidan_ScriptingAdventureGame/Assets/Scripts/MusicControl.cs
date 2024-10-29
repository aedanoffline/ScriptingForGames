using System;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class MusicControl : MonoBehaviour
{
    public AudioSource musicSource;
    private TextMeshProUGUI text;

    private void Start()
    {
        text = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void ToggleMusic()
    {
        if (musicSource.isPlaying)
        {
            musicSource.Pause();
            text.text = "Music: Off";
        }
        else
        {
            musicSource.Play();
            text.text = "Music: On";
        }
    }
}
