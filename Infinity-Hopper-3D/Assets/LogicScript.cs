using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LogicScript : MonoBehaviour
{
    //Tracked values
    public Text score;
    public Vector3 frogPosition;
    public int laneCount = 0;
    public int countUntillNewRoad = 0;
    [SerializeField]
    GameObject frog;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        getFrogPosition();
        upArrowPress();
    }

    private void getFrogPosition()
    {
        frogPosition = frog.transform.position;
    }

    public void increaseLaneCount()
    {
        laneCount++;
    }

    public void increaseCountUntillNewRoad()
    {
        countUntillNewRoad++;
    }

    private void upArrowPress()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            // Allows road to move down and lane count to be tracked in one place
            increaseLaneCount();
            increaseCountUntillNewRoad();
        }
    }

    //THOUGHTS ON WHAT I WANT THIS SCRIPT TO DO
    //
    //KEEP TRACK OF VALUES THAT MANY COMPONENTS WITH NEED TO USE IN SOME WAY
    //This script is the one place where these values will be calculated and stored

    //VALUES TO BE STORED
    //frog's current position
    //score
    //laneCount- distance traveled


}
