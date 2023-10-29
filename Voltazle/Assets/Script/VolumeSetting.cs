using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSetting : MonoBehaviour
{
    [SerializeField] private AudioMixer myMixer;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider BGMSlider;
    [SerializeField] private Slider SFXSlider;

    private void Start(){
        if(PlayerPrefs.HasKey("MasterAudio")){
            LoadVolume();
        }else{
            SetMasterVolume();
        }

        if(PlayerPrefs.HasKey("BGMAudio")){
            LoadVolume();
        }else{
            SetBGMVolume();
        }

        if(PlayerPrefs.HasKey("SFXAudio")){
            LoadVolume();
        }else{
            SetSFXVolume();
        }
    }
    public void SetMasterVolume(){
        float volume = musicSlider.value;
        myMixer.SetFloat("MasterAudio",Mathf.Log10(volume)*20);
        PlayerPrefs.SetFloat("MasterAudio", volume);
    }
    public void SetBGMVolume(){
        float volume = BGMSlider.value;
        myMixer.SetFloat("BGMAudio",Mathf.Log10(volume)*20);
        PlayerPrefs.SetFloat("BGMAudio", volume);
    }

    public void SetSFXVolume(){
        float volume = SFXSlider.value;
        myMixer.SetFloat("SFXAudio",Mathf.Log10(volume)*20);
        PlayerPrefs.SetFloat("SFXAudio", volume);
    }

    private void LoadVolume(){
        musicSlider.value = PlayerPrefs.GetFloat("MasterAudio");
        BGMSlider.value = PlayerPrefs.GetFloat("BGMAudio");
        SFXSlider.value = PlayerPrefs.GetFloat("SFXAudio");
        SetMasterVolume();
        SetBGMVolume();
        SetSFXVolume();
    }
}
