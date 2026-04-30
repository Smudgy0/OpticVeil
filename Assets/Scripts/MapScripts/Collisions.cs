using UnityEngine;

public class Collisions : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Bullet")
        {
            Destroy(collision.gameObject);
        }

        if (collision.tag == "BossBullet")
        {
            Destroy(collision.gameObject);
        }
    }
}
