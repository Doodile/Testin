using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyRequired_Nick : BaseInteract_Nick
{
    Door attachedTo;
    public int DoorNumber = 0;
    bool locked;
    PlayerInteract_Nick KeyInventory;

    // Start is called before the first frame update
    void Start()
    {
        attachedTo = GetComponent<Door>();
        KeyInventory = GameObject.Find("PlayerFab").GetComponent<PlayerInteract_Nick>();
        if(!attachedTo)
        {
            Debug.Log("NO DOOR, PLS FIX");
        }
        else
        {
            locked = attachedTo.Locked;
        }
    }

    public override void Interact()
    {
        if(KeyInventory.HasKey(DoorNumber))
        {
            attachedTo.LockPickDone();
        }
    }

}
