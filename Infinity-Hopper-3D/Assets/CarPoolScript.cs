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
        Debug.Log("get16Cars was called");

        for (int i = 0; i < 16; i++)
        {
            Debug.Log("get16Car loop");
            GameObject car = createCar();
            car.SetActive(false);
            Debug.Log(car.activeSelf);
            carPoolList.Add(car);
        }
    }

    private GameObject createCar()
    {
        GameObject car = Instantiate(carPrefab);
        return car;
    }

    public void grabCarDataFromLaneScript(int laneSpeed, Vector3 laneRotation, Vector3 laneOffsetPosition)
    {
        GameObject car = grabInactiveCar();

        if (car)
        {
            Debug.Log("car grabed", car);
            car.GetComponent<CarScript>().speed = laneSpeed;
            car.GetComponent<CarScript>().rotation = laneRotation;
            car.GetComponent<CarScript>().offsetPosition = laneOffsetPosition;
            car.SetActive(true);
            // I think i should be setting the parent lane here as well
        }
        else
        {
            Debug.Log("car was null");
        }
            
    }

    private GameObject grabInactiveCar()
    {
        Debug.Log(carPoolList.Count);
        for (int i = 0; i < carPoolList.Count; i++)
        {
            Debug.Log(i);
            GameObject car = carPoolList[i];

            if (i== 6)
            {
                Debug.Log(car.activeSelf);
                return car;
            }

            if (!car.activeSelf)
            {
                Debug.Log("cars retrived");
                return car;
            }
        }
        Debug.Log("all cars are active");
        return null;
    }
}
