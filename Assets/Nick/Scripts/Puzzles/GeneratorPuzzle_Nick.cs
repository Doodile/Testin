using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorPuzzle_Nick : MultiPartPuzzle_Nick
{
    LightSwitch_Nick[] switches;

    void Start()
    {
        switches = FindObjectsOfType<LightSwitch_Nick>();
    }


    public override void CompletePuzzle()
    {
        foreach (var item in switches)
        {
            item.SetUsable(true);
        }
        MarkAsComplete();
    }
}
