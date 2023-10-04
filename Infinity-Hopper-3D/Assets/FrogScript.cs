using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogScript : MonoBehaviour
{
    LogicScript logicScript;


    // Start is called before the first frame update
    void Start()
    {
        logicScript = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        frogMovement();
    }

    private void frogMovement()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            logicScript.increaseLaneCount();
            logicScript.increaseCountUntillNewRoad();
            //move frog up
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {

            //move frog right
            frogMoveRight();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {

            //move frog left
            frogMoveLeft();
        }
    }

    private void frogMoveRight()
    {
        transform.position = new Vector3(1, 0, -0.01f);
    }

    private void frogMoveLeft()
    {
        transform.position = new Vector3(-1, 0, -0.01f);
    }
}
