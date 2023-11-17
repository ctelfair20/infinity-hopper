using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventoryScript : MonoBehaviour
{
    public int score = 0;
    public int distance = 0;
    public List<int> highScoreList = new List<int>();

    private void Start()
    {
        EventManagerScript.current.onFrogDeath += updateHighScoreList;
    }

    public void updateHighScoreList()
    {
        // add current score and distane
    }

    public void updateActiveScoreAndDistance()
    {
        // increase score and distance by 1 when lane moves down
    }
}
