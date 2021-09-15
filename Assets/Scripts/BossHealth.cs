using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour
{
    [SerializeField] private EndGame endgameHandler;
    [SerializeField] public Image healthBar;
    public float healthAmount = 10f;
    public float healthMax = 10f;

    // Update is called once per frame
    void Update()
    {
        if (healthAmount <= 0)
        {
            endgameHandler.OnPlayerWin();
        }
    }

    public void TakeDamage(float damage)
    {
        healthAmount -= damage;
        healthBar.fillAmount = healthAmount / healthMax;
    }
}