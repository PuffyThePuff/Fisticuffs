using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoFire : MonoBehaviour
{
    [SerializeField] private GameObject barrel;
    [SerializeField] private GameObject bulletTemplate;
    [SerializeField] private WeaponSwitch weaponSwitch;

    public List<GameObject> bulletPool;
    private float timer = 0f;
    private float totalTime = 0f;

    //lower = faster
    public float fireRate = 1f;

    private void SpawnBullet(GameObject templateObject, Vector3 pos)
    {
        GameObject bullet = GameObject.Instantiate(templateObject, null);
        bullet.SetActive(true);
        bullet.transform.position = pos;
        this.bulletPool.Add(bullet);
    }

    public void DespawnBullet(GameObject gameObject)
    {
        for (int i = 0; i < this.bulletPool.Count; i++)
        {
            if (this.bulletPool[i] == gameObject)
            {
                this.bulletPool.RemoveAt(i);
                break;
            }
        }
        GameObject.Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = barrel.transform.position;

        this.totalTime += Time.deltaTime;
        this.timer += Time.deltaTime;
        if (this.timer >= this.fireRate)
        {
            this.timer = 0f;
            SpawnBullet(bulletTemplate, pos);
        }
        if (weaponSwitch.weaponType == 0)
        {
            bulletTemplate.tag = "BulletPaper";
        }
        if (weaponSwitch.weaponType == 1)
        {
            bulletTemplate.tag = "BulletRock";
        }
        if (weaponSwitch.weaponType == 2)
        {
            bulletTemplate.tag = "BulletPaper";
        }
    }
}
