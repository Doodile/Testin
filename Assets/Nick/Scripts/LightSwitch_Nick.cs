//Nick

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch_Nick : BaseInteract_Nick
{
    public Light[] lights;
    public bool Usable = true;

    override public void Interact()
    {
        if (!Usable)
        {
            Debug.Log("//LIGHTSWITCH DISABLED//");
            return;
        }
        Debug.Log("Lights Toggled");
        foreach (var item in lights)
        {
            item.enabled = !item.enabled;
            Debug.Log("Light is now " + item.enabled);
        }
    }


    internal void SetUsable(bool newUsable)
    {
        Usable = newUsable;
    }

}
