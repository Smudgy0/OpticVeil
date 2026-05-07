using UnityEngine;

public class Note : MonoBehaviour
{
    public string StoryMessage;
    public NoteManager NM;

    private void Awake()
    {
        NM = FindAnyObjectByType<NoteManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            NM.ChangeNoteDesc(StoryMessage);
            Destroy(this.gameObject);
        }
    }
}
