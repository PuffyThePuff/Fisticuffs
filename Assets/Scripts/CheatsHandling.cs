using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheatsHandling : MonoBehaviour
{
    [SerializeField] private Toggle invincibleToggle;
    [SerializeField] private Toggle maxFiringRateToggle;
    [SerializeField] private Toggle startOnBossToggle;

    public static bool isInvincible = false;
    public static int rateOfFire = 0;
    public static int bossWaveNumber = 5;

    public void InvincibleSwitch()
    {
        if (invincibleToggle.isOn) isInvincible = true;
        else isInvincible = false;
    }

    public void FiringRateSwitch()
    {
        if (maxFiringRateToggle.isOn) rateOfFire = 4;
        else rateOfFire = 0;
    }

    public void BossSwitch()
    {
        if (startOnBossToggle.isOn) bossWaveNumber = 1;
        else bossWaveNumber = 5;
    }
}