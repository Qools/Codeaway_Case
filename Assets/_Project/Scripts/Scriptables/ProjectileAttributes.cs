using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ProjectileAttributes", menuName = "ScriptableObjects/ProjectileAttributes", order = 1)]
public class ProjectileAttributes : ScriptableObject
{
    public GameObject particleEffect;

    public float speed = 80f;
    public float explosionRadius = 0f;
}
