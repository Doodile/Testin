using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveGame : MonoBehaviour
{
    public GameObject playerObj;
    public GameObject cameraObj;

    private string LineValue;
    private int Line = 0;

    private const string FilePath = "Assets/Jamie/SaveGameData.txt";

    void Update()
    {
        
        if (Input.GetKeyDown("f5"))
        {
            SaveGameFunction();
        }

        if (Input.GetKeyDown("delete"))
        {
            DeleteSave();
        }
    }

    //NEED TO FINISH
    private void SaveGameFunction()
    {
        Debug.Log("saving to text file...");
        try
        {
            //Write to each line of SaveGameData (See SaveGameData format below)

            using (StreamWriter write = new StreamWriter(FilePath))
            {
                write.WriteLine();
                Line++;
            }


            Debug.Log("saving done");
        }
        catch (IOException)
        {
            Debug.Log("failed to find SaveGameData text file, cant save!");
        }

    }

    private void DeleteSave()
    {
        Debug.Log("deleteing save");
        try
        {
            //Clear text file
            using (StreamWriter write = new StreamWriter(FilePath))
            {
                write.WriteLine(" ");
                Line++;
            }
            Debug.Log("successfully cleared save");
        }
        catch (IOException)
        {
            Debug.Log("failed to find SaveGameData text file, cant delete save!");
        }
    }

    float GetValue()
    {
        //See SaveGameData format below to see what each line represents
        if (Line == 0) { return 2; }
        if (Line == 1) { return 2; }
        if (Line == 2) { return 2; }
        if (Line == 3) { return 2; }
        if (Line == 4) { return 2; }
        return 2;
    }



    /*
     * 
     *  SaveGameData format
     *  
     *  Player X Position       0
     *  Player Y Position
     *  Player Z Position
     *  Player Y Rotation
     *  Camera X Rotation
     * 
     */

}
