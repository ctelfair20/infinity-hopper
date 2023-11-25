using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LaneControllerScript : MonoBehaviour
{
    bool isLaneMovementActive = false;

    [SerializeField] public GameObject lane;
    public List<GameObject> laneList = new List<GameObject>();
    public List<string> laneMaterialNames = new List<string>
    {
        "BlueRoad","YellowRoad","MagentaRoad","DarkPurpleRoad","GreenRoad",
        "DarkBlueRoad","OrangeRoad","PurpleRoad","BrownRoad","CarMaterial",
    };
    public List<Material> laneMaterialsList = new List<Material>();

    // Start is called before the first frame update
    void Start()
    {
        EventManagerScript.current.onHomeSreenNewGameClick += updateIsLaneMovementActive;
        EventManagerScript.current.onFrogDeath += updateIsLaneMovementActive;

        generateListOfMaterials();
        generate10Lanes();
        setIsLaneMovementActive();
    }

    // Update is called once per frame
    void Update()
    {
        onTapMoveDown();
    }

    public void generateListOfMaterials()
    {
        for (int i = 0; i < 10; i++)
        {
            laneMaterialsList.Add(Resources.Load<Material>("Materials/" + laneMaterialNames[i]));
        }
    }

    public void generate10Lanes()
    {
        int yPositionForLane = -2;

        for (int i = 0; i < 10; i++)
        {
            Material material = laneMaterialsList[i];
            // Use the material
            if (material != null)
            {
                // Do something with the material
                laneList.Add(createAndActivateLane(yPositionForLane));
                laneList[i].transform.GetChild(0).
                    GetComponent<Renderer>().material = material;
                yPositionForLane += 2;
            }
            else
            {
                Debug.LogError("Material not found!");
            }
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
        if (Input.GetKeyDown(KeyCode.UpArrow) && isLaneMovementActive)
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

    private void setIsLaneMovementActive()
    {
        if (SceneManager.GetActiveScene().name == "Scene v2")
        {
            isLaneMovementActive = false;
        }
        else
        {
            isLaneMovementActive = true;
        }
    }

    private void updateIsLaneMovementActive()
    {
        if(isLaneMovementActive) {

            isLaneMovementActive = false;
        }
        else
        {
            isLaneMovementActive = true;
        }
    }
}
