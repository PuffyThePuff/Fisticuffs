using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletCollision : MonoBehaviour
{
    [SerializeField] private AutoFire autoFire;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlayerShip")
        {
            autoFire.DespawnBullet(this.gameObject);
        }
    }
}
