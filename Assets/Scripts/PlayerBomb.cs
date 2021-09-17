using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBomb : MonoBehaviour
{
    [SerializeField] private EnemySpawnBehavior spawnBehavior;
    [SerializeField] private Gold goldHandler;
    [SerializeField] private Score scoreHandler;

    private int counter = 0;

    // Start is called before the first frame update
    void Start()
    {
        GameEvents.current.onSwipeUp += Explode;
        GameEvents.current.onBuyBomb += BuyBomb;
    }

    private void BuyBomb()
    {
        counter++;
    }

    private void Explode()
    {
        if (counter > 0)
        {
            counter--;
            this.GetComponent<MeshRenderer>().enabled = true;
            this.GetComponent<CapsuleCollider>().enabled = true;
            this.GetComponent<Animator>().enabled = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EnemyShip"))
        {
            SoundManager.PlaySound("shipDeath");
            GameEvents.current.ShipDeath(other.transform.position);
            spawnBehavior.DespawnEnemy(other.gameObject);
            goldHandler.GainGold(5);
            scoreHandler.AddScore(100);
        }
    }

    public void DestroyThis()
    {
        this.GetComponent<MeshRenderer>().enabled = false;
        this.GetComponent<CapsuleCollider>().enabled = false;
        this.GetComponent<Animator>().enabled = false;
    }
}
