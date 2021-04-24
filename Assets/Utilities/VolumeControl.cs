using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField]
    private GameObject SoundMuted;
    [SerializeField]
    private VolumeConstants VolumeParameter;
    [SerializeField]
    private MuteConstants MuteParemeter;
    [SerializeField]
    private AudioMixer mixer;
    [SerializeField]
    private Slider slider;
    [SerializeField]
    private Toggle unmuteMute;
#pragma warning restore 0649    
    private readonly float multiplier = 30.0f;
    private float lastVolume;
    private readonly int on = 1, off = 0;
    private void Awake()
    {
        slider.onValueChanged.AddListener(ChangeVolume);
        CheckMute();
        unmuteMute.onValueChanged.AddListener(MuteUnmuteVolume);
    }

    private void CheckMute()
    {
        int enableSound = PlayerPrefs.GetInt(MuteParemeter.ToString(), on);
        MuteUnmuteVolume(enableSound == on);
        unmuteMute.isOn = enableSound == on;
    }
    private void MuteUnmuteVolume(bool enableSound)
    {
        lastVolume = slider.value = 
            enableSound ? PlayerPrefs.GetFloat(VolumeParameter.ToString(), slider.value) : slider.minValue;
        SoundMuted.SetActive(!enableSound);
        SaveMute(enableSound ? on : off);
    }
    private void ChangeVolume(float volume)
    {
        if(volume > lastVolume)
        {
            unmuteMute.isOn = true;
            SoundMuted.SetActive(false);
        }
        mixer.SetFloat(VolumeParameter.ToString(), Mathf.Log10(volume) * multiplier);
        if (unmuteMute.isOn)
        {         
            SaveVolume();
        }
    }
    private void OnDisable() => SaveVolume();
    private void SaveVolume() => PlayerPrefs.SetFloat(VolumeParameter.ToString(), slider.value);
    private void SaveMute(int enableSound) => PlayerPrefs.SetInt(MuteParemeter.ToString(), enableSound);
    private void OnEnable() => slider.value = PlayerPrefs.GetFloat(VolumeParameter.ToString(), slider.value);
}
