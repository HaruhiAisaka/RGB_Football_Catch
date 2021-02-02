using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text highScoreText;
    public TMP_Text comboText;

    void Start()
    {
        GameState gameState = FindObjectOfType<GameState>();
        UpdateScoreText(gameState.score);
        UpdateHighScoreText(gameState.highScore);
        UpdateComboText(gameState.combo, gameState.CalculateScoreIncrease());
    }

    public void UpdateScoreText(int score)
    {
        scoreText.text = "Score: " + score.ToString();
    }

    public void UpdateHighScoreText(int highScore)
    {
        highScoreText.text = "High Score: " + highScore.ToString();
    }

    public void UpdateComboText(int combo, int scoreIncrement)
    {
        comboText.text = "Combo: " + combo.ToString() + " (+" + scoreIncrement.ToString() + ")";
    }
}
