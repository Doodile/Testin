//WM
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TransitionScene : BaseInteract_Nick
{
    public bool Requires_Key=false;

    public int Required_Key = 0;

    public string SceneToTransitionTo;

    //Check is key is needed and if he has key, then transition if so
    public override void Interact()
    {
        Debug.Log("hey");
        if (Requires_Key)
        {
            if (Camera.main.transform.parent.GetComponent<PlayerInteract_Nick>().HasKey(Required_Key))
            {
                //You have the key 
                SceneManager.LoadScene(SceneToTransitionTo, LoadSceneMode.Single);

            }
            else
            {

                //You dont have the key

            }

        }
        else
        {

            //can enter

        }

    }
}
