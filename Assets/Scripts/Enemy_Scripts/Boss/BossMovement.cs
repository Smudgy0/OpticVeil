using UnityEngine;
using System.Collections;

public class BossMovement : MonoBehaviour
{
    public bool BossActive;

    public Player_Movement MyTarget;

    public Transform[] AttackPoints;
    public GameObject MyBullet;

    public int shootingDelay;

    bool fired;

    private void Awake()
    {
        MyTarget = FindAnyObjectByType<Player_Movement>();
    }

    private void Update()
    {
        int RNDChoice = Random.Range(1,10000);

        if(RNDChoice < 9800 && !fired)
        {
            RangedAttack();
        }

        if(!BossActive) { return; }
        LookAtPlayer();
    }

    public void LookAtPlayer()
    {
        Rotate(MyTarget.transform.position);
    }

    private void Rotate(Vector2 LookAt)
    {
        Vector2 distance = LookAt - (Vector2)transform.position;
        float angle = Mathf.Atan2(distance.y, distance.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    public void RangedAttack()
    {
        fired = true;
        int FiringPoint = Random.Range(0, AttackPoints.Length);
        GameObject bulletClone = Instantiate(MyBullet, AttackPoints[FiringPoint].position, transform.rotation);
        Destroy(bulletClone, 5);
        StartCoroutine(FiringDelay());
    }

    IEnumerator FiringDelay()
    {
        yield return new WaitForSeconds(shootingDelay);
        fired = false;
    }
}
