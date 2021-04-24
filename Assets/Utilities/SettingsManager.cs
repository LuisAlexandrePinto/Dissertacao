using UnityEngine;
using UnityEngine.Audio;

public class SettingsManager : Singleton<SettingsManager>
{
#pragma warning disable 0649
    [SerializeField]
    private AudioMixer Mixer;
#pragma warning restore 0649
    private readonly float multiplier = 30.0f, mediumVolume = 0.5f;
    public PlayerPreferences PlayerPreferences { get; private set; }    
    private void Awake()
    {
        PlayerPreferences = new PlayerPreferences();
        SetMusicVolume();
        SetSFXVolume();
    }
    public void SetMusicVolume()
    {
        float value;
        if (PlayerPrefs.GetInt(MuteConstants.MusicMute.ToString()) > 0)
        {
            float musicVolume = PlayerPrefs.GetFloat(VolumeConstants.MusicVolume.ToString(), mediumVolume);
            Mixer.SetFloat(VolumeConstants.MusicVolume.ToString(), Mathf.Log10(musicVolume) * multiplier);
        }
        else
        {
            Mixer.SetFloat(VolumeConstants.MusicVolume.ToString(), Mathf.Log10((float)0.0001) * multiplier);
        }
        Mixer.GetFloat(VolumeConstants.MusicVolume.ToString(), out value);
        Debug.Log(value);
    }
    public void SetSFXVolume()
    {
        if (PlayerPrefs.GetInt(MuteConstants.SFXMute.ToString()) > 0)
        {
            float sfxVolume = PlayerPrefs.GetFloat(VolumeConstants.SFXVolume.ToString(), mediumVolume);
            Mixer.SetFloat(VolumeConstants.SFXVolume.ToString(), Mathf.Log10(sfxVolume) * multiplier);
        }
        else
        {
            Mixer.SetFloat(VolumeConstants.SFXVolume.ToString(), Mathf.Log10((float)0.0001) * multiplier);
        }
    }
}
