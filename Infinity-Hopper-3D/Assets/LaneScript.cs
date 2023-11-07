using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaneScript : MonoBehaviour
{
    [SerializeField]
    float timer = 0;
    // rate at which cars spawn. Must be higher than speed
    [SerializeField]
    float spawnRate;
    [SerializeField]
    float speed;
    [SerializeField]
    Vector3 offsetPosition;
    Vector3 rotation;
    [SerializeField]
    CarPoolScript carPoolScript;
    [SerializeField]
    bool canGetCar = true;

    // Start is called before the first frame update
    void Start()
    {
        // either -0.7 or 0.7
        offsetPosition = new Vector3(
            -0.7f, transform.position.y, transform.position.z);
        // if offset is negative
        rotation = new Vector3(0, -90, 0); // 90 if offset is positive

        if (transform.position == new Vector3(0, -2, 0))
        {
            canGetCar = false;
        }
        else
        {
            updateLaneVariablesOnPop(transform.position);
            carPoolScript.grabCarDataFromLaneScript(
                gameObject, speed, rotation, offsetPosition);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (canGetCar)
        {
            carSpawerTimer();
        }
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
            updateLaneVariablesOnPop(transform.position);
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

    private void updateLaneVariablesOnPop(Vector3 currLanePosition)
    {
        // should be randomly true or false
        canGetCar = true;

        // deactivates all cars on the lane before poping to the top
        turnOffOldCars();

        //OFFSETPOSITION
        // grab lanes current y position
        float laneYPosition = currLanePosition.y;
        // give offset the same y val
        offsetPosition.y = laneYPosition;

        //SPEED
        //get random number between 1 and 8
        speed = Random.Range(1, 8);

        //SPAWN RATE
        if (speed >= 3)
        {
            spawnRate = speed - 2;
        }
        else if (speed >= 1)
        {
            spawnRate = Random.Range(4, 5);
        }
        Debug.Log($"speed became : {speed}", gameObject);

        //ROTATION
        
    }

    private void turnOffOldCars()
    {
        // onLanePop set all child cars to inactive
        // iterate over all children of the lane
        for (int i = 0; i < transform.childCount; i++)
        {
            // call getChild by index on the lane tranform
            Transform child = transform.GetChild(i);
            // set child to inactive
            if (child.tag == "car")
            {
                child.gameObject.SetActive(false);
            }
        }
    }
}
