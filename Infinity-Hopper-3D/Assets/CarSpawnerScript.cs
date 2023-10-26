using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawnerScript : MonoBehaviour
{
    [SerializeField]
    GameObject car;
    public int spawnRate = 3;
    public float timer = 0;
    public float carSpeed;

    // Start is called before the first frame update
    void Start()
    {
        carSpeed = Random.Range(1, 3);
        createNewCar();
    }

    // Update is called once per frame
    void Update()
    {
        spawnerTimer();
        spawnerMovement();
        destroySpawner();
    }

    private void createNewCar()
    {
        GameObject carInstance = Instantiate(car, transform.position, car.transform.rotation);
        CarScript carScript = carInstance.GetComponent<CarScript>();
        carScript.speed = carSpeed;
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

    private Vector3 getSpawnerPosition()
    {
        Vector3 spawnerPosition = transform.position;
        return spawnerPosition;
    }

    private void spawnerMovement()
    {
        Vector3 spawnerPosition = getSpawnerPosition();

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.position = new Vector3(
                spawnerPosition.x, spawnerPosition.y - 2, spawnerPosition.z);
        }
    }

    private void destroySpawner()
    {
        if (gameObject != null && transform.position.y <= -5)
        {
            Destroy(gameObject);
        }
    }
}
