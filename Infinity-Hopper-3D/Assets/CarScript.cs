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
        float laneSpeed, Vector3 laneRotation, Vector3 laneOffsetPosition)
    {
        speed = laneSpeed;
        rotation = laneRotation;
        offsetPosition = laneOffsetPosition;

        // set car's position
        transform.localPosition = new Vector3(offsetPosition.x, 0, 0);
        // set car's rotation
        transform.eulerAngles = rotation;
        // activate car
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
}
