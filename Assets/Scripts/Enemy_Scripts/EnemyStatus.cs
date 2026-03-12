using UnityEngine;

public class EnemyStatus : MonoBehaviour
{
    public Player_Shooting PS;
    public int EnemyHP = 10;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PS = FindAnyObjectByType<Player_Shooting>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Bullet")
        {
            Destroy(collision.gameObject);
            this.EnemyHP -= PS.PlayerDamage;

            if(this.EnemyHP <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
