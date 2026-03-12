using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class EnemyPatrolScript : MonoBehaviour
{
    public Transform[] PatrolRoute;
    public int currentPatrolPosition = 0;
    //[SerializeField] private Transform CurrentDestination;

    private Rigidbody2D RB;
    private PathfindingCells PFC;

    [SerializeField] private Vector2 currentTarget;
    [SerializeField] private int currentPosInArray = 0;

    NavMeshAgent NMA;

    private bool foundPlayer = false;

    public int runSpeed = 5;
    public float LocationDistance = 0.25f;


    [SerializeField] private enum State
    {
        Idle,
        Patrol,
        Searching,
        Chaseing
    }

    [SerializeField] private State currentState = State.Patrol;

    private void Awake()
    {
        NMA = GetComponent<NavMeshAgent>();
        RB = GetComponent<Rigidbody2D>();    
        PFC = FindAnyObjectByType<PathfindingCells>();

    }

    private void Start()
    {
        Invoke("ResetTarget", 5);
    }

    public void GoToNextPoint(Vector2 GoTo)
    {
        Rotate(GoTo);
    }

    public void ResetTarget()
    {
        PFC.GeneratePath(new Vector2(this.transform.position.x, this.transform.position.y), new Vector2(PatrolRoute[currentPatrolPosition].transform.position.x, PatrolRoute[currentPatrolPosition].transform.position.y));
    }
    private void FixedUpdate()
    {
        RB.linearVelocity = transform.right.normalized * runSpeed;
    }

    public void Rotate(Vector2 LookAt)
    {
        Vector2 distance = LookAt - (Vector2)transform.position;
        float angle = Mathf.Atan2(distance.y, distance.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    private void Update()
    {
        if(!PFC.pathsGenerated) { return; }
        if (this.gameObject.transform.position.x == PFC.finalPath[currentPosInArray].x && this.gameObject.transform.position.x == PFC.finalPath[currentPosInArray].y)
        {
            currentPosInArray++;
            if (currentPosInArray != PFC.finalPath.Count)
            {
                GoToNextPoint(PFC.finalPath[currentPosInArray]);
            }
        }

        if (!foundPlayer)
        {

        }
        switch(currentState)
        {
            case State.Idle:
                break;
            case State.Patrol:
                GoToNextPoint(currentTarget);

                if (Vector2.Distance(transform.position, currentTarget) < LocationDistance)
                {
                    currentPosInArray = Mathf.Clamp(currentPosInArray + 1, 0, PFC.finalPath.Count - 1);
                    currentTarget = PFC.finalPath[currentPosInArray];
                    if (currentPosInArray == PFC.finalPath.Count - 1)
                    {
                        currentPosInArray = 0;
                        currentPatrolPosition++;
                        ResetTarget();
                    }
                }

                else if (currentTarget == Vector2.zero)
                {
                    currentPosInArray = 0;
                    currentTarget = PFC.finalPath[currentPosInArray];
                }

                break;
            case State.Searching:
                break;
            case State.Chaseing:
                break;
        }
    }
}
