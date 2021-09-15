using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickMove : MonoBehaviour
{
    public float speed = 5f;

    public OnScreenJoystick joystick;

    private void FixedUpdate()
    {
        float x = joystick.JoystickAxis.x;
        float y = joystick.JoystickAxis.y;
        transform.Translate(x * speed * Time.deltaTime, 0, y * speed * Time.deltaTime);
    }
}
