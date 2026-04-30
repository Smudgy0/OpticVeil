using UnityEngine;
using System.Collections;

public class BossMovement : MonoBehaviour
{
    public bool BossActive;

    public Player_Movement MyTarget;

    public Transform[] AttackPoints;
    public GameObject MyBullet;

    public int shootingDelay;
    public int ChargeForce;

    public SpriteRenderer MySprite;

    public Rigidbody2D MyRigidbody;

    public bool fired;
    public bool charging;

    public float MaxSpeed;

    public int RNDChoice;

    bool canCharge = true;

    [SerializeField] private int bossHp = 30;

    private void Awake()
    {
        InvokeRepeating("RNDNum", 1, 1);

        charging = false;

        MyRigidbody = GetComponent<Rigidbody2D>();
        MySprite.color = Color.red;
        MyTarget = FindAnyObjectByType<Player_Movement>();
    }

    private void Update()
    {
        if (!BossActive) { return; }

        if (fired || charging) { return;  }

        if(RNDChoice < 70 && !fired && !charging)
        {
            fired = true;
            LookAtPlayer();
            RangedAttack();
        }

        if (RNDChoice >= 70 && !charging && canCharge)
        {
            charging = true;
            LookAtPlayer();
            Charge();
        }
    }

    private void FixedUpdate()
    {
        MyRigidbody.linearVelocity = new Vector2(Mathf.Clamp(MyRigidbody.linearVelocity.x, -MaxSpeed, MaxSpeed), Mathf.Clamp(MyRigidbody.linearVelocity.y, -MaxSpeed, MaxSpeed));
    }

    public void RNDNum()
    {
        RNDChoice = Random.Range(1, 101);
    }

    public void Charge()
    {
        Debug.Log("Boss is Charging");
        ChargeDelay();
        MyRigidbody.AddForce(transform.right * ChargeForce, ForceMode2D.Impulse);


        charging = false;
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
        int FiringPoint = Random.Range(0, AttackPoints.Length);
        GameObject bulletClone = Instantiate(MyBullet, AttackPoints[FiringPoint].position, AttackPoints[FiringPoint].rotation);
        Destroy(bulletClone, 5);
        Invoke("FiringDelay", shootingDelay);
    }

    public void FiringDelay()
    {
        fired = false;
    }

    IEnumerator ChargeDelay()
    {
        ColorChange();
        yield return new WaitForSeconds(0.5f);
        ColorChange();
        yield return new WaitForSeconds(0.5f);
        ColorChange();
        yield return new WaitForSeconds(0.5f);
        ColorChange();
        yield return new WaitForSeconds(0.5f);
    }

    public void ColorChange()
    {
        if(MySprite.color == Color.red)
        {
            MySprite.color = Color.blue;
        }
        else
        {
            MySprite.color = Color.red;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Bullet")
        {
            Destroy(collision.gameObject);
            bossHp -= 2;
            if (bossHp <= 0)
            {
                Destroy(this.gameObject);
                // add open and close boss arena
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            canCharge = false;
            Invoke("ChargeTimer", 3);
        }
    }

    public void ChargeTimer()
    {
        canCharge = true;
    }
}
