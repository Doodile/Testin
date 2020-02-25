using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiPartPuzzle_Nick : PuzzleBase_Nick
{
    public PuzzleBase_Nick[] subPuzzles;
    int subPuzzlesComplete = 0;

    override public void Interact()
    {
        Debug.Log(GetProgress());
    }


    public virtual void SubPuzzleComplete()
    {
        SetProgress(EPuzzleProgress.IN_PROGRESS);
        ++subPuzzlesComplete;
        if(subPuzzlesComplete == subPuzzles.Length)
        {
            CompletePuzzle();
        }
    }

}
