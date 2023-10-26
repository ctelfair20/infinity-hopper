using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerPlacerScript : MonoBehaviour
{
    public List<int> test = new List<int> { 1, 2, 3, 4, 5 };
    public List<int> test2 = new List<int>();
    public List<int> test3;

    // Start is called before the first frame update
    void Start()
    {
        //Vector3 test = new Vector3(1, 2, 3);
        //Debug.Log(test.x);
        //Debug.Log(test.y);
        //Debug.Log(test.z);
        //test3 = new List<int> {test};
        //test3.Add(6);
        test3.AddRange(test);
        test3.Add(6);
        //List<int> test = new List<int> {1,2,3,4,5};
        //List<int> test2 = new List<int>();
        Debug.Log(test3);
        Debug.Log(test2.Count);
        //test.CopyTo(test2);
        Debug.Log(test2.Count);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //THOUGHTS ON WHAT THIS SCRIPT SHOULD DO
    //Place carSpawners at one of the possible 8 locations
    //Understand that if there is a spawner at one end of the road then a spawner CAN'T be placed there
    //There can only be a max of four spawners in the game at any given point

    //create a list of location options - there are 8
    //create an empty list to put carSpawner gameobjects in

    // copy GO list
    //iterate through 
}
