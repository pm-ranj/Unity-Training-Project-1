using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int score = 0;
    Text scoreText;
    void Start()
    {
        scoreText = GetComponent<Text>();       
    }

    void Update()
    {
        DisplayScore();
    }
    void DisplayScore()
    {
        scoreText.text = score.ToString();
    }
    public void AddScore()
    {
        score += 20;
    }
}
