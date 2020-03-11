using System;
using System.Collections.Generic;
using UnityEngine;

public class Notes : MonoBehaviour
{
    public static readonly NotesClass first_Note = new NotesClass(
        m_title:"Name of the titleeeeee",
        m_text:"TExt about the stufffff woooo"

        );




    public static readonly NotesClass second_Note = new NotesClass(
       m_title: "Note 22222 testttt",
       m_text: "randddommmmm stuffeeeeeeeeeedadasdwqdw"

       );







    public static List<NotesClass> ListNotes;


    private void Start()
    {
        ListNotes = new List<NotesClass>();
        ListNotes.Add(null);
        ListNotes.Add(first_Note);
        ListNotes.Add(second_Note);
      
    }

    public static NotesClass GetNote(int s)
    {
        Debug.Log(s);
        return ListNotes[s];
    }


}