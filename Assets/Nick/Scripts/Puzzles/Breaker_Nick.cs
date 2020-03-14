using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breaker_Nick : PuzzleBase_Nick
{
    public GeneratorTest_Nick generator;
    public GeneratorPuzzle_Nick puzzle;

    public override void Interact()
    {
        //If generator is on, flip breaker switch and mark as complete
        if(GetProgress() != EPuzzleProgress.COMPLETED && generator.GetProgress() == EPuzzleProgress.COMPLETED)
        {
            transform.Rotate(new Vector3(180, 0, 0));
            CompletePuzzle();
        }
    }
}
