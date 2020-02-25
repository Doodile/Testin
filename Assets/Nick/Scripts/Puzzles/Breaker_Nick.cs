using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breaker_Nick : PuzzleBase_Nick
{
    public GeneratorTest_Nick generator;
    public GeneratorPuzzle_Nick puzzle;

    public override void Interact()
    {
        if(GetProgress() != EPuzzleProgress.COMPLETED && generator.GetProgress() == EPuzzleProgress.COMPLETED)
        {
            transform.Rotate(new Vector3(180, 0, 0));
            puzzle.SubPuzzleComplete();
            CompletePuzzle();
        }
    }
}
