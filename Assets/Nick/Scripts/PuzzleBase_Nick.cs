//Nick

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EPuzzleProgress
{
    NOT_STARTED,
    IN_PROGRESS,
    COMPLETED
};

public class PuzzleBase_Nick : BaseInteract_Nick
{
    //The progress required to start puzzle
    public int RequiredLevelProgressInt = 0;

    //Should ideally be 1 for simplicity
    public int ProgressToAdd = 1;

    protected EPuzzleProgress puzzleProgress = EPuzzleProgress.NOT_STARTED;

    protected MultiPartPuzzle_Nick attachedTo;

    //Called when interacted with. Override To add functionality
    override public void Interact()
    {
        Debug.Log("PUZZLE COMPLETED. THIS SHOULD HAVE BEEN OVERRIDDEN.");
        CompletePuzzle();
    }

    //Marks puzzle as complete and increments level progress int.
    public virtual void CompletePuzzle()
    {
        MarkAsComplete();
    }

    protected void MarkAsComplete()
    {
        Debug.Log("Complete");
        LevelProgressData_Nick.AddProgress(ProgressToAdd);
        puzzleProgress = EPuzzleProgress.COMPLETED;
        if(attachedTo)
        {
            attachedTo.SubPuzzleComplete();
        }
        else
        {
            Debug.Log("Not a sub puzzle.");
        }
    }

    //Returns level progress from static data.
    public int GetCurrentProgressInt()
    {
        return LevelProgressData_Nick.GetProgress();
    }

    //Returns puzzle progress. Can be called from other scripts to see what puzzles have and haven't been done.
    public EPuzzleProgress GetProgress()
    {
        return puzzleProgress;
    }

    //Sets current Puzzle Progress. This can be used when loading saves.
    public void SetProgress(EPuzzleProgress newstate)
    {
        puzzleProgress = newstate;
    }

    //Compares level progress int to required int.
    public bool CanUsePuzzle()
    {
        return (GetCurrentProgressInt() >= RequiredLevelProgressInt);
    }

    //Sets owner if attached to a multiPartPuzzle
    public void SetOwner(MultiPartPuzzle_Nick newOwner)
    {
        Debug.Log("Owner set as " + newOwner);
        attachedTo = newOwner;
    }
}
