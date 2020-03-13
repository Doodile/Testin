using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{


    public List<string> ClipNames = new List<string>();
    public List<AudioClip> ClipList = new List<AudioClip>();

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


  





}
