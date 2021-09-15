using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Camera mainCam;

    private Vector3 holder = Vector3.zero;
    private float totalCamDistance = 0f;
    private float stopCamDistance = 0.75f;
    private bool isDescending = true;

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.activeSelf)
        {
            if (isDescending)
            {
                Vector3 currentPosition = this.gameObject.transform.position;
                float distance = this.speed * Time.deltaTime;
                currentPosition.y -= distance;

                this.holder.y += distance;
                totalCamDistance = this.mainCam.WorldToViewportPoint(this.holder).y;
                if (totalCamDistance >= stopCamDistance)
                {
                    this.isDescending = false;
                }

                this.gameObject.transform.position = currentPosition;
            }
        }
    }
}