//Nick

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickupable_Nick : BaseInteract_Nick
{
    GameObject PlayerRef;
    PlayerInteract_Nick PlayerInventory;

    //What item is this?
    public EInventoryItems ItemType;

    //How many of item is this?
    public int NumberOfItem = 1;

    // Start is called before the first frame update
    void Start()
    {
        PlayerRef = GameObject.Find("PlayerFab");
        PlayerInventory = PlayerRef.GetComponent<PlayerInteract_Nick>();
    }

    //When player interacts, override interact to add self to player's inventory, then destroy;
    override public void Interact()
    {
        PlayerInventory.AddToInventory(ItemType, NumberOfItem);
        Destroy(gameObject);
    }
}
