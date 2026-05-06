using UnityEngine;

public class GateTrigger : MonoBehaviour
{
    public GameObject Gate;
    public BossMovement BM;

    private void Awake()
    {
        BM = FindAnyObjectByType<BossMovement>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            CloseGate();
            BM.BossActive = true;
        }
    }

    public void CloseGate()
    {
        Gate.SetActive(true);
    }
}
