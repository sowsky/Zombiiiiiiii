using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public AudioSource[] musics;
    public AudioSource[] effects;

    public AudioSource backgroundMusic;

    public Toggle toggle;

    public void SetMusicVolume(float sliderValue)
    {
        for (int i = 0; i < musics.Length; i++)
            musics[i].volume = sliderValue;
    }
    public void SetEffctVolume(float sliderValue)
    {
        for (int i = 0; i < effects.Length; i++)
        {
            if (effects[i] != backgroundMusic)
                effects[i].volume = sliderValue;
        }
    }
    public void IsMute()
    {
        if (!toggle.isOn)
        {
            for (int i = 0; i < musics.Length; i++)
                musics[i].Stop();
            for (int i = 0; i < effects.Length; i++)
                effects[i].Stop();
        }
        else
        {
            for (int i = 0; i < musics.Length; i++)
                musics[i].Play();
            for (int i = 0; i < effects.Length; i++)
                effects[i].Play();
        }
    }
}
