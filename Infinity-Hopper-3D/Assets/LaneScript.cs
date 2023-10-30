using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaneScript : MonoBehaviour
{
    [SerializeField]
    float timer = 0;
    [SerializeField]
    int spawnRate;
    int speed;
    Vector3 offsetPosition;
    Vector3 rotation;
    [SerializeField]
    CarPoolScript carPoolScript;

    // Start is called before the first frame update
    void Start()
    {
        // rate at which cars spawn. Must be higher than speed
        spawnRate = 2;
        speed = 2;
        // either -3 or 3
        offsetPosition = new Vector3(-3, transform.position.y, transform.position.z);
        // if offset is negative
        rotation = new Vector3(0, -90, 0); // 90 if offset is positive
        carPoolScript.grabCarDataFromLaneScript(gameObject, speed, rotation, offsetPosition);
    }

    // Update is called once per frame
    void Update()
    {
        onTapMoveDown();
        carSpawerTimer();
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

    private void carSpawerTimer()
    {
        while (timer > spawnRate)
        {
            timer = 0;
            // gain access to grabCarDataFromLaneScript()
            // from carpoolscript, pass in "this"
            carPoolScript.
                grabCarDataFromLaneScript(gameObject, speed, rotation, offsetPosition);
        }
        timer += Time.deltaTime;
    }
}
