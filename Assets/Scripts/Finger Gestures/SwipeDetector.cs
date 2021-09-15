using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SwipeDetector : MonoBehaviour
{
    public bool swipeLeft, swipeRight, tap, swipeUp, swipeDown;
    [SerializeField] private bool isDragging = false;
    [SerializeField] private Vector2 startTouch, swipeDelta;

    private void Update()
    {
        //yes this makes it false every frame
        tap = swipeUp = swipeDown = swipeLeft = swipeRight = false;

        //for testing
        if (Input.GetMouseButtonDown(0))
        {
            tap = true;
            isDragging = true;
            startTouch = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
            Reset();
        }

        //for touch inputs
        if (Input.touches.Length != 0)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                tap = true;
                isDragging = true;
                startTouch = Input.touches[0].position;
            }
            else if(Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                isDragging = false;
                Reset();
            }
        }

        //calculate distance
        swipeDelta = Vector2.zero;
        if (isDragging)
        {
            if (Input.touches.Length != 0)
            {
                swipeDelta = Input.touches[0].position - startTouch;
            }
            else if (Input.GetMouseButton(0))
            {
                swipeDelta = (Vector2)Input.mousePosition - startTouch;
            }
        }

        //check if cross deadzone
        if (swipeDelta.magnitude > 70)
        {
            //check direction
            float x = swipeDelta.x;
            float y = swipeDelta.y;

            //if true, on x axis
            if (Mathf.Abs(x) > Mathf.Abs(y))
            {
                if (x < 0)
                {
                    swipeLeft = true;
                }
                else
                {
                    swipeRight = true;
                }
            }
            //else, on y axis
            else
            {
                if (y < 0)
                {
                    swipeDown = true;
                }
                else
                {
                    swipeUp = true;
                }
            }

            Reset();
        }
    }

    private void Reset()
    {
        startTouch = swipeDelta = Vector2.zero;
    }
}
