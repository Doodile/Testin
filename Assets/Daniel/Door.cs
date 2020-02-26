//Daniel

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : BaseInteract_Nick
{
    public bool IsOpening=false;
    public float startY;
    public float endY;

    public override void Interact()
    {
        IsOpening = !IsOpening;
    }

    void FixedUpdate()
    {
        if (IsOpening)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(-89.98f, endY, 0), 1.5f * Time.deltaTime);
        }
        else
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(-89.98f, startY, 0), 1.5f * Time.deltaTime);
        }
    }
}