using System;
using System.Collections.Generic;
using UnityEngine;

public class Notes : MonoBehaviour
{
    public static readonly NotesClass first_Note = new NotesClass(
        m_title:"Name of the titleeeeee",
        m_text:"TExt about the stufffff woooo",
        m_lan:NotesClass.Language.EN
        );




    public static readonly NotesClass second_Note = new NotesClass(
       m_title: "Note 22222 testttt",
       m_text: "randddommmmm stuffeeeeeeeeeedadasdwqdw",
       m_lan: NotesClass.Language.EN
       );







    public static List<NotesClass> ListNotes;


    private void Start()
    {
        ListNotes = new List<NotesClass>();

        ListNotes.Add(first_Note);
        ListNotes.Add(second_Note);
      
    }

    public static NotesClass GetNote(int s)
    {
        return ListNotes[s];
    }


}