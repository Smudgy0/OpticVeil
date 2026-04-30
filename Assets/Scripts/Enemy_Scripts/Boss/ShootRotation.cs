using UnityEngine;

public class ShootRotation : MonoBehaviour
{
    public Player_Movement MyTarget;
    public BossMovement BM;

    private void Awake()
    {
        MyTarget = FindAnyObjectByType<Player_Movement>();
        BM = FindAnyObjectByType<BossMovement>();
    }
    void Update()
    {
        if (!BM.BossActive) { return; }
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
}
