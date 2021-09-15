using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletCollision : MonoBehaviour
{
    [SerializeField] private AutoFire autoFire;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "EnemyShip")
        {
            autoFire.DespawnBullet(this.gameObject);
        }
    }
}
