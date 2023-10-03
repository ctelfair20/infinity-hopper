using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawnerScript : MonoBehaviour
{
    [SerializeField]
    GameObject car;
    public int spawnRate = 3;
    public float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        createNewCar();
    }

    // Update is called once per frame
    void Update()
    {
        spawnerTimer();
    }

    private void createNewCar()
    {
        GameObject carInstance = Instantiate(car, transform.position, transform.rotation);
    }

    private void spawnerTimer()
    {
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            timer = 0;
            createNewCar();
        }
    }
}
