using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public List<TurretAttributes> turretAttributes = new List<TurretAttributes>();
    
    public void PurchaseTurret(int index)
    {
        BuildManager.Instance.SetTurretToBuild(turretAttributes[index]);
    }
}
