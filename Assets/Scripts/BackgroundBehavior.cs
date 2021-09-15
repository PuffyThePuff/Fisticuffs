using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundBehavior : MonoBehaviour
{
    [SerializeField] private Image background;
    [SerializeField] private Canvas canvas;
    [SerializeField] private float speed;
    private Vector2 currentPosition;
    private float currentPositionY = 0;
    private float endPositionY;
    private bool isScrolling = true;

    // Start is called before the first frame update
    void Start()
    {
        this.currentPosition = this.background.GetComponent<RectTransform>().anchoredPosition;
        this.endPositionY = this.canvas.GetComponent<RectTransform>().rect.height - this.background.GetComponent<RectTransform>().rect.height;
        Debug.Log(this.endPositionY);
    }

    // Update is called once per frame
    void Update()
    {
        if (isScrolling)
        {
            this.currentPositionY -= this.speed * Time.deltaTime;
            Debug.Log(this.currentPositionY);
            if (currentPositionY <= endPositionY)
            {
                this.currentPositionY = this.endPositionY;
                this.isScrolling = false;
            }
            this.currentPosition.y = currentPositionY;
            this.background.GetComponent<RectTransform>().anchoredPosition = this.currentPosition;
        }
    }
}