//Daniel

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book : BaseInteract_Nick
{
    //Book rotation values
    private float RotX, RotY, RotZ;

    public bool InteractBook, PuzzleDone;

    private bool BookFinishedMoving;
    private Vector3 InitialBookPos, RotateBookPos;
    public float BookRotation, BookRotationSpeed;


    //Table rotation and position values
    private float RotTableX, RotTableY, RotTableZ;
    private float PosX, PosY, PosZ;


    public GameObject TurnTable;
    private Vector3 RotationTable, TableMovePos;

    void Awake()
    {
        //Get the book's rotation values 
        RotX = transform.eulerAngles.x;
        RotY = transform.eulerAngles.y;
        RotZ = transform.eulerAngles.z;

        //Get the Table's position values
        PosX = TurnTable.transform.position.x;
        PosY = TurnTable.transform.position.y;
        PosZ = TurnTable.transform.position.z;

        //Get the Table's rotation values
        RotTableX = TurnTable.transform.eulerAngles.x;
        RotTableY = TurnTable.transform.eulerAngles.y;
        RotTableZ = TurnTable.transform.eulerAngles.z;

        //Set the initial position of the book
        InitialBookPos = new Vector3(RotX, RotY, RotZ);

        //Set the rotation of the book
        RotateBookPos = new Vector3(RotX + BookRotation, RotY, RotZ);

        //Set the table move position
        TableMovePos = new Vector3(PosX, PosY, PosZ + 1);

        //Set the rotation of the table
        RotationTable = new Vector3(RotTableX, RotTableY, RotTableZ + 90);
    }

    public override void Interact()
    {
        if (!InteractBook)
        {
            //Start to interact with the book
            InteractBook = true;
        }
    }

    void FixedUpdate()
    {
        if (InteractBook)
        {
            //Check when the book stops moving
            if (Mathf.Abs(transform.rotation.eulerAngles.x - RotateBookPos.x) >= 1f && !BookFinishedMoving)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(RotateBookPos), BookRotationSpeed * 0.03f);
            }
            else
            {
                BookFinishedMoving = true;
                //Move the book back to it's original position
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(InitialBookPos), BookRotationSpeed * 0.02f);

                //Move and rotate the table
                TurnTable.transform.rotation = Quaternion.Slerp(TurnTable.transform.rotation, Quaternion.Euler(RotationTable), 0.5f * 0.02f);
                TurnTable.transform.position = Vector3.Lerp(TurnTable.transform.position, TableMovePos, 0.5f * 0.02f);
            }
        }
    }
}
