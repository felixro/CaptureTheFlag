using UnityEngine;
using System.Collections;
using Pathfinding;

[RequireComponent (typeof (Rigidbody2D))]
[RequireComponent (typeof (Seeker))]
public class EnemyAI : MonoBehaviour 
{
    public float updateRate = 2f;
    public Path path;
    public float speed = 300f;
    public ForceMode2D forceMode2D;
    public float nextWaypointDistance = 3f;

    [HideInInspector]
    public bool pathIsEnded = false;

    private Seeker seeker;
    private int currentWaypoint;

    private MovementDirection direction;
    private Behavior behavior;

    void Awake()
    {
        seeker = GetComponent<Seeker>();
        behavior = GetComponent<Behavior>();

        direction = new MovementDirection();

        StartCoroutine(UpdatePath());
    }

    public void SetTargets(
        GameObject flagTarget, 
        Transform playerTarget, 
        Transform homeBaseTarget
    )
    {
        behavior.SetTargets(flagTarget, playerTarget, homeBaseTarget);
    }

    IEnumerator UpdatePath()
    {
        Transform currentTarget = null;

        while(currentTarget == null)
        {
            currentTarget = behavior.GetCurrentTarget();

            if (currentTarget)
            {
                break;
            }

            Debug.Log("No target found");
            yield return null;
        }

        seeker.StartPath(transform.position, currentTarget.position, OnPathComplete);

        yield return new WaitForSeconds(1f/updateRate);
        StartCoroutine(UpdatePath());
    }

    public void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    void FixedUpdate()
    {
        Transform currentTarget = behavior.GetCurrentTarget();

        if (currentTarget == null)
        {
            return;
        }

        if (path == null)
        {
            return;
        }
            
        if (currentWaypoint >= path.vectorPath.Count)
        {
            if (pathIsEnded)
            {
                return;
            }

            Debug.Log("End of Path reached");

            pathIsEnded = true;

            return;
        }

        pathIsEnded = false;

        direction.SetPreviousPosition(transform.position.x);
        transform.position = Vector3.MoveTowards(transform.position, path.vectorPath[currentWaypoint], speed * Time.deltaTime);
        direction.SetNextPosition(transform.position.x);

        float dist = Vector3.Distance(transform.position, path.vectorPath[currentWaypoint]);
        if (dist < nextWaypointDistance)
        {
            currentWaypoint++;
            return;
        }
    }

    public float GetMovementDirection()
    {
        return direction.GetMovementDirection();
    }
}
