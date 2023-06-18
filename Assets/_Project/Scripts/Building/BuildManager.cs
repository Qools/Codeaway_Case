using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    private TurretAttributes turretToBuild;

    public TurretAttributes standardTurretPrefab;

    public static BuildManager Instance;

    // Start is called before the first frame update
    void Start()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        turretToBuild = standardTurretPrefab;
    }

    public bool CanBuild
    {
        get { return turretToBuild != null; }
    }

    public bool HasMoney
    {
        get { return PlayerStats.Money >= turretToBuild.price; }
    }

    public void BuildTurretOn(Node node)
    {
        if (PlayerStats.Money < turretToBuild.price)
        {
            return;
        }

        PlayerStats.Money -= turretToBuild.price;

        GameObject turret = Instantiate(turretToBuild.turretPrefab, node.GetOffsetPosition(), Quaternion.identity);
        node.turret = turret;
    }

    public void SetTurretToBuild(TurretAttributes _turret)
    {
        turretToBuild = _turret;
    }
}
