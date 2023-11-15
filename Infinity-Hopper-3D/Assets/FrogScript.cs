using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogScript : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        frogMovement();
    }

    private void frogMovement()
    {
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

    private void OnCollisionEnter(Collision collision)
    {
        //todo: this func is not running
        Debug.Log(collision);
        EventManagerScript.current.frogDeath();
    }
}
