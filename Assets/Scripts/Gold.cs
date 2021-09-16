using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gold : MonoBehaviour
{
    [SerializeField] private Text display;
    [SerializeField] private Text brokeMessage;

    public int totalGold = 0;
    private float timer = 0f;
    private bool messageIsUp = false;

    public bool UseGold(int cost)
    {
        if(cost > totalGold)
        {
            brokeMessage.gameObject.SetActive(true);
            messageIsUp = true;
            return false;
        }

        else
        {
            totalGold -= cost;
            display.text = totalGold.ToString();
            return true;
        }
    }

    public void GainGold(int amount)
    {
        totalGold += amount;
        display.text = totalGold.ToString();
    }

    void Update()
    {
        if (messageIsUp)
        {
            timer += Time.deltaTime;
            if (timer >= 2f)
            {
                brokeMessage.gameObject.SetActive(false);
                messageIsUp = false;
                timer = 0.0f;
            }
        }
    }
}