using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorPuzzle_Nick : MultiPartPuzzle_Nick
{
    LightSwitch_Nick[] switches;

    void Start()
    {
        base.Start();
        switches = FindObjectsOfType<LightSwitch_Nick>();
    }

    //When generator puzzle is completed, 
    public override void CompletePuzzle()
    {
        Debug.Log("Generator Puzzle Complete");
        foreach (var item in switches)
        {
            item.SetUsable(true);
        }
        MarkAsComplete();
    }
}
