using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarScript : MonoBehaviour
{
    public float speed;
    public Vector3 offsetPosition;
    public Vector3 rotation;

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

        // set rotation here
        transform.localPosition = new Vector3(offsetPosition.x, 0, 0);
        gameObject.SetActive(true);
    }

    private void carMovement()
    {
        // move car to the left smoothly
        // car prefab as been rotated 90 degrees so Vector3.down moves the car to the right
        transform.Translate(Vector3.down * (Time.deltaTime * speed));
    }

    private void deactivateCar()
    {
        if (transform.position.x  >= 3)
        {
            gameObject.SetActive(false);
            transform.parent = null;
        }
    }
}
