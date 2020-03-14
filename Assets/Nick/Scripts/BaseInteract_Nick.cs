//Nick

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseInteract_Nick : MonoBehaviour
{
    //When the player pressed interact while looking at this object, call this. Overidden in inherited classes.
    public virtual void Interact()
    {
        Debug.Log("Interacted");
    }
}
