using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerTrapTrigger : MonoBehaviour
{
    public GameObject Player;
    public GameObject[] Alltraps;
    public Trap ClosestTrap;


    private void Awake()
    {
        Alltraps = GameObject.FindGameObjectsWithTag("TrapBase");
    }

    void Update()
    {

        // always check for the closest trap
        //ClosestTrap = FindAnyObjectByType<Trap>();
        if(Alltraps.Length == 0) { return; }
        GameObject nearestTrap = Alltraps[0];
        float distanceToTrap = Vector2.Distance(Player.transform.position, nearestTrap.transform.position);

        for(int i = 0; i < Alltraps.Length; i++)
        {
            float distanceToCurrent = Vector2.Distance(Player.transform.position, Alltraps[i].transform.position);

            if(distanceToCurrent < distanceToTrap)
            {
                nearestTrap = Alltraps[i];
                distanceToTrap = distanceToCurrent;
            }
        }

        ClosestTrap = nearestTrap.GetComponent<Trap>();
        ClosestTrap.TriggerIcon.SetActive(true);
    }

    public void TriggerTrap(InputAction.CallbackContext context)
    {
        // when the player inputs the interact key, it triggers the cloest trap
        if (ClosestTrap == null)
        {
            ClosestTrap.TriggerIcon.SetActive(false);
            return; 
        }
        Debug.Log("TriggerTrap");
        ClosestTrap.EngageTrap();
    }
}
