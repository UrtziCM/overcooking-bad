using System.Collections.Generic;
using UnityEngine;

public class ScoreManager
{
    private List<int> scoreGoals;
    private int CurrentScore { get; set; } = 0;
    private int CurrentLevel { get; set; } = 0;

    public ScoreManager(List<int> scoreGoals)
    {
        SetScoreGoals(scoreGoals);
    }



    public void SetScoreGoals(List<int> scoreGoals)
    {
        this.scoreGoals = scoreGoals;
    }

    public bool ScoreReached()
    {
        return scoreGoals[CurrentLevel] < CurrentScore;
    }

    public void AddScore(int score)
    {
        CurrentScore += score;
    }

}
