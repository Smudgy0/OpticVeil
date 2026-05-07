using System.Collections;
using UnityEngine;
using System;

public class SpeedBoost : MonoBehaviour
{
    public Player_Movement playerMovement;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            playerMovement.TempSpeed = playerMovement.runSpeed * 2;
            StartCoroutine(Delay());
            gameObject.SetActive(false);
        }
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(5);
        playerMovement.TempSpeed = playerMovement.runSpeed;
    }

}
