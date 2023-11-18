using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Device;
using UnityEngine.SceneManagement;

public class UIControllerScript : MonoBehaviour
{
    
    public GameObject pauseScreen;
    public GameObject homeScreen;
    public GameObject gameOverScreen;
    public GameObject highScoreListScreen;
    public GameObject activeGameUIScreen;

    private void Start()
    {
        // subscript a local function to an action on the EventManagerScript
        EventManagerScript.current.onGameLoad += turnOnHomescreen;
        EventManagerScript.current.onFrogDeath += turnOnGameOverScreen;
        EventManagerScript.current.onDoubleClick += turnOnPauseScreen;
        EventManagerScript.current.onHighScoreUpdate += updateHighScoreDisplay;
    }

    // Button Functions
    public void startNewGame()
    {
        // deactivate game over screen
        toggleScreen(gameOverScreen);
    }

    public void quitGame()
    {
        // deactivate pause over screen
        toggleScreen(pauseScreen);
        // reload scene
        Scene activeScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(activeScene.name);
    }

    //TODO: if frog is hit twice, then this func will run twice 
    public void updateHighScoreDisplay(List<ScoreDistance> highScoreList)
    {
        // add current score and distance to highscore list
        Debug.Log(highScoreList[0].Score);
        // sort highScoreList from highest score to lowest score
        SortHighScoreList(highScoreList);
        // sort highScoreList from highest distance to lowest distance
    }
    
    //TODO: Continue working on this algorithm 
    void SortHighScoreList(List<ScoreDistance> highScoreList)
    {
        Debug.Log("Score Distance List:");

        for (int i = 0; i < highScoreList.Count; i++)
        {
            ScoreDistance scoreDistance = highScoreList[i];
            Debug.Log("Score: " + scoreDistance.Score + ", Distance: " + scoreDistance.Distance);
        }
    }

    //Toggle Functions
    public void turnOnHomescreen()
    {
        // activate home
        toggleScreen(homeScreen);
    }

    public void turnOffHomescreen()
    {
        // deactivate home
        toggleScreen(homeScreen);
        // activate the active game ui
        toggleScreen(activeGameUIScreen);
    }

    public void turnOnGameOverScreen()
    {
        toggleScreen(gameOverScreen);
        toggleScreen(activeGameUIScreen);
    }


    public void turnOnPauseScreen()
    {
        toggleScreen(pauseScreen);
    }

    public void toggleScreen(GameObject screen)
    {
        if (screen.activeInHierarchy)
        {
            screen.SetActive(false);
        }
        else
        {
            screen.SetActive(true);
        }
    }
}
