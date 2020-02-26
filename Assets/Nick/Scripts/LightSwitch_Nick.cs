//Nick

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch_Nick : BaseInteract_Nick
{
    public GameObject[] lights;
    public bool Usable = true;

    void Start()
    {
        if(!Usable)
        {
            foreach (var item in lights)
            {
                item.SetActive(false);
            }
        }
    }

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
            item.SetActive(!item.activeSelf);
            Debug.Log("Light is now " + item.activeSelf);
        }
    }


    internal void SetUsable(bool newUsable)
    {
        Usable = newUsable;
    }

}
