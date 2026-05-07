using TMPro;
using UnityEngine;

public class NoteManager : MonoBehaviour
{
    public TMP_Text NoteDesc;

    public void ChangeNoteDesc(string text)
    {
        NoteDesc.text = text;
    }
}
