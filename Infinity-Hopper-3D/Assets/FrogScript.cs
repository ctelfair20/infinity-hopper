using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class FrogScript : MonoBehaviour
{
    int clicked = -1;
    bool alive;

    private void Start()
    {
        EventManagerScript.current.onHomeSreenNewGameClick += updateFrogAlive;

        setFrogAlive();
    }

    // Update is called once per frame
    void Update()
    {
        frogMovement();
        checkForDoubleClick();
    }

    private void setFrogAlive()
    {
        if (SceneManager.GetActiveScene().name == "Scene v2")
        {
            alive = false;
        }
        else
        {
            alive = true;
        }
    }
    private void updateFrogAlive()
    {
        alive = true;
    }

    private void frogMovement()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow) && alive)
        {
            //move frog right
            frogMoveRight();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && alive)
        {
            //move frog left
            frogMoveLeft();
        }
    }

    private void frogMoveRight()
    {
        if(transform.position.x < 1)
        {
            transform.position = new Vector3(transform.position.x+1, transform.position.y, transform.position.z);
        }
    }

    private void frogMoveLeft()
    {
        if (transform.position.x > -1)
            transform.position = new Vector3(transform.position.x - 1, transform.position.y, transform.position.z);
    }

    //TODO: need to update to touch controls
    private void checkForDoubleClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            clicked++;
            //Debug.Log("there was a mouse click" + clicked);
            if (clicked == 2)
            {
                //Debug.Log("there was a DOUBLE click" + clicked);
                EventManagerScript.current.doubleClick();
                clicked = -1;
            }
        }
    }

    //TODO: if frog is hit multiple times, the gameover screen will toggle off and on
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Car(Clone)" && alive)
        {
            alive = false;
            EventManagerScript.current.frogDeath();
        }
    }
}
