using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyAttributes enemyAttributes;

    private Transform target;
    private int waypointIndex = 0;
    private bool isReachedEnd = false;
    private int enemyHealthPoints;

    private void Start()
    {
        target = Waypoints.waypoints[0];

        enemyHealthPoints = enemyAttributes.healthPoints;
    }

    private void Update()
    {
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

            Destroy(gameObject);

            return;
        }

        target = Waypoints.waypoints[waypointIndex];
    }

    public void TakeDamage(int _damage)
    {
        enemyHealthPoints -= _damage;

        if (enemyHealthPoints <= 0)
        {
            EnemyDeath();
        }
    }

    public void EnemyDeath()
    {
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        BusSystem.CallEnemyDestroyed();
    }
}
