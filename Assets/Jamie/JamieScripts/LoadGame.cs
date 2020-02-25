using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


public class LoadGame : MonoBehaviour
{
    public GameObject playerObj;
    public GameObject cameraObj;

    private string LineValue;
    private int Line = 0;

    private const string FilePath = "Assets/Jamie/SaveGameData.txt";

    void Start()
    {
        //Ran only once to read and apply values in SaveGameData text file

        Debug.Log("loading from save file...");

        try
        {
            //Read each line of SaveGameData and apply values to approiate places (See SaveGameData format below)
            
            using (StreamReader read = new StreamReader(FilePath))
            {
                //Check first line of text file to see if empty or not. If empty then leave function
                /*if ((LineValue = read.ReadLine()) == null) 
                {
                    Debug.Log("save file empty");
                    return; 
                }*/
                
                
                while ((LineValue = read.ReadLine()) != null)
                {
                    ApplyValue();
                    Line++;
                }
            }


            Debug.Log("loading done");
        }
        catch (IOException)
        {
            Debug.Log("failed to find SaveGameData text file, will use default values");
        }
    }

    private void ApplyValue()
    {
        //See SaveGameData format below to see what each line represents
        //Debug.Log(LineValue);
        if (Line == 0) { playerObj.transform.position = new Vector3(float.Parse(LineValue), playerObj.transform.position.y, playerObj.transform.position.z); }
        if (Line == 1) { playerObj.transform.position = new Vector3(playerObj.transform.position.x, float.Parse(LineValue), playerObj.transform.position.z); }
        if (Line == 2) { playerObj.transform.position = new Vector3(playerObj.transform.position.x, playerObj.transform.position.y, float.Parse(LineValue)); }
        if (Line == 3) { playerObj.transform.rotation = Quaternion.Euler(playerObj.transform.rotation.eulerAngles.x ,float.Parse(LineValue), playerObj.transform.rotation.eulerAngles.z); }
        if (Line == 4) { cameraObj.transform.rotation = Quaternion.Euler(float.Parse(LineValue), cameraObj.transform.rotation.eulerAngles.y, cameraObj.transform.rotation.eulerAngles.z); } //fix this
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
