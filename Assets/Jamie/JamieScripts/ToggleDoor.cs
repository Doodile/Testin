//Jamie G
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleDoor : BaseInteract_Nick
{
    internal bool Open = false;

    override public void Interact()
    {
        Debug.Log("interacting with door");
        //If door has the LockedDoor script attached that check that script to see if door is locked or not
        if (GetComponent<LockedDoor>())
        {
            //Door locked so perform lock picking stuff
            if (GetComponent<LockedDoor>().Locked)
            {
                GetComponent<LockedDoor>().LockpickingStart();
            }
            //Door is unlocked so open / close the door
            else
            {
                //OpenClose();
                GetComponent<Door>().Interact();
            }
        }
        //Otherwise the door is not a lockable door so simply open / close the door
        else
        {
            GetComponent<Door>().Interact();
            //OpenClose();
        }

    }

    void OpenClose()
    {
        //Open door
        if (!Open)
        {
            Debug.Log("opening door");
            Open = true;
            transform.parent.Rotate(new Vector3(0, -90, 0));

        }
        //Close door
        else
        {
            Debug.Log("Closing door");
            Open = false;
            transform.parent.Rotate(new Vector3(0, 90, 0));

        }
    }



}
