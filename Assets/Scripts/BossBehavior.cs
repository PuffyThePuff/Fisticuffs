using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehavior : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Camera mainCam;
    [SerializeField] private BossCollisionDetection collisionHandler;
    private float endPositionY;
    private bool isDescending = true;

    private float leftBoundX;
    private float rightBoundX;
    private bool isMovingRight = false;

    void Start()
    {
        Vector3 endPosition = this.mainCam.ViewportToWorldPoint(new Vector3(0f, 0.8f, 0f));
        Vector3 leftBound = this.mainCam.ViewportToWorldPoint(new Vector3(0.15f, 0.8f, 0f));
        Vector3 rightBound = this.mainCam.ViewportToWorldPoint(new Vector3(0.65f, 0.8f, 0f));
        this.endPositionY = endPosition.y;
        this.leftBoundX = leftBound.x;
        this.rightBoundX = rightBound.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.activeSelf)
        {
            if (isDescending)
            {
                Vector3 currentPosition = this.gameObject.transform.position;
                currentPosition.y -= this.speed * Time.deltaTime;
                if (currentPosition.y <= endPositionY)
                {
                    currentPosition.y = this.endPositionY;
                    collisionHandler.StartFight();
                    this.isDescending = false;
                }

                this.gameObject.transform.position = currentPosition;
            }

            else
            {
                Vector3 currentPosition = this.gameObject.transform.position;

                if (isMovingRight)
                {
                    currentPosition.x += this.speed * Time.deltaTime;
                    if (currentPosition.x >= rightBoundX)
                    {
                        currentPosition.x = this.rightBoundX;
                        this.isMovingRight = false;
                    }
                }
                else
                {
                    currentPosition.x -= this.speed * Time.deltaTime;
                    if (currentPosition.x <= leftBoundX)
                    {
                        currentPosition.x = this.leftBoundX;
                        this.isMovingRight = true;
                    }
                }

                this.gameObject.transform.position = currentPosition;
            }
        }
    }
}