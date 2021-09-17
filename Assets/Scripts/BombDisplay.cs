using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BombDisplay : MonoBehaviour
{
    private Text text;
    private int counter = 0;

    // Start is called before the first frame update
    void Start()
    {
        text = this.GetComponent<Text>();
        GameEvents.current.onSwipeUp += BombUsed;
        GameEvents.current.onBuyBomb += BuyBomb;
    }

    private void BombUsed()
    {
        counter--;
        if (counter < 0) { counter = 0; }
        text.text = counter.ToString();
    }

    private void BuyBomb()
    {
        counter++;
        text.text = counter.ToString();
    }
}
