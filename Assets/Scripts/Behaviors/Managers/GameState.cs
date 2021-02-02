using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    [Header("Scoring")]
    public int score = 0;
    public int highScore;
    public int scoreIncrease;
    public int ballsNeededForScoreIncrease;
    public int combo;

    [Header("UI")]
    public UIManager ui;

    [Header("Other Managers")]
    public SaveSystem saveSystem;
    public SceneLoader sceneLoader;


    public void AddScore()
    {
        score += Ball.score + CalculateScoreIncrease();
        combo ++;
        UpdateHighScore();
        ui.UpdateScoreText(score);
        ui.UpdateComboText(combo, CalculateScoreIncrease());
    }

    public int CalculateScoreIncrease()
    {
        return scoreIncrease * (combo / ballsNeededForScoreIncrease);
    }

    public void UpdateHighScore()
    {
        if (score > highScore)
        {
            highScore = score;
            ui.UpdateHighScoreText(highScore);
        }
    }

    public void GameOver()
    {
        if (score == highScore)
        {
            saveSystem.SaveGame();
        }
        sceneLoader.LoadMainMenu();
    }

}
