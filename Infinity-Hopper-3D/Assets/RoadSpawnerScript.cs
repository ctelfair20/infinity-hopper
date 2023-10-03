using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadSpawnerScript : MonoBehaviour
{
    GameObject road;
    LogicScript logicScript;
    // access countUntillNewRoad from logic
    int countUntillNewRoad;


    // Start is called before the first frame update
    void Start()
    {
        // access logic
        logicScript = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        road = GameObject.FindGameObjectWithTag("Road");
        createNewRoad();
    }

    // Update is called once per frame
    void Update()
    {
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

    //THOUGHTS ON WHAT THIS SCRIPT IS SUPPOSED TO DO
    //Create new roads periodically

}
