using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollisionDetection : MonoBehaviour
{
    [SerializeField] private EnemySpawnBehavior spawnBehavior;
    [SerializeField] private Gold goldHandler;
    [SerializeField] private Score scoreHandler;
    [SerializeField] private string diesToTag;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == diesToTag)
        {
            SoundManager.PlaySound("shipDeath");
            GameEvents.current.ShipDeath(this.transform.position);
            spawnBehavior.DespawnEnemy(this.gameObject);
            goldHandler.GainGold(5);
            scoreHandler.AddScore(100);
        }
    }
}