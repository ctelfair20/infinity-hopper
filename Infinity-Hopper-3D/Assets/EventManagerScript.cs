using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class EventManagerScript : MonoBehaviour
{
    // Singleton pattern
    // create a eventmanager variable
    public static EventManagerScript current;

    private void Awake()
    {
        // equate the eventmanager variable to "this"
        current = this;
    }

    private void Start()
    {
        // depatch action
        EventManagerScript.current.gameLoad();
    }

    // create an action
    public event Action onGameLoad;

    // create a function to invoke the action
    public void gameLoad()
    {
        if (onGameLoad != null)
        {
            onGameLoad();
        }
        // OR
        //onGameLoad?.Invoke();
    }

    // create an action
    public event Action onFrogDeath;

    // create invoking function
    public void frogDeath()
    {
        if (onFrogDeath != null)
        {
            onFrogDeath();
        }
    }

    // create an action
    public event Action onDoubleClick;
    // create invoking function
    public void doubleClick()
    {
        if (onDoubleClick != null)
        {
            onDoubleClick();
        }
    }

    public event Action<List<ScoreDistance>> onHighScoreUpdate;

    public void highScoreUpdate(List<ScoreDistance> highScoreList)
    {
        if(onHighScoreUpdate != null)
        {
            onHighScoreUpdate(highScoreList);
        }
    }

    public event Action onLaneMovement;

    public void laneMovement()
    {
        if (onLaneMovement != null)
        {
            onLaneMovement();
        }
    }

    public event Action<int, int> onActiveScoreAndDistanceUpdate;

    public void activeScoreAndDistanceUpdate(int score, int distance)
    {
        if (onActiveScoreAndDistanceUpdate != null)
        {
            onActiveScoreAndDistanceUpdate(score, distance);
        }
    }

    public event Action onHomeSreenNewGameClick;

    public void homeSreenNewGameClick()
    {
        if(onHomeSreenNewGameClick != null)
        {
            onHomeSreenNewGameClick();
        }
    }
}
