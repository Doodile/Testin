using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandlePuzzleTest_Nick : MultiPartPuzzle_Nick
{

    override public void Interact()
    {
        if(CanUsePuzzle())
        {
            Debug.Log("Hello, yes this can be used");
        }
    }

}
