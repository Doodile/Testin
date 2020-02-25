//Daniel

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : BaseInteract_Nick
{
    public bool IsOpening=false;

    public override void Interact()
    {
        IsOpening = !IsOpening;
    }

    void FixedUpdate()
    {
        if (IsOpening)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(-89.98f, 85, 0), 1.5f * Time.deltaTime);
        }
        else
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(-89.98f, 0, 0), 1.5f * Time.deltaTime);
        }
    }
}