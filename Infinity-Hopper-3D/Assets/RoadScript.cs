using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadScript : MonoBehaviour
{
    Vector3 roadPosition;
    //LogicScript logicScript;


    // Start is called before the first frame update
    void Start()
    {
        //logicScript = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        roadMovement();
        destroyRoad();
    }

    private void roadMovement()
    {
        getRoadPosition();

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.position = new Vector3(roadPosition.x, roadPosition.y-2, roadPosition.z);
            //logicScript.increaseLaneCount();
            //logicScript.increaseCountUntillNewRoad();
        }

    }

    private void getRoadPosition()
    {
        roadPosition = transform.position;
    }

    private void destroyRoad()
    {
        if (gameObject != null && transform.position.y <= -10)
        {
            Destroy(gameObject);
        }
    }
    //THOUGHTS ON WHAT THIS SCRIPT IS SUPPOSED TO DO
    //Tell the road to move toward the frog on touch and keyboard press lane by lane
    //Remove roads when out of view
}
