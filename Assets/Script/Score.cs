using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public float score = 0f;
    public TextMeshProUGUI scoreText;

    public void IncreaseScore(int value)
    {
        score += value;
        scoreText.SetText("Pontos: " + score.ToString());
    }
}
