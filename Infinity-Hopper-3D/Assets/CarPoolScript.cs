using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarPoolScript : MonoBehaviour
{
    public GameObject carPrefab;
    public List<GameObject> carPoolList;

    // Start is called before the first frame update
    void Start()
    {
        // instantiate 16 cars
        get16Cars();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void get16Cars()
    {
        for (int i = 0; i <= 15; i++)
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
}
