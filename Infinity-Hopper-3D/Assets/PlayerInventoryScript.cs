using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventoryScript : MonoBehaviour
{
    public int score = 0;
    public int distance = 0;
    public List<ScoreDistance> highScoreList = new List<ScoreDistance>();

    private void Start()
    {
        EventManagerScript.current.onFrogDeath += updateHighScoreList;
        EventManagerScript.current.onLaneMovement += updateActiveScoreAndDistance;
        //EventManagerScript.current.onGameLoad += startNewScoreDistance;
    }

    void AddScoreDistance(int score, int distance)
    {
        highScoreList.Add(new ScoreDistance(score, distance));
    }

    public void updateHighScoreList()
    {
        // add current score and distane to highScoreList
        AddScoreDistance(score, distance);
        // activate onHighScoreUpdate action
        EventManagerScript.current.highScoreUpdate(highScoreList);
    }


    public void updateActiveScoreAndDistance()
    {
        // increase score and distance by 1 when lane moves down
        score++;
        distance++;
        //Debug.Log("score and distance increased!");
        EventManagerScript.current.activeScoreAndDistanceUpdate(score, distance);
    }

    //public void startNewScoreDistance()
    //{

    //}
}

// Custom class for score and distance
// We want to add a new ScoreDistance object
// to our highscore list at the end of every game
public class ScoreDistance
{
    public int Score { get; set; }// this allows for easier reading and writting of the score property
    public int Distance { get; set; }// this allows for easier reading and writting of the distance property

    // This is a constructor function for the class ScoreDistance
    public ScoreDistance(int score, int distance)
    {
        Score = score;
        Distance = distance;
    }
}
