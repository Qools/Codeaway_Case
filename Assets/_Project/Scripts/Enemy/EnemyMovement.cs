using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public EnemyAttributes enemyAttributes;

    private Transform target;
    private int waypointIndex = 0;
    private bool isReachedEnd = false;

    private void Start()
    {
        target = Waypoints.waypoints[0];
    }

    private void Update()
    {
        if (GameManager.Instance.isGameOver)
        {
            return;
        }

        if (!GameManager.Instance.isGameStarted)
        {
            return;
        }

        Movement();
    }

    private void Movement()
    {
        if (isReachedEnd)
        {
            return;
        }

        Vector3 direction = target.position - transform.position;
        transform.Translate(direction.normalized * enemyAttributes.speed * Time.deltaTime, Space.World);

        if (CalculateDistanceToWayPoint())
        {
            GetNextWaypoint();
        }
    }

    private bool CalculateDistanceToWayPoint()
    {
        bool isClose = false;

        if (Vector3.Distance(transform.position, target.position) < enemyAttributes.minDistanceToWaypoint)
        {
            isClose = true;
        }

        return isClose;
    }

    private void GetNextWaypoint()
    {
        waypointIndex++;

        if (waypointIndex == Waypoints.waypoints.Length)
        {
            isReachedEnd = true;

            EndPath();

            return;
        }

        target = Waypoints.waypoints[waypointIndex];
    }

    private void EndPath()
    {
        PlayerStats.Lives--;
        BusSystem.CallLivesReduced(PlayerStats.Lives);
        Destroy(gameObject);
    }
}
