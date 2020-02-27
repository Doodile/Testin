//Jamie G
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedDoor : BaseInteract_Nick
{
    internal bool Locked = true;
    public GameObject LockpickingPrefab;
    private GameObject lockpickingObject;

    private GameObject player;
    internal bool PlayerLockpicking = false;

    public float DistanceFromCamera = 4f;

    private Door doorScript;

    private void Awake()
    {
        player = GameObject.Find("PlayerFab");
        doorScript = GetComponent<Door>();
    }

    public override void Interact()
    {
        if (!Locked)
            return;
        LockpickingStart();
    }

    public void LockpickingStart()
    {
        if (!PlayerLockpicking)
        {
            PlayerLockpicking = true;
            player.GetComponent<Playermovement_Nick>().SetCanMove(false);
            lockpickingObject = Instantiate(LockpickingPrefab, Camera.main.transform);
            lockpickingObject.transform.localPosition = new Vector3(-0.339f, 0.23f, 0.028f);
            lockpickingObject.GetComponent<Lockpicking>().DoorReference(gameObject);
            lockpickingObject.GetComponent<Lockpicking>().Active = true;
        }
        

    }

    public void LockpickingEnd(bool UnlockDoor)
    {
        if (UnlockDoor)
        {
            doorScript.LockPickDone();
            Locked = false;
        }
        PlayerLockpicking = false;
        StartCoroutine(MoveDelay());
        Destroy(lockpickingObject);

    }

    //Used to slightly delay when the character can move
    IEnumerator MoveDelay()
    {
        yield return new WaitForSeconds(0.5f);
        player.GetComponent<Playermovement_Nick>().SetCanMove(true);
    }



}
