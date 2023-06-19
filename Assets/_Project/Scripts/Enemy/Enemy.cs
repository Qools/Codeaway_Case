using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Enemy : MonoBehaviour
{
    public EnemyAttributes enemyAttributes;
    [SerializeField] private Image healthBar;

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

        healthBar.DOFillAmount(enemyHealthPoints / enemyAttributes.healthPoints, 0.5f);

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
