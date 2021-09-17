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
        onShipDeath?.Invoke(shipPosition);
    }

    public event Action onBuyBomb;
    public void BuyBomb()
    {
        onBuyBomb?.Invoke();
    }

    public event Action onSwipeUp;
    public void SwipeUp()
    {
        onSwipeUp?.Invoke();
    }
}
