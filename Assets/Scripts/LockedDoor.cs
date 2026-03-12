using UnityEngine;

public class LockedDoor : MonoBehaviour
{
    public Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created


    void Start()
    {
        transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
    }



}