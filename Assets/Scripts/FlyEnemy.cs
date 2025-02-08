using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyEnemy : MonoBehaviour
{
    public float flightSpeed = 2f;
    public List<Transform> wayPoints;
    Transform nextWaypoint;
    int waypointNum = 0;
    Rigidbody2D rb;
    public float waypointReachedDistance = 0.1f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        nextWaypoint = wayPoints[waypointNum];
    }

    private void Flight()
    {
        Vector2 directionToWaypoint = (nextWaypoint.position - transform.position).normalized;
        float distance = Vector2.Distance(nextWaypoint.position, transform.position);

        rb.velocity = directionToWaypoint * flightSpeed;

        if(distance <= waypointReachedDistance)
        {
            waypointNum++;

            if(waypointNum >= wayPoints.Count)
            {
                waypointNum = 0;
            }

            nextWaypoint = wayPoints[waypointNum];
        }
    }
    

    private void FixedUpdate()
    {
        Flight();
    }
}
