using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Shop : MonoBehaviour
{
    public List<TurretBlueprint> turretBlueprint = new List<TurretBlueprint>();
    [SerializeField] private List<TextMeshProUGUI> priceTexts = new List<TextMeshProUGUI>();
    [SerializeField] private List<Image> turretIcons = new List<Image>(); 

    private void Start()
    {
        SetPriceTexts();

        SetTurretIcons();
    }

    private void SetTurretIcons()
    {
        for (int i = 0; i < turretIcons.Count; i++)
        {
            turretIcons[i].sprite = turretBlueprint[i].turretIcon;
        }
    }

    private void SetPriceTexts()
    {
        for (int i = 0; i < priceTexts.Count; i++)
        {
            priceTexts[i].text = "$" + turretBlueprint[i].price.ToString();
        }
    }

    public void PurchaseTurret(int index)
    {
        BuildManager.Instance.SetTurretToBuild(turretBlueprint[index]);
    }
}
