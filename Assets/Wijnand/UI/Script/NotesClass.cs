
using UnityEngine;

public class NotesClass
{

    private string title = "NoteDefault";
    private string text = "DefaultText";
    public enum Language
    {
        PT,
        EN

    }
    Language lan;
    public NotesClass(string m_title=default, string m_text= default, Language m_lan = Language.EN)
    {
        title = m_title;
        text = m_text;
        lan = m_lan;


    }

    public string GetTitle()
    {
        return title;
    }

    public string Gettext()
    {
        return text;
    }

    public Language Getlanguage()
    {
        return lan;
    }

}
