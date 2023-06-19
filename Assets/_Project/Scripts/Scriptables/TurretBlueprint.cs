using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TurretBlueprint", menuName = "ScriptableObjects/TurretBlueprint", order = 1)]
public class TurretBlueprint : ScriptableObject
{
    public GameObject turretPrefab;
    public GameObject upgradeTurretPrefab;

    public Sprite turretIcon;
    public Sprite upgradeTurretIcon;

    public int price;
    public int upgradePrice;
}
