using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Shop : MonoBehaviour
{
    public List<TurretBlueprint> turretAttributes = new List<TurretBlueprint>();
    [SerializeField] private List<TextMeshProUGUI> priceTexts = new List<TextMeshProUGUI>();

    private void Start()
    {
        SetPriceTexts();
    }

    private void SetPriceTexts()
    {
        for (int i = 0; i < priceTexts.Count; i++)
        {
            priceTexts[i].text = "$" + turretAttributes[i].price.ToString();
        }
    }

    public void PurchaseTurret(int index)
    {
        BuildManager.Instance.SetTurretToBuild(turretAttributes[index]);
    }
}
