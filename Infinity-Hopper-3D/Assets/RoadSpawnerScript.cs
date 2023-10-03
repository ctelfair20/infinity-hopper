using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadSpawnerScript : MonoBehaviour
{
    GameObject road;// get road prefab at runtime
    LogicScript logicScript;
    // access countUntillNewRoad from logicScript
    int countUntillNewRoad;


    // Start is called before the first frame update
    void Start()
    {
        // access logic script
        logicScript = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        updateRoadVariable();
        createNewRoad();
    }

    // Update is called once per frame
    void Update()
    {
        updateRoadVariable();
        roadSpawner();
    }

    private void roadSpawner()
    {
        countUntillNewRoad = logicScript.countUntillNewRoad;

        // if countUntillNewRoad is at 4
        if (countUntillNewRoad >= 4)
        {
            // spawn new road
            createNewRoad();
            // reset countUntillNewRoad to 1
            logicScript.countUntillNewRoad = 0;
        }
    }

    public void createNewRoad()
    {
        Instantiate(road, transform.position, transform.rotation);
    }

    //Prevents roads from being accessed after being destroyed
    private void updateRoadVariable()
    {
        if(road == null)
        {
            road = GameObject.FindGameObjectWithTag("Road");
        }
    }
    //THOUGHTS ON WHAT THIS SCRIPT IS SUPPOSED TO DO
    //Create new roads periodically

}
