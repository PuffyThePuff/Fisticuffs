using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTiltControls : MonoBehaviour
{
    private Rigidbody rb;
    private float x;
    private float y;
    [SerializeField] private float speed = 20f;
    private bool toggle = true;

    public void toggleOnOff()
    {
        if (toggle) { toggle = false; }
        else { toggle = true; }
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (toggle)
        {
            x = Input.acceleration.x * speed;
            y = Input.acceleration.y * speed;
        }
    }

    private void FixedUpdate()
    {
        if (toggle)
        {
            rb.velocity = new Vector3(x, y, 0f);
        }
    }
}
