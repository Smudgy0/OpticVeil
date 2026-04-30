using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;

public class Player_Movement : MonoBehaviour
{
    public int HP = 10;

    public Vector2 mousePos;
    public Vector2 mousePosLastFrame;
    private Vector2 movementDirection;
    private Rigidbody2D rb;

    public int runSpeed = 25;
    public int TempSpeed;

    bool controllerEnabled;

    public int BossImpactForce = 10;

    bool takingDamage = false;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        TempSpeed = runSpeed;
    }

    public void OnMove(InputAction.CallbackContext value)
    {
        movementDirection = value.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(movementDirection.x * TempSpeed * Time.deltaTime, movementDirection.y * TempSpeed * Time.deltaTime);
    }

    public void OnMousePosition(InputAction.CallbackContext value)
    {
        mousePos = value.ReadValue<Vector2>();

        if(mousePos != mousePosLastFrame)
        {
            mousePosLastFrame = mousePos;
            controllerEnabled = false;
        }
    }

    private void Update()
    {
        Vector3 mouseScreenPos = Camera.main.ScreenToWorldPoint(mousePos);
        if (!controllerEnabled)
        {
            Rotate(mouseScreenPos);
        }
    }

    private void Rotate(Vector2 mouseScreenPos)
    {
        Vector2 distance = mouseScreenPos - (Vector2)transform.position;
        float angle = Mathf.Atan2(distance.y, distance.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    public void ControllerRotate(InputAction.CallbackContext value)
    {
        Debug.Log("Controller Axis");
        controllerEnabled = true;

        Vector2 distance = value.ReadValue<Vector2>();
        if (distance == Vector2.zero) return;

        float angle = Mathf.Atan2(distance.y, distance.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        return;
    }

    public void TakeDamage()
    {
        HP -= 2;

        if (HP <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void Impact()
    {
        HP -= 4;
        rb.AddForce(transform.right * -5, ForceMode2D.Impulse);

        rb.linearVelocity = new Vector2(Mathf.Clamp(rb.linearVelocity.x, 0, 5), Mathf.Clamp(rb.linearVelocity.y, 0, 5));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "HidingSpot")
        {
            this.gameObject.layer = 7;
        }

        if (collision.tag == "EnemyAttack")
        {
            if(!takingDamage)
            {
                takingDamage = true;
                InvokeRepeating("TakeDamage", 1, 1);
            }

            if(HP <= 0)
            {
                Destroy(this.gameObject);
            }
        }

        if(collision.tag == "Boss")
        {
            Invoke("Impact", 0.2f);

            if (HP <= 0)
            {
                Destroy(this.gameObject);
            }
        }

        if (collision.tag == "BossBullet")
        {
            Destroy(collision.gameObject);
            HP -= 3;
            rb.AddForceX(BossImpactForce);

            if (HP <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "EnemyAttack")
        {
            CancelInvoke();
            takingDamage = false;
        }

        if (collision.tag == "HidingSpot")
        {
            this.gameObject.layer = 9;
        }
    }
}
