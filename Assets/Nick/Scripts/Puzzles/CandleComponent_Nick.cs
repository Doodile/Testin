using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandleComponent_Nick : PuzzleBase_Nick
{
    MeshRenderer Renderer;
    
    public Material Wax;

    PlayerInteract_Nick Inventory;

    void Awake()
    {
        Renderer = GetComponent<MeshRenderer>();
        Inventory = GameObject.Find("PlayerFab").GetComponent<PlayerInteract_Nick>();
    }

    public override void Interact()
    {
        //If already complete, do nothing
        if (GetProgress() == EPuzzleProgress.COMPLETED)
            return;
        //If candle is in inventory, remove it and mark puzzle as complete
        if (Inventory.IsInInventory(EInventoryItems.CANDLE) && LevelProgressData_Nick.GetProgress() >= RequiredLevelProgressInt)
        {
            Inventory.RemoveFromInventory(EInventoryItems.CANDLE);
            Renderer.material = Wax;
            CompletePuzzle();
        }

    }

}
