
using UnityEngine;

public class NotesClass
{

    private string title = "NoteDefault";
    private string text = "DefaultText";
   
    public NotesClass(string m_title=default, string m_text= default)
    {
        title = m_title;
        text = m_text;
      


    }

    public string GetTitle()
    {
        return title;
    }

    public string Gettext()
    {
        return text;
    }

 
}
