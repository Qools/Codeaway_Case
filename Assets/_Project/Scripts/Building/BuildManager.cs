using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : Singleton<BuildManager>
{
    private TurretAttributes turretToBuild;

    public TurretAttributes standardTurretPrefab;

    public void Init()
    {
        SetStatus(Status.ready);
    }

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    public bool CanBuild
    {
        get { return turretToBuild != null; }
    }

    public void BuildTurretOn(Node node)
    {
        if (turretToBuild == null)
        {
            if (PlayerStats.Money < standardTurretPrefab.price)
            {
                return;
            }

            PlayerStats.Money -= standardTurretPrefab.price;

            GameObject turret = Instantiate(standardTurretPrefab.turretPrefab, node.GetOffsetPosition(), Quaternion.identity);
            node.turret = turret;
        }

        else
        {
            if (PlayerStats.Money < turretToBuild.price)
            {
                return;
            }

            PlayerStats.Money -= turretToBuild.price;

            GameObject turret = Instantiate(turretToBuild.turretPrefab, node.GetOffsetPosition(), Quaternion.identity);
            node.turret = turret;
        }
    }

    public void SetTurretToBuild(TurretAttributes _turret)
    {
        turretToBuild = _turret;
    }
}
