//Nick

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelProgressData_Nick : MonoBehaviour
{
    static int ProgressInt = 0;

    //IncrementProgress
    public static void AddProgress(int toAdd = 1)
    {
        ProgressInt += toAdd;
    }

    //Return Progress
    public static int GetProgress()
    {
        return ProgressInt;
    }

    //ONLY USE FOR SAVEGAMES
    public static void SetProgress(int setTo)
    {
        ProgressInt = setTo;
    }
}
