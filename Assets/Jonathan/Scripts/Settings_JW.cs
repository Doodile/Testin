using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Settings_JW : MonoBehaviour
{
    //CONTROLS
    /*
     * 
     * Will have to transition from the project settings to individual keybinds
     * 
     */


    

    //GRAPHICS
    public void setGraphicsQuality(int level)
    {
        QualitySettings.SetQualityLevel(level);
    }
    
    //AUDIO
    public AudioMixer audioMixer;
    
    //Audio Functions - AudioMixer works on a lograthmic scale (dB) so v is converted
    public void setMasterVolume(float v)
    {
        audioMixer.SetFloat("Master", (Mathf.Log10(v) * 20));
    }
    public void setAmbientVolume(float v)
    {
        audioMixer.SetFloat("Ambient", (Mathf.Log10(v) * 20));
    }
    public void setSFXVolume(float v)
    {
        audioMixer.SetFloat("SFX", (Mathf.Log10(v) * 20));
    }
    public void setVoiceVolume(float v)
    {
        audioMixer.SetFloat("Voice", (Mathf.Log10(v) * 20));
    }
}
