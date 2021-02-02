using UnityEngine;

[System.Serializable]
public class Save
{
    public int highScore;

    public Save(int highScore)
    {
        this.highScore = highScore;
    }
}