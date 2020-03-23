using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public List<string> ClipNames = new List<string>();
    public List<AudioClip> ClipList = new List<AudioClip>();

    //Nick
    public string[] VoiceClipSubtitles = new string[(int)EVoiceClips.CLIP_LENGTH];
    public AudioClip[] VoiceClipList = new AudioClip[(int)EVoiceClips.CLIP_LENGTH];

    Text SubtitleText;
    //Nick End

    public GameObject SFX_Prefab;

    private Dictionary<string, AudioClip> SFX_Lib = new Dictionary<string, AudioClip>();

    public static SFXManager GlobalSFXManager;

    void Start()
    {
        GlobalSFXManager = this;

        for (int i = 0; i < ClipNames.Count; i++)
        {
            SFX_Lib.Add(ClipNames[i], ClipList[i]);
        }
        //Nick
        SubtitleText = GameObject.Find("Subtitles").GetComponent<Text>();
        SubtitleText.enabled = false;
        //Nick End
    }


    //Plays SFX close to camera, use for ui and sutch
    public void PlaySFX(string ClipName)
    {
        if (SFX_Lib.ContainsKey(ClipName))
        {
            AudioSource SFX = Instantiate(SFX_Prefab).GetComponent<AudioSource>();
            SFX.PlayOneShot(SFX_Lib[ClipName]);
            Destroy(SFX.gameObject, SFX_Lib[ClipName].length);
        }
    }


    //Plays SFX in a 3D space use for light switches or thunder and sutch.
    //Where is the gameobject where the sound comes from
    public void PlaySFXObject(string ClipName, GameObject Where)
    {
        if (SFX_Lib.ContainsKey(ClipName))
        {
            AudioSource SFX = Instantiate(SFX_Prefab, Where.transform).GetComponent<AudioSource>();
            SFX.PlayOneShot(SFX_Lib[ClipName]);
            SFX.spatialBlend = 1;
            Destroy(SFX.gameObject, SFX_Lib[ClipName].length);
        }
    }

    //Nick
    //Play voiceline and display subtitles for audio clip
    public void PlayVoiceClip(EVoiceClips clip)
    {
        AudioSource SFX = Instantiate(SFX_Prefab).GetComponent<AudioSource>();
        SFX.PlayOneShot(VoiceClipList[(int)clip]);

        SubtitleText.enabled = true;
        SubtitleText.text = VoiceClipSubtitles[(int)clip];
        StartCoroutine(SubtitleDelay(VoiceClipList[(int)clip].length));

        Destroy(SFX.gameObject, VoiceClipList[(int)clip].length);
    }
    //Alternate version wihout enum
    public void PlayVoiceClip(AudioClip clip, string sub)
    {
        AudioSource SFX = Instantiate(SFX_Prefab).GetComponent<AudioSource>();
        SFX.PlayOneShot(clip);

        SubtitleText.enabled = true;
        SubtitleText.text = sub;
        StartCoroutine(SubtitleDelay(clip.length));

        Destroy(SFX.gameObject, clip.length);
    }

    IEnumerator SubtitleDelay(float delay)
    {
        //Debug.Log("Start");
        yield return new WaitForSeconds(delay);

        SubtitleText.enabled = false;
    }

}

//Nick
//All the voicelines.
public enum EVoiceClips : int
{
    CLIP_TEST,
    CLIP_DONTWANT,
    //Alanna code added//
    key_dropped, 
    candle_pickup, 
    candle_pickup_2, 
    piece_of_clothing, 
    basement_key, 
    office_key_door, 
    knife_pickup, 
    finding_switch_generator, 
    found_switch, 
    basement_book, 
    basement_secret_open, 
    pencil_found, 
    paper_found, 
    start_ritual,
    //Alanna End//

    CLIP_LENGTH
}