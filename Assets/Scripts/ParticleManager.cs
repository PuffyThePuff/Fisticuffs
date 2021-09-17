using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    private Vector3 position;
    [SerializeField] private GameObject explosionEffectPrefab;

    // Start is called before the first frame update
    void Start()
    {
        GameEvents.current.onShipDeath += SpawnExplosion;
    }

    private void SpawnExplosion(Vector3 position)
    {
        Instantiate(explosionEffectPrefab, position, Quaternion.Euler(0, 0, 0));
    }
}
