using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents current;

    private void Awake()
    {
        current = this;
    }

    public event Action<Vector3> onShipDeath;
    public void ShipDeath(Vector3 shipPosition)
    {
        if (onShipDeath != null)
        {
            onShipDeath(shipPosition);
        }
    }

    public event Action onSpendMoney;
    public void SpendMoney()
    {
        if (onSpendMoney != null)
        {
            onSpendMoney();
        }
    }
}
