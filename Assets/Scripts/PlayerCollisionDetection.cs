using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionDetection : MonoBehaviour
{
    [SerializeField] private PlayerHealth playerHealth;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "EnemyBullet")
        {
            playerHealth.TakeDamage(1);
        }

        else if (other.tag == "EnemyShip")
        {
            playerHealth.TakeDamage(1);
        }
    }
}
