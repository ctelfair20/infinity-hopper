using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarPoolScript : MonoBehaviour
{
    public GameObject carPrefab;
    public List<GameObject> carPoolList = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        // instantiate 16 cars
        generate16Cars();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void generate16Cars()
    {
        for (int i = 0; i < 16; i++)
        {
            GameObject car = createCar();
            car.SetActive(false);
            carPoolList.Add(car);
        }
    }

    private GameObject createCar()
    {
        GameObject car = Instantiate(carPrefab);
        return car;
    }

    public void grabCarDataFromLaneScript(GameObject lane, int laneSpeed, Vector3 laneRotation, Vector3 laneOffsetPosition)
    {
        GameObject car = grabInactiveCar();

        if (car)// if inactive car exist
        {
            CarScript carScript = car.GetComponent<CarScript>();
            // set the car's parent as the lane
            car.transform.parent = lane.transform;
            //Debug.Log(carScript.offsetPosition, car);
            //Debug.Break();
            carScript.grabCarDataFromCarPoolScript(laneSpeed, laneRotation, laneOffsetPosition);
        }
        else
        {
            Debug.Log("garbed car was null");
            // instatiate new car?
        }     
    }

    private GameObject grabInactiveCar()
    {
        for (int i = 0; i < carPoolList.Count; i++)
        {
            GameObject car = carPoolList[i];

            if (!car.activeInHierarchy)
            {
                return car;
            }
        }
        return null;
    }
}
