using UnityEngine;

public class BulletSpawn : MonoBehaviour
{
    public float LaunchSpeed;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        rb.linearVelocity = transform.right * LaunchSpeed;
    }
}
