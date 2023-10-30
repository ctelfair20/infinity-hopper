using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarScript : MonoBehaviour
{
    public float speed;
    public Vector3 offsetPosition;
    public Vector3 rotation;

    // Start is called before the first frame update
    void Start()
    {
        //transform.eulerAngles = rotation;
        transform.position = offsetPosition;
    }

    // Update is called once per frame
    void Update()
    {
        carMovement();
        deactivateCar();
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
            Debug.Log("car is deactivated");
            //transform.position = new Vector3(-4, 7, 0);
        }
    }
}
