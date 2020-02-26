//Daniel

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : BaseInteract_Nick
{
    public bool IsOpening = false;
    private Vector3 InitialPos, OpenPos;
    public float OpenRotation, DoorOpenSpeed;
    private float x, y, z;
    public bool Locked;

    private void Start()
    {
        //Get the rotation values 
        x = transform.eulerAngles.x;
        y = transform.eulerAngles.y;
        z = transform.eulerAngles.z;

        //Set the initial values
        InitialPos = new Vector3(x, y, z);

        //Set the open values
        OpenPos = new Vector3(x, y + OpenRotation, z);
    }

    public override void Interact()
    {
        if (Locked)
        {
            IsOpening = !IsOpening;
        }

    }

    void FixedUpdate()
    {
        if (IsOpening)
        {
            //Open door
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(OpenPos), DoorOpenSpeed * Time.deltaTime);
        }
        else
        {
            //Close door
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(InitialPos), DoorOpenSpeed * Time.deltaTime);
        }
    }

    public void LockPickDone()
    {
        Locked = false;
    }
}