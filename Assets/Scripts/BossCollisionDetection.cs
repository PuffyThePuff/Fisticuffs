using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCollisionDetection : MonoBehaviour
{
    [SerializeField] BossHealth healthHandler;
    [SerializeField] private string weakToTag;
    private bool isVulnerable = false;

    public void StartFight()
    {
        isVulnerable = true;
        healthHandler.healthBar.gameObject.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isVulnerable && other.tag == weakToTag)
        {
            healthHandler.TakeDamage(1);
        }
    }
}