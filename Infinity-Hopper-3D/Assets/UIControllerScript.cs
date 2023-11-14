using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Device;

public class UIControllerScript : MonoBehaviour
{
    public GameObject pauseScreen;
    public GameObject homeScreen;
    public GameObject gameOverScreen;
    public GameObject highScoreListScreen;
    public GameObject activeGameUIScreen;

    // Start is called before the first frame update
    void Start()
    {
        // turn on homescreen
        toggleScreen(homeScreen);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Toggle Functions
    public void turnOffHomescreen()
    {
        // deactivate home
        toggleScreen(homeScreen);
        // activate the active game ui
        toggleScreen(activeGameUIScreen);
    }

    public void onFrogDeath()
    {
        // activate gameover screen
        toggleScreen(gameOverScreen);
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
