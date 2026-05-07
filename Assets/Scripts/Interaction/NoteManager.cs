using TMPro;
using UnityEngine;

public class NoteManager : MonoBehaviour
{
    public TMP_Text NoteDesc;

    // change ui text to the string value of the note
    public void ChangeNoteDesc(string text)
    {
        NoteDesc.text = text;
    }
}
