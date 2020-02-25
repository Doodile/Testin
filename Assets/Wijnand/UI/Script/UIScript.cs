using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{


    public GameObject Inventory;
    public GameObject Notes_OB;
    public GameObject Settings;
    public GameObject InventorySlots;
    public PlayerInteract_Nick Interact;
    public GameObject PrefabSlot;
    private int CurrentNote = 0;
    public int unlockednotes = 1;
    private void Start()
    {
        ShowOrHideMenu();
    }


    //Update has to be removed, and move the Key statement
    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {

            ShowOrHideMenu();

        }

    }



    public void ShowOrHideMenu()
    {

        GetComponent<Canvas>().enabled = !GetComponent<Canvas>().enabled;
        GetComponent<Animation>().Play();
        Inventory.SetActive(false);
        Notes_OB.SetActive(false);
        Settings.SetActive(false);
        //Cursor.visible = !Cursor.visible;
        if (Cursor.visible)
        {
            Cursor.lockState = CursorLockMode.Confined;

        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }



    public void ShowInventory()
    {
        Inventory.SetActive(true);
        Notes_OB.SetActive(false);
        Settings.SetActive(false);
        UpdateInventory();
    }

    public void ShowNotes()
    {
        Inventory.SetActive(false);
        Notes_OB.SetActive(true);
        Settings.SetActive(false);
        GetCurrentNote();
    }

    public void ShowSettings()
    {
        Inventory.SetActive(false);
        Notes_OB.SetActive(false);
        Settings.SetActive(true);

    }

    //IGNORE--
    //If Inventory has a count of 3 for loop 3 and name each child the inventory num 

    //Go throw all slots and inventory at same time so first item picked is 1,2,3 etc
    //When inventory doesn't have items it has no name so has no item
    //--------






    //Updates each inventory slot with an item
    public void UpdateInventory()
    {

        ClearInventory();

       for(int i = 0; i < (int)EInventoryItems.ITEMS_LENGTH; i++)
        {


            EInventoryItems getenum = (EInventoryItems)i;

            if (Interact.IsInInventory(getenum))
            {
                //Make a new slot instead of chaing name


                CreateSlot(getenum);


            }



        }

    }


    public void ClearInventory()
    {
        foreach (Transform child in InventorySlots.transform)
        {
            GameObject.Destroy(child.gameObject);
        }


    }


    //Use enum to get name and check how many there are and for the mesh after
    private void CreateSlot(EInventoryItems enumn)
    {

        GameObject OB = Instantiate(PrefabSlot,InventorySlots.transform);
        OB.transform.GetChild(1).GetComponent<Text>().text = Interact.NumberOfItemInInventory(enumn).ToString();
        OB.name = enumn.ToString();

    }

    public void NextNote()
    {
        if (CurrentNote < unlockednotes)
        {
            CurrentNote++;

            GetCurrentNote();


        }


    }

    public void PreviousNote()
    {
        if(CurrentNote != 0)
        {
            CurrentNote--;
            GetCurrentNote();
        }


    }


    //Gets current note depending on the CurrentNote int
    public void GetCurrentNote()
    {

        //Changes title
        Notes_OB.transform.GetChild(0).GetComponent<Text>().text = Notes.GetNote(CurrentNote).GetTitle();

        //Changes Text
        Notes_OB.transform.GetChild(1).GetComponent<Text>().text = Notes.GetNote(CurrentNote).Gettext();


    }

}
