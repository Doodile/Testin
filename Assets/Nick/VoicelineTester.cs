using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoicelineTester : BaseInteract_Nick
{
    SFXManager voiceline;
    public bool UseEnums = true;

    public EVoiceClips clipToPlay;
    public AudioClip audioClip;
    public string Subs;


    public override void Interact()
    {
        if(UseEnums)
        {
            SFXManager.GlobalSFXManager.PlayVoiceClip(clipToPlay);
            //voiceline.PlayVoiceClip(clipToPlay);
        }
        else
        {
            SFXManager.GlobalSFXManager.PlayVoiceClip(audioClip, Subs);
            //voiceline.PlayVoiceClip(audioClip, Subs);
        }
    }
}
