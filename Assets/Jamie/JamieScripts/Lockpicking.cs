//Jamie G
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lockpicking : MonoBehaviour
{
    public GameObject Lock;
    public GameObject ScrewDriver;
    public GameObject BobbyPin;

    private GameObject door;

    //Active becoming true means the player is currently lock picking it
    internal bool Active = false;

    //Bobby pin
    //Range the correct bobby pin number can be
    private const int MinRange = -90;
    private const int MaxRange = 90;

    //Users current bobby pin number
    private int CurrentPosition = 0;

    //Correct number for door to unlock 
    private int CorrectPosition = 0;

    //How much bobby pin gets moved
    private int BobbyPinSpeed = 1;

    //How close CurrentPosition can be to CorrectPosition to be accepted
    private int AcceptedRange = 5;

    //Visually turning lock stuff
    //Wheather player is currently turning lock
    private bool TurningLock = false;

    //Default rotations of lock and screw driver
    private Vector3 DefaultScrewDriverRotation;
    private Vector3 DefaultLockRotation;

    //How far the lock & screwdriver can turn by. 90 = unlock
    private int MaxTurnDegrees = 0;

    //If the lock and screw driver are moving back to original position
    private bool ResettingPosition = false;
    //private bool LockReset = false;
    //private bool ScrewDriverReset = false;

    //Used to wiggle components
    private int WiggleTick = 0;

    private Vector3 LockPosition;
    private Vector3 ScrewDriverPosition;
    private Vector3 BobbyPinPosition;

    void Start()
    {
        CorrectPosition = Random.Range(MinRange, MaxRange);

        DefaultScrewDriverRotation = ScrewDriver.transform.rotation.eulerAngles;
        DefaultLockRotation = ScrewDriver.transform.rotation.eulerAngles;

        LockPosition = Lock.transform.position;
        ScrewDriverPosition = ScrewDriver.transform.position;
        BobbyPinPosition = BobbyPin.transform.position;

    }

    void Update()
    {
        if (Active)
        {
            if (!TurningLock)
            {
                //Player tries to move bobby pin to left
                if (Input.GetKey("a") && CurrentPosition - BobbyPinSpeed >= MinRange)
                {
                    BobbyPin.transform.Rotate(new Vector3(0, 0, BobbyPinSpeed));
                    CurrentPosition -= BobbyPinSpeed;
                }

                //Player tries to move bobby pin to right
                if (Input.GetKey("d") && CurrentPosition + BobbyPinSpeed <= MaxRange)
                {
                    BobbyPin.transform.Rotate(new Vector3(0, 0, -BobbyPinSpeed));
                    CurrentPosition += BobbyPinSpeed;
                }

            }

            //Player tries to turn lock & screwdriver to unlock it
            if (Input.GetKey("w") && !ResettingPosition)
            {
                TurningLock = true;
                //Find how much the lock can rotate by. If the bobby pin is within the AcceptedRange then MaxTurnDegrees = 90.
                if (CurrentPosition <= CorrectPosition + AcceptedRange && CurrentPosition >= CorrectPosition - AcceptedRange)
                {
                    MaxTurnDegrees = 90;
                }
                //Bobby pin is not within accepted range so work out how far it is to visually show lock turning
                else
                {
                    //MaxTurnDegrees equals the distance between CorrectPosition and CurrentPosition
                    MaxTurnDegrees = 90;
                    MaxTurnDegrees -= Mathf.Abs(CorrectPosition - CurrentPosition);
                    if (MaxTurnDegrees < 5) { MaxTurnDegrees = 5; }
                }

                //Rotate lock and screw driver, ensuring they dont rotate further then MaxTurnDegrees
                if (Lock.transform.rotation.eulerAngles.z < MaxTurnDegrees)
                {
                    Lock.transform.Rotate(new Vector3(0, 0, 1));
                    ScrewDriver.transform.Rotate(new Vector3(0, 0, -2));
                }                
                
                //Lockpick has turned the full 90 degrees thus unlocking door
                if (Lock.transform.rotation.eulerAngles.z >= 90 && Lock.transform.rotation.eulerAngles.z <= 92)
                {
                    Debug.Log("door unlocked");
                    Active = false;
                    door.GetComponent<LockedDoor>().LockpickingEnd(true);
                }

                //If rotation is equal to MaxTurnDegrees and player is still holding down W then make lock, bobby pin and screw driver wiggle to indicate stress
                if (Lock.transform.rotation.eulerAngles.z < MaxTurnDegrees + 1 && Lock.transform.rotation.eulerAngles.z > MaxTurnDegrees - 1)
                {
                    WiggleComponents();
                }
            }

            //Player released w so reset rotation of lock and screw driver
            if (Input.GetKeyUp("w"))
            {
                ResettingPosition = true;
                //LockReset = false;
                //ScrewDriverReset = false; 
                Lock.transform.position = LockPosition;
                ScrewDriver.transform.position = ScrewDriverPosition;
                BobbyPin.transform.position = BobbyPinPosition;
                WiggleTick = 0;
            }

            //Lock and screw driver are still moving back to original position
            if (ResettingPosition)
            {
                //Check if the Lock & screw drivers rotation is default and if not then rotate them to default rotation
                if (Lock.transform.rotation.eulerAngles.z > 0 && Lock.transform.rotation.eulerAngles.z < 90)
                {
                    Lock.transform.Rotate(new Vector3(0, 0, -2));
                    ScrewDriver.transform.Rotate(new Vector3(0, 0, 4));
                }
                //If they are then enable turning of bobby pin
                else
                {
                    Lock.transform.eulerAngles = DefaultLockRotation;
                    ScrewDriver.transform.eulerAngles = DefaultScrewDriverRotation;
                    ResettingPosition = false;
                    TurningLock = false;
                }
                /*Debug.Log("resetting position");
                //If lock and screwdriver have reset position then enable turning of bobby pin
                if (LockReset && ScrewDriverReset)
                {
                    //Debug.Log("hello");
                    Lock.transform.eulerAngles = DefaultLockRotation;
                    ScrewDriver.transform.eulerAngles = DefaultScrewDriverRotation;
                    ResettingPosition = false;
                    TurningLock = false;
                }
                //Check if the lock rotation is default and if not then rotate them to default rotation
                if (Lock.transform.rotation.eulerAngles.z > 0 && Lock.transform.rotation.eulerAngles.z < 90)
                {
                    Debug.Log("moving lock");
                    Lock.transform.Rotate(new Vector3(0, 0, -3));
                }
                else
                {
                    LockReset = true;
                }

                //if between -180 and 0 then it needs to move
                //Check if the screw drivers rotation is default and if not then rotate them to default rotation
                if (ScrewDriver.transform.rotation.eulerAngles.z < 3 && ScrewDriver.transform.rotation.eulerAngles.z > -180) //NEED TO FIX --------------------------------------------------------------
                {
                    Debug.Log("moving screwdriver");
                    ScrewDriver.transform.Rotate(new Vector3(0, 0, 3));
                }
                else
                {
                    //Debug.Log("set to true");
                    ScrewDriverReset = true;
                }*/
            }

            if (Input.GetKeyDown("escape"))
            {
                door.GetComponent<LockedDoor>().LockpickingEnd(false);
            }

        }
    }

    //Used to save what door player is lockpicking
    public void DoorReference(GameObject doorref)
    {
        door = doorref;
    }

    //Function to wiggle lock, bobby pin and screw driver
    private void WiggleComponents()
    {
        WiggleTick++;
        if (WiggleTick > 4) { WiggleTick = 0; }
        
        if (WiggleTick == 0)
        {
            Lock.transform.position = (new Vector3(LockPosition.x, LockPosition.y + 0.001f, LockPosition.z));
            ScrewDriver.transform.position = (new Vector3(ScrewDriverPosition.x + 0.001f, ScrewDriverPosition.y, ScrewDriverPosition.z));
            BobbyPin.transform.position = (new Vector3(BobbyPinPosition.x - 0.001f, BobbyPinPosition.y, BobbyPinPosition.z));
        }
        else if (WiggleTick == 1)
        {
            Lock.transform.position = (new Vector3(LockPosition.x, LockPosition.y - 0.002f, LockPosition.z));
            ScrewDriver.transform.position = (new Vector3(ScrewDriverPosition.x - 0.002f, ScrewDriverPosition.y, ScrewDriverPosition.z));
            BobbyPin.transform.position = (new Vector3(BobbyPinPosition.x + 0.002f, BobbyPinPosition.y, BobbyPinPosition.z));
        }
        else if (WiggleTick == 2)
        {
            Lock.transform.position = (new Vector3(LockPosition.x, LockPosition.y + 0.003f, LockPosition.z));
            ScrewDriver.transform.position = (new Vector3(ScrewDriverPosition.x + 0.003f, ScrewDriverPosition.y, ScrewDriverPosition.z));
            BobbyPin.transform.position = (new Vector3(BobbyPinPosition.x - 0.003f, BobbyPinPosition.y, BobbyPinPosition.z));
        }
        else if (WiggleTick == 3)
        {
            Lock.transform.position = (new Vector3(LockPosition.x, LockPosition.y - 0.002f, LockPosition.z));
            ScrewDriver.transform.position = (new Vector3(ScrewDriverPosition.x - 0.002f, ScrewDriverPosition.y, ScrewDriverPosition.z));
            BobbyPin.transform.position = (new Vector3(BobbyPinPosition.x + 0.002f, BobbyPinPosition.y, BobbyPinPosition.z));
        }
        else
        {
            Lock.transform.position = (new Vector3(LockPosition.x, LockPosition.y, LockPosition.z));
            ScrewDriver.transform.position = (new Vector3(ScrewDriverPosition.x, ScrewDriverPosition.y, ScrewDriverPosition.z));
            BobbyPin.transform.position = (new Vector3(BobbyPinPosition.x, BobbyPinPosition.y, BobbyPinPosition.z));
        }



    }



}
