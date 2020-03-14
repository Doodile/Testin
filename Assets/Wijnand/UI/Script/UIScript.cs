using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{


    public GameObject Inventory;
    public GameObject Notes_OB;
    public GameObject Settings;
    public GameObject ContinueOB;
    public GameObject InventorySlots;
    public PlayerInteract_Nick Interact;
    public GameObject PrefabSlot;
    private int CurrentNote = 1;
    private int unlockednotes = 2;
    public bool HideOnStart = false;
    public bool IsStartingGame = false;
    public GameObject SettingsOB;
    private void Start()
    {
        //A way to fix a random error ¯\_(ツ)_/¯
       // GetCurrentNote();

        if (HideOnStart)
        {
            ShowOrHideMenu();
            Camera.main.GetComponent<Animator>().SetBool("InMenu", false);
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        if (IsStartingGame)
        {
            ContinueOB.GetComponent<Text>().text = "Start Game";
            GameObject.Find("PlayerFab").GetComponent<Playermovement_Nick>().SetCanMove(false);
        }
    }


   //Change this to button IMPORTANT <----------------------------------- WM
    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Tab) && !IsStartingGame)
        {

            ShowOrHideMenu();

        }

    }



    public void ShowOrHideMenu()
    {
        ContinueOB.GetComponent<Text>().text = "Continue";
        GetComponent<Canvas>().enabled = !GetComponent<Canvas>().enabled;
        GetComponent<Animation>().Play();
        Inventory.SetActive(false);
        Notes_OB.SetActive(false);
        Settings.SetActive(false);
        SettingsOB.SetActive(false);
        if (!Cursor.visible)
        {
            GameObject.Find("PlayerFab").GetComponent<Playermovement_Nick>().SetCanMove(false);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            GameObject.Find("PlayerFab").GetComponent<Playermovement_Nick>().SetCanMove(true);
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    //This was to implement the main menu makes it so i can ask if it's in the main menu or not
    public void FuncContinue(){
        if (IsStartingGame)
        {
            StartCoroutine(WaitForAnimation());
            Camera.main.GetComponent<Animator>().SetBool("InMenu", false);
            GameObject.Find("PlayerFab").GetComponent<Playermovement_Nick>().SetCanMove(false);
            IsStartingGame = false;
            Cursor.visible = false;
            SettingsOB.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            GetComponent<Canvas>().enabled = !GetComponent<Canvas>().enabled;
        }

        else ShowOrHideMenu();
    }

    public void ShowInventory()
    {
        if (IsStartingGame)
            return;
        SettingsOB.SetActive(false);
        Inventory.SetActive(true);
        Notes_OB.SetActive(false);
        Settings.SetActive(false);
        UpdateInventory();
    }

    public void ShowNotes()
    {
        if (IsStartingGame)
            return;
        SettingsOB.SetActive(false);
        Inventory.SetActive(false);
        Notes_OB.SetActive(true);
        Settings.SetActive(false);
        GetCurrentNote();
    }

    public void ShowSettings()
    {

        SettingsOB.SetActive(true);
        Inventory.SetActive(false);
        Notes_OB.SetActive(false);
        Settings.SetActive(true);

    }


    //Wait for animation to end make player able to play
    IEnumerator WaitForAnimation()
    {

        yield return new WaitForSeconds(4.2f);
        Camera.main.GetComponent<Animator>().SetBool("InMenu", true);
        GameObject.Find("PlayerFab").GetComponent<Playermovement_Nick>().SetCanMove(true);

    }



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
        OB.transform.GetChild(0).GetComponent<MeshFilter>().mesh = Resources.Load<Mesh>(enumn.ToString());
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
        if(CurrentNote != 1)
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
