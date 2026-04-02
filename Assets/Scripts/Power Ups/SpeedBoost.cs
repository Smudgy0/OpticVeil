using System.Collections;
using UnityEngine;
using System;

public class SpeedBoost : MonoBehaviour
{
    public Player_Movement playerMovement;

    //int TempSpeed = Speed
    // in movement script use TempSpeed Instead of Speed

    //playerMovement.int runSpeed * 3f;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            playerMovement.TempSpeed = playerMovement.runSpeed * 100;
            Debug.Log("Speed increased");
            //make the sprite invisible
            StartCoroutine(Delay());
            Debug.Log("delay ended");
            playerMovement.TempSpeed = playerMovement.runSpeed;
            Debug.Log("Speed decreased");
        }
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(5);
    }

}
