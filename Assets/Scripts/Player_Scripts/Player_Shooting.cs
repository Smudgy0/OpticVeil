using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Shooting : MonoBehaviour
{
    public Transform firingPosition;

    public float shootingDelay = 1;
    public float shootingpower = 1;

    public int PlayerDamage;

    [SerializeField] private bool fired = false;
    [SerializeField] private bool autofire = false;

    public GameObject Bullet;

    public void OnShoot(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            autofire = true;
        }

        if(context.canceled)
        {
            autofire = false;
        }
    }

    private void Update()
    {
        if(autofire && !fired)
        {
            AutoFire();
        }
    }

    void AutoFire()
    {
        fired = true;
        GameObject bulletClone = Instantiate(Bullet, firingPosition.position, transform.rotation);
        Destroy(bulletClone, 5);
        StartCoroutine(FiringDelay());
    }

    IEnumerator FiringDelay()
    {
        yield return new WaitForSeconds(shootingDelay);
        fired = false;
    }
}
