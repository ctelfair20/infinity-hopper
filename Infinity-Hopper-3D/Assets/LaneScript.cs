using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaneScript : MonoBehaviour
{
    int spawnRate;
    int speed;
    int offsetPosition;
    float rotation;
    public CarPoolScript carPoolScript;

    // Start is called before the first frame update
    void Start()
    {
        // get carPoolScript
        //carPoolScript
        // rate at which cars spawn. Must be higher than speed
        spawnRate = 4;
        speed = 2;
        // either -3 or 3
        offsetPosition = -3;
        // if offset is negative
        rotation = -90; // 90 if offset is positive
    }

    // Update is called once per frame
    void Update()
    {
        onTapMoveDown();
    }

    private void onTapMoveDown()
    {
        // check for touch
            // if the position of the touch at the end is above the frog
                // move lane down by 2 on y axis

        // check of up arrow press
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            // call moveDown
            moveDown();
        }
    }

    [ContextMenu("moveDown")]
    private void moveDown()
    {
        // grab current position
        Vector3 currentPosition = transform.position;
        // set current y axis to 2 less than itself
        float newYPosition = currentPosition.y - 2;
        // reposition lane to new y axis value
        transform.position = new Vector3(currentPosition.x, newYPosition, currentPosition.z);
        // move lane to top if necessary
        popToTheTop();
    }

    [ContextMenu("PopToTheTop")]
    private void popToTheTop()
    {
        // grab current position
        Vector3 currentPosition = transform.position;
        // set current y axis to 6 (above all other lanes out of screen view)
        float newYPosition = 6;

        // if lane is out of screen view,
        if (currentPosition.y <= -4)
        {
            // move lane to the top of the screen outside of view
            transform.position = new Vector3(currentPosition.x, newYPosition, currentPosition.z);
        }
    }
}
