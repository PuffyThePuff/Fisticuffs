using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] private Text display;
    public static int totalScore = 0;

    public void AddScore(int scoreIncrease)
    {
        totalScore += scoreIncrease;
        display.text = totalScore.ToString();
    }

    public static void ResetScore()
    {
        totalScore = 0;
    }
}