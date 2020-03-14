using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickup_Nick : BaseInteract_Nick
{
    public int KeyNumber = 0;

    PlayerInteract_Nick PlayerInventory;

    void Start()
    {
        PlayerInventory = GameObject.Find("PlayerFab").GetComponent<PlayerInteract_Nick>();
    }

    public override void Interact()
    {
        PlayerInventory.AddKey(KeyNumber);
        Destroy(gameObject);
    }
}
