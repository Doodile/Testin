//Nick

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract_Nick : MonoBehaviour
{
    //Player Camera
    Camera cameraBoi;

    //inventory array
    int[] Inventory = new int[(int)EInventoryItems.ITEMS_LENGTH];

    //Key Array
    List<int> KeysHeld = new List<int>();

    Ray ray;

    //Ray Distance
    public float InteractRange = 4;

    void Awake()
    {
        //Get player camera
        cameraBoi = transform.GetChild(0).gameObject.GetComponent<Camera>();
        AddToInventory(EInventoryItems.LIGHTER);
    }


    // Update is called once per frame
    void Update()
    {
        //If interacting, cast ray
        if (Input.GetButtonDown("Interact"))
        {
            Debug.Log("CAST");

            BaseInteract_Nick[] interactToGet;
            RaycastHit hit;
            ray = cameraBoi.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
            //Cast Ray
            if (Physics.Raycast(ray, out hit, InteractRange))
            {
                //Set interact to hit result, if interact found
                interactToGet = hit.collider.GetComponents<BaseInteract_Nick>();
                if (interactToGet.Length > 0)
                {
                    foreach (var item in interactToGet)
                    {
                        item.Interact();
                    }
                }
                else
                    Debug.Log("No Interact Found :(");

                //if(interactToGet = hit.collider.GetComponent<BaseInteract_Nick>())
                //{
                //    //Call interact on found object
                //    interactToGet.Interact();
                //}
            }

        }
        {
            //TOOLTIPS
            RaycastHit hit;
            ray = cameraBoi.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
            //Cast Ray
            if (Physics.Raycast(ray, out hit, InteractRange))
            {
                ToolTipSpawner_Nick toolTipToGet = hit.collider.GetComponent<ToolTipSpawner_Nick>();
                if(toolTipToGet)
                {
                    toolTipToGet.LookAt();
                }
            }
        }

    }

    //Adds item to inventory, Overloadable to add multiple.
    internal void AddToInventory(EInventoryItems itemToAdd, int numberToAdd = 1)
    {
        Inventory[(int)itemToAdd] += numberToAdd;
        Debug.Log("Added " + numberToAdd + " " + itemToAdd + " to Inventory");
    }

    //Removes item from inventory, Overloadable to remove multiple.
    internal void RemoveFromInventory(EInventoryItems itemToRemove, int numberToRemove = 1)
    {
        Inventory[(int)itemToRemove] -= numberToRemove;
        Debug.Log("Removed " + numberToRemove + " " + itemToRemove + " from Inventory");
    }

    //Returns true if item is in inventory. Overloadable to test if there are more than one.
    public bool IsInInventory(EInventoryItems itemToTest, int numberToTest = 1)
    {
        Debug.Log(Inventory[(int)itemToTest] + " of " + itemToTest + " in inventory. Returning " + (Inventory[(int)itemToTest] >= numberToTest));
        return (Inventory[(int)itemToTest] >= numberToTest);
    }

    //Returns number of an item in inventory.
    public int NumberOfItemInInventory(EInventoryItems itemToTest)
    {
        Debug.Log(Inventory[(int)itemToTest] + " of " + itemToTest + " in inventory");
        return Inventory[(int)itemToTest];
    }

    //Sets whole inventory. Use for loading a save, DO NOT USE OTHERWISE.
    public void SetInventory(int[] toSet)
    {
        if(toSet.Length == (int)EInventoryItems.ITEMS_LENGTH)
        {
            Inventory = toSet;
        }
        else
        {
            Debug.Log("Inventory being set isn't a valid length.");
        }
    }

    //Returns entire inventory. Should be used for saving the game. 
    //Can be used outside of saving but the other functions are recommended instead. Use as a last resort.
    public int[] GetEntireInventory()
    {
        return Inventory;
    }

    //Test to see if player has key
    public bool HasKey(int KeyNumber)
    {
        bool has = false;
        foreach (var item in KeysHeld)
        {
            if(item == KeyNumber)
            {
                has = true;
            }
        }

        return has;
    }

    //Adds a key to key list
    public void AddKey(int KeyNumber)
    {
        KeysHeld.Add(KeyNumber);
    }
}
