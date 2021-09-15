using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeHandling : MonoBehaviour
{
    [SerializeField] private AutoFire firingRateHandler;
    [SerializeField] private PlayerHealth healthHandler;
    [SerializeField] private Gold goldHandler;
    [SerializeField] private Text maxMessage;

    private int upgradeCountFR = CheatsHandling.rateOfFire;
    private float timer = 0f;
    private bool messageIsUp = false;

    public void UpgradeFiringRate()
    {
        if(upgradeCountFR >= 4)
        {
            maxMessage.gameObject.SetActive(true);
            messageIsUp = true;
        }

        else
        {
            if (goldHandler.UseGold(50))
            {
                upgradeCountFR += 1;
                switch (upgradeCountFR)
                {
                    case 1: firingRateHandler.fireRate = 0.9f; break;
                    case 2: firingRateHandler.fireRate = 0.75f; break;
                    case 3: firingRateHandler.fireRate = 0.6f; break;
                    case 4: firingRateHandler.fireRate = 0.5f; break;
                }
            }
        }
    }

    public void HealPlane()
    {
        if(healthHandler.healthAmount == healthHandler.healthMax)
        {
            maxMessage.gameObject.SetActive(true);
            messageIsUp = true;
        }

        else
        {
            if (goldHandler.UseGold(25)) healthHandler.HealDamage(1f);
        }
    }

    void Update()
    {
        if (messageIsUp)
        {
            timer += Time.deltaTime;
            if(timer >= 2f)
            {
                maxMessage.gameObject.SetActive(false);
                messageIsUp = false;
            }
        }
    }
}