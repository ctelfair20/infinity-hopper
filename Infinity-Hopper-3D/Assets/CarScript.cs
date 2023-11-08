using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarScript : MonoBehaviour
{
    public float speed;
    public Vector3 offsetPosition;
    public Vector3 rotation;

    //private void OnDisable()
    //{
    //    Debug.Log("testD: carscript is disabled");
    //}

    //private void OnEnable()
    //{
    //    Debug.Log("testE: carscript is enabled");
    //}

    //private void Start()
    //{
    //    Debug.Log("testS: carscript has started");
        
    //}

    // Update is called once per frame
    void Update()
    {
        carMovement();
        deactivateCar();
    }

    public void grabCarDataFromCarPoolScript(
        float laneSpeed,
        Vector3 laneRotation,
        Vector3 laneOffsetPosition
    ){
        speed = laneSpeed;
        rotation = laneRotation;
        offsetPosition = laneOffsetPosition;

        // set position of car
        transform.localPosition = new Vector3(offsetPosition.x, 0, 0);
        setRotation();
        //Debug.Log($"rotation, offsetX :{transform.eulerAngles.z}, {offsetPosition.x}", gameObject);
        gameObject.SetActive(true);
        //Debug.Break();
    }

    private void carMovement()
    {
        // move car to the left smoothly
        // car prefab as been rotated 90 degrees so Vector3.down moves the car to the right
        transform.Translate(Vector3.down * (Time.deltaTime * speed));
    }

    private void deactivateCar()
    {
        if (transform.position.x >= 3 && transform.eulerAngles.z == 90)
        {
            gameObject.SetActive(false);
            transform.parent = null;
        }
        else if (transform.position.x <= -3 && transform.eulerAngles.z == 270)
        {
            gameObject.SetActive(false);
            transform.parent = null;
        }
    }

    private void setRotation()
    {
        // set rotation of car based on offsetPosition
        if (offsetPosition.x < 0)
        {
            //Debug.Log($"90 offsetPosition.x : {offsetPosition.x}", gameObject);
            transform.eulerAngles = rotation;
        }
        else
        {
            //Debug.Log($"270 offsetPosition.x : {offsetPosition.x}", gameObject);
            Debug.Log($"1 transform.eulerAngles.z : {transform.eulerAngles.z}", gameObject);
            transform.eulerAngles = rotation;
            Debug.Log($"2 transform.eulerAngles.z : {transform.eulerAngles.z}", gameObject);
        }
    }
}
