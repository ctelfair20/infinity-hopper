using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaneControllerScript : MonoBehaviour
{
    [SerializeField] public GameObject lane;
    public List<GameObject> laneList = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        generate10Lanes();
    }

    // Update is called once per frame
    void Update()
    {
        onTapMoveDown();
    }

    public void generate10Lanes()
    {
        int yPositionForLane = -2;

        for(int i = 0; i < 11; i++)
        {
            laneList.Add(createAndActivateLane(yPositionForLane));
            yPositionForLane += 2;
        }
    }

    public GameObject createAndActivateLane(int yPosition)
    {
        Vector3 lanePosition = new Vector3(0, yPosition, 0);
        GameObject laneInstance = Instantiate(lane, lanePosition, lane.transform.rotation);
        laneInstance.SetActive(true);
        return laneInstance;
    }

    private void onTapMoveDown()
    {
        // check for touch
        // if the position of the touch at the end is above the frog
        // move lane down by 2 on y axis

        // check of up arrow press
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            // move all lanes down by one lane
            for (int i = 0; i < laneList.Count; i++)
            {
                moveDown(laneList[i]);
            }

            // Dispatch action
            EventManagerScript.current.laneMovement();
        }
    }


    private void moveDown(GameObject lane)
    {
        // grab current position of lane instace
        Vector3 currentPosition = lane.transform.position;
        // set current y axis to 2 less than itself
        float newYPosition = currentPosition.y - 2;
        // reposition lane to new y axis value
        lane.transform.position = new Vector3(currentPosition.x, newYPosition, currentPosition.z);
    }
}
