using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadScript : MonoBehaviour
{
    Vector3 roadPosition;
    RoadSpawnerScript roadSpawnerScript;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        roadMovement();
        //destroyRoad();
    }

    private void roadMovement()
    {
        getRoadPosition();

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.position = new Vector3(roadPosition.x, roadPosition.y-1, roadPosition.z);
        }

    }

    private void getRoadPosition()
    {
        roadPosition = transform.position;
    }

    private void destroyRoad()
    {
        if (transform.position != null && transform.position.y <= -15)
        {
            Debug.Log("low enough");
            Destroy(gameObject);
        }
    }
    //THOUGHTS ON WHAT THIS SCRIPT IS SUPPOSED TO DO
    //Tell the road to move toward the frog on touch and keyboard press lane by lane
}
