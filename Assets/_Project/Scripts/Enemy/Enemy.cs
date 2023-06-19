using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyAttributes enemyAttributes;

    private int enemyHealthPoints;

    private bool isDying = false;
    private void Start()
    {
        enemyHealthPoints = enemyAttributes.healthPoints;
    }

    public void TakeDamage(int _damage)
    {
        if (isDying)
        {
            return;
        }

        enemyHealthPoints -= _damage;

        if (enemyHealthPoints <= 0)
        {
            isDying = true;

            EnemyDeath();
        }
    }

    public void EnemyDeath()
    {
        AddRewardMoney();
        Destroy(gameObject);
    }

    private void AddRewardMoney()
    {
        PlayerStats.Money += enemyAttributes.killReward;
        Debug.Log(PlayerStats.Money);
    }

    private void OnDestroy()
    {
        BusSystem.CallEnemyDestroyed();
    }
}
