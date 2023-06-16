using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private ProjectileAttributes projectileAttributes;
    private Transform target;

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Movement();
    }

    private void Movement()
    {
        Vector3 direction = target.position - transform.position;
        float distanceThisFrame = projectileAttributes.speed * Time.deltaTime;

        if (direction.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }


        transform.Translate(direction.normalized * distanceThisFrame, Space.World);
        transform.LookAt(target);
    }

    private void HitTarget()
    {
        if (projectileAttributes.particleEffect != null)
        {
            GameObject particleEffect = Instantiate(projectileAttributes.particleEffect, transform.position, transform.rotation);

            Destroy(particleEffect, 2f);
        }


        if (projectileAttributes.explosionRadius > 0f)
        {
            Explode();
        }
        else
        {
            DamageTarget(target);
        }

        Destroy(gameObject);
    }

    private void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, projectileAttributes.explosionRadius);

        foreach (var collider in colliders)
        {
            if (collider.CompareTag(PlayerPrefKeys.enemy))
            {
                DamageTarget(collider.transform);
            }
        }
    }

    private void DamageTarget(Transform enemy)
    {
        Destroy(enemy.gameObject);
    }

    public void SetTarget(Transform _target)
    {
        target = _target;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, projectileAttributes.explosionRadius);
    }
}
