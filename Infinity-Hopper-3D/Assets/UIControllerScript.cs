using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Device;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIControllerScript : MonoBehaviour
{
    
    public GameObject pauseScreen;
    public GameObject homeScreen;
    public GameObject gameOverScreen;
    public Text gameOverScore;
    public Text gameOverDistance;
    public GameObject highScoreListScreen;
    public GameObject row;
    public GameObject activeGameUIScreen;
    public Text activeUIScore;
    public Text activeUIDistance;

    private void Start()
    {
        // subscript a local function to an action on the EventManagerScript
        EventManagerScript.current.onGameLoad += turnOnHomescreen;
        EventManagerScript.current.onFrogDeath += turnOnGameOverScreen;
        EventManagerScript.current.onDoubleClick += turnOnPauseScreen;
        EventManagerScript.current.onHighScoreUpdate += updateHighScoreDisplay;
        EventManagerScript.current.onActiveScoreAndDistanceUpdate += updateActiveScoreAndDistanceDisplay;
    }

    // Button Functions
    public void startNewGame()
    {
        // reload scene
        Scene activeScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(activeScene.name);
        // deactivate home over screen
        toggleScreen(homeScreen);
    }

    public void HighScoreButton()
    {
        toggleScreen(highScoreListScreen);
    }

    public void HomeButton()
    {
        toggleScreen(highScoreListScreen);
    }

    public void closeButton()
    {
        toggleScreen(highScoreListScreen);
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
    public void SortHighScoreList(List<ScoreDistance> highScoreList)
    {
        Debug.Log("Score Distance List");
        highScoreList.Sort((obj1, obj2) => obj1.Score.CompareTo(obj2.Score));
        Debug.Log("highacore list sorts");

        for (int i = 0; i < highScoreList.Count; i++)
        {
            ScoreDistance scoreDistance = highScoreList[i];
            //Debug.Log("Score: " + scoreDistance.Score + ", Distance: " + scoreDistance.Distance);
            createRow(scoreDistance);
        }
    }

    public void createRow(ScoreDistance scoreDistanceObj)
    {
        // access the highScoreTable gameobject from the screen
        Transform highScoreTable = highScoreListScreen.transform.GetChild(1);
        // create a row and set row's parent to be the highscoretable comp
        GameObject rowInstance = Instantiate(row, highScoreTable);
        // access row's score and distance children
        Text[] rowTextComps = rowInstance.GetComponentsInChildren<Text>();
        // set their values with the parameter
        rowTextComps[0].text = scoreDistanceObj.Score.ToString();
        rowTextComps[1].text = scoreDistanceObj.Distance.ToString();
        Debug.Log("s: " + rowTextComps[0].text);
        Debug.Log("d: " + rowTextComps[1].text);
        // position row
    }

    public void updateActiveScoreAndDistanceDisplay(int score, int distance)
    {
        // update the game over score and distance
        gameOverScore.text = "Score: " + score.ToString();
        gameOverDistance.text = "Distance: " + distance.ToString();
        // update the active ui score and distance
        activeUIScore.text = "Score: " + score.ToString();
        activeUIDistance.text = "Distance: " + distance.ToString();
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
