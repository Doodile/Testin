using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveLoad : MonoBehaviour
{
    //Object references
    private GameObject playerObj;
    private GameObject cameraObj;

    //Text file directory
    private const string FilePath = "Assets/SaveGameData.txt";

    //Loading variables
    private string LineValue = "";

    //Saving variables
    private bool WritingDone = false;
    private string ValueToWrite = "";

    //
    private int Line = 0;

    private void Awake()
    {
        playerObj = GameObject.Find("PlayerFab");
        cameraObj = GameObject.Find("Camera");
    }

    void Start()
    {
        //Loads the game at game start
        LoadGame();
    }

    void Update()
    {

        //If player presses F5 then save game 
        if (Input.GetKeyDown("f5"))
        {
            SaveGame();
        }

        //If player presses delete key then delete save
        if (Input.GetKeyDown("delete"))
        {
            DeleteSave();
        }

    }

    //Read values from SaveGameData.txt and apply those values
    private void LoadGame()
    {
        try
        {
            //Read each line of SaveGameData and apply values to approiate places (See SaveGameData format below)
            using (StreamReader read = new StreamReader(FilePath))
            {
                //Check first line of SaveGameData to see if empty or not. If empty then leave function
                if ((LineValue = read.ReadLine()) == "EMPTY")
                {
                    Debug.Log("Save file empty, will use default values");
                    return;
                }
                else
                {
                    ApplyValue();
                    Line++;
                }

                //Loop to go through remaining lines of SaveGameData and apply value
                while ((LineValue = read.ReadLine()) != null)
                {
                    ApplyValue();
                    Line++;
                }
            }
        }
        catch (IOException)
        {
            Debug.Log("Failed to find SaveGameData text file, will use default values");
        }
    }

    //Writes values into SaveGameData.txt
    private void SaveGame()
    {
        //Ensure SaveGameData is empty before writing to file
        DeleteSave();

        try
        {
            //Loop to write to each line of SaveGameData (See SaveGameData format below)
            using (StreamWriter write = new StreamWriter(FilePath))
            {
                while (!WritingDone)
                {
                    ValueToWrite = GetValue();
                    write.WriteLine(ValueToWrite);
                    Line++;
                }
            }

            //Reset variables used
            Line = 0;
            WritingDone = false;
        }
        catch (IOException)
        {
            Debug.Log("Failed to find SaveGameData text file, cant save!");
        }
    }

    //Delete everything in SaveGameData.txt and writes EMPTY to first line
    private void DeleteSave()
    {
        try
        {
            //Clear text file and write EMPTY to first line
            using (StreamWriter write = new StreamWriter(FilePath))
            {
                write.WriteLine("EMPTY");
            }
        }
        catch (IOException)
        {
            Debug.Log("Failed to find SaveGameData text file, cant delete save!");
        }
    }

    //Function used to get values from different references and returns them to be added to SaveGameData
    private string GetValue()
    {
        //See SaveGameData format below to see what each line represents
        if (Line == 0) { return playerObj.transform.position.x.ToString(); }
        if (Line == 1) { return playerObj.transform.position.y.ToString(); }
        if (Line == 2) { return playerObj.transform.position.z.ToString(); }
        if (Line == 3) { return playerObj.transform.rotation.eulerAngles.y.ToString(); }
        if (Line == 4) { return cameraObj.transform.rotation.eulerAngles.x.ToString(); }

        //Finished writing to file so exit while loop
        WritingDone = true;
        return "";
    }

    //Function used to apply values to different references
    private void ApplyValue()
    {
        //See SaveGameData format below to see what each line represents
        if (Line == 0) { playerObj.transform.position = new Vector3(float.Parse(LineValue), playerObj.transform.position.y, playerObj.transform.position.z); }
        if (Line == 1) { playerObj.transform.position = new Vector3(playerObj.transform.position.x, float.Parse(LineValue), playerObj.transform.position.z); }
        if (Line == 2) { playerObj.transform.position = new Vector3(playerObj.transform.position.x, playerObj.transform.position.y, float.Parse(LineValue)); }
        if (Line == 3) { playerObj.transform.rotation = Quaternion.Euler(playerObj.transform.rotation.eulerAngles.x, float.Parse(LineValue), playerObj.transform.rotation.eulerAngles.z); }
        if (Line == 4) { cameraObj.transform.rotation = Quaternion.Euler(float.Parse(LineValue), cameraObj.transform.rotation.eulerAngles.y, cameraObj.transform.rotation.eulerAngles.z); }
    }

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
