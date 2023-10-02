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
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            
            //move frog left
        }
    }
}
