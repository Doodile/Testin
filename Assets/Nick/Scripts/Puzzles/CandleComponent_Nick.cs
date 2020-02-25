using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandleComponent_Nick : PuzzleBase_Nick
{
    CandlePuzzleTest_Nick attachedTo;
    MeshRenderer Renderer;
    bool used = false;
    
    public Material Wax;

    PlayerInteract_Nick Inventory;

    void Awake()
    {
        attachedTo = transform.parent.GetComponent<CandlePuzzleTest_Nick>();
        if (!attachedTo)
            Debug.Log("Candle Failed to attach");
        Renderer = GetComponent<MeshRenderer>();
        Inventory = GameObject.Find("PlayerFab").GetComponent<PlayerInteract_Nick>();
    }

    public override void Interact()
    {
        if (used)
            return;
        if (Inventory.IsInInventory(EInventoryItems.CANDLE) && LevelProgressData_Nick.GetProgress() >= RequiredLevelProgressInt)
        {
            Inventory.RemoveFromInventory(EInventoryItems.CANDLE);
            attachedTo.SubPuzzleComplete();
            Renderer.material = Wax;
            used = true;
        }

    }

}
