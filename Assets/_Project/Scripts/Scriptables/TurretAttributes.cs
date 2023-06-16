using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TurretAttributes", menuName = "ScriptableObjects/TurretAttributes", order = 1)]
public class TurretAttributes : ScriptableObject
{
    public GameObject turretPrefab;
    public GameObject projectile;

    public Sprite turretIcon;

    public int price;
    public float range = 15f;
    public float timeToRotate = 0.25f;
    public float fireRate = 1f;
}
