using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private EndGame endgameHandler;
    [SerializeField] private Image healthBar;
    public float healthAmount = 3;
    public float healthMax = 3;
    private bool hasDied = false;

    private void Update()
    {
        if (!hasDied && healthAmount <= 0)
        {
            endgameHandler.OnPlayerLose();
            hasDied = true;
        }
    }

    public void TakeDamage(float damage)
    {
        healthAmount -= damage;
        healthBar.fillAmount = healthAmount / healthMax;
    }

    public void HealDamage(float heal)
    {
        healthAmount += heal;
        healthAmount = Mathf.Clamp(healthAmount, 0, healthMax);

        healthBar.fillAmount = healthAmount / healthMax;
    }
}