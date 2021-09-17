using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawnBehavior : MonoBehaviour
{
    [SerializeField] private int levelNumber = 1;

    [SerializeField] private Camera mainCam;
    [SerializeField] private Gold goldHandler;
    [SerializeField] private Score scoreHandler;
    [SerializeField] private Text waveDisplay;

    [SerializeField] private GameObject boss;
    [SerializeField] private GameObject greenBoulder;
    [SerializeField] private GameObject redPage;
    [SerializeField] private GameObject blueBlade;
    [SerializeField] private float waveLength = 25f;
    [SerializeField] private float waveInterval = 5f;

    public List<GameObject> enemyList;
    private float timer = 0f;
    
    private int waveNumber;
    private int bossWaveNumber = 4;
    private int killCount = 0;
    private bool waveIsActive = false;
    private bool waveCleared = true;
    private bool bossMode = false;

    private GameObject SpawnEnemy(GameObject templateObject)
    {
        GameObject enemy = GameObject.Instantiate(templateObject, null);
        enemy.SetActive(true);
        this.enemyList.Add(enemy);
        return enemy;
    }

    public void DespawnEnemy(GameObject enemy)
    {
        for (int i = 0; i < this.enemyList.Count; i++)
        {
            if(this.enemyList[i] == enemy)
            {
                this.enemyList.RemoveAt(i);
                break;
            }
        }
        GameObject.Destroy(enemy);
    }

    private void DespawnFleet()
    {
        for(int i = 0; i < this.enemyList.Count; i++)
        {
            GameObject.Destroy(this.enemyList[i]);
        }
        this.enemyList.Clear();
    }

    private void SpawnFleet(int spawnIndex)
    {
        GameObject enemy1 = null;
        GameObject enemy2 = null;
        GameObject enemy3 = null;

        Vector3 position1;
        Vector3 position2;
        Vector3 position3;

        switch (spawnIndex)
        {
            case 0:
                enemy1 = SpawnEnemy(this.greenBoulder);
                position1 = this.mainCam.ViewportToWorldPoint(new Vector3(0.25f, 1.1f, 10f));
                enemy1.transform.position = position1;

                enemy2 = SpawnEnemy(this.greenBoulder);
                position2 = this.mainCam.ViewportToWorldPoint(new Vector3(0.5f, 1.2f, 10f));
                enemy2.transform.position = position2;

                enemy3 = SpawnEnemy(this.greenBoulder);
                position3 = this.mainCam.ViewportToWorldPoint(new Vector3(0.75f, 1.1f, 10f));
                enemy3.transform.position = position3;

                break;
            case 1:
                enemy1 = SpawnEnemy(this.redPage);
                position1 = this.mainCam.ViewportToWorldPoint(new Vector3(0.25f, 1.1f, 10f));
                enemy1.transform.position = position1;

                enemy2 = SpawnEnemy(this.redPage);
                position2 = this.mainCam.ViewportToWorldPoint(new Vector3(0.5f, 1.2f, 10f));
                enemy2.transform.position = position2;

                enemy3 = SpawnEnemy(this.redPage);
                position3 = this.mainCam.ViewportToWorldPoint(new Vector3(0.75f, 1.1f, 10f));
                enemy3.transform.position = position3;

                break;
            case 2:
                enemy1 = SpawnEnemy(this.blueBlade);
                position1 = this.mainCam.ViewportToWorldPoint(new Vector3(0.25f, 1.1f, 10f));
                enemy1.transform.position = position1;

                enemy2 = SpawnEnemy(this.blueBlade);
                position2 = this.mainCam.ViewportToWorldPoint(new Vector3(0.5f, 1.2f, 10f));
                enemy2.transform.position = position2;

                enemy3 = SpawnEnemy(this.blueBlade);
                position3 = this.mainCam.ViewportToWorldPoint(new Vector3(0.75f, 1.1f, 10f));
                enemy3.transform.position = position3;

                break;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        if (CheatsHandling.spawnAtBoss) waveNumber = bossWaveNumber - 1;
        else waveNumber = 0;

        waveDisplay.text = "WAVE " + waveNumber.ToString() + " / " + bossWaveNumber.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        this.timer += Time.deltaTime;

        if (this.waveIsActive)
        {
            if (this.waveNumber == this.bossWaveNumber)
            {
                this.boss.SetActive(true);
                this.bossMode = true;
            }

            if (!this.bossMode)
            {
                if (this.timer >= this.waveLength)
                {
                    this.waveIsActive = false;
                }

                if (this.enemyList.Count == 0)
                {
                    int spawnIndex = Random.Range(0, 3);
                    this.SpawnFleet(spawnIndex);
                }
            }
        }

        else
        {
            if (!waveCleared)
            {
                if (enemyList.Count == 0)
                {
                    waveCleared = true;
                    timer = 0f;

                    if (this.killCount >= 8)
                    {
                        this.scoreHandler.AddScore(400);
                        this.goldHandler.GainGold(20);
                    }
                }
            }

            else
            {
                if (this.timer >= this.waveInterval)
                {
                    this.timer = 0f;
                    this.killCount = 0;
                    this.waveNumber += 1;
                    waveDisplay.text = "WAVE " + waveNumber.ToString() + " / " + bossWaveNumber.ToString();
                    this.waveIsActive = true;
                    waveCleared = false;
                }
            }
        }
    }
}