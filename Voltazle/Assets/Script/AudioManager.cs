using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Source")]
    [SerializeField] AudioSource BGMsource;
    [SerializeField] AudioSource SFXsource;

    [Header("Audio Clip")]
    public AudioClip bgm;
    public AudioClip death;
    public AudioClip jump;
    public AudioClip lasershoot;
    public AudioClip interact;
    public AudioClip FinishLift;

    void Awake(){
        DontDestroyOnLoad(gameObject);
    }

    void Start(){
        BGMsource.clip = bgm;
        BGMsource.Play();
    }

    public void PlaySFX(AudioClip clip){
        SFXsource.PlayOneShot(clip);
    }
}
