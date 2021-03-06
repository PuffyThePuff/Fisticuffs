using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    [SerializeField] private float direction = 1;
    [SerializeField] private float speed = 20;
    [SerializeField] private AutoFire autoFire;

    private float y;
    private int life = 5;

    IEnumerator RemoveAfterSeconds(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        if (this.gameObject == null)
        {
            autoFire.DespawnBullet(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        y = this.transform.position.y;
        StartCoroutine(RemoveAfterSeconds(life));
    }

    // Update is called once per frame
    void Update()
    {
        y += speed * Time.deltaTime * direction;
        this.transform.position = new Vector3(this.transform.position.x, y, this.transform.position.z);
    }
}
