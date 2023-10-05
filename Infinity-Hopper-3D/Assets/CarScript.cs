using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarScript : MonoBehaviour
{
    public float speed = 1;

    // Start is called before the first frame update
    void Start()
    {
        //speed = Random.Range(1, 3);
    }

    // Update is called once per frame
    void Update()
    {
        carMovement();
        destroyCar();
    }

    private void carMovement()
    {
        // move car to the left smoothly
        // car prefab as been rotated 90 degrees so Vector3.down moves the car to the right
        transform.Translate(Vector3.down * (Time.deltaTime * speed));
    }

    private void destroyCar()
    {
        if (gameObject != null && transform.position.x  >= 3)
        {
            Destroy(gameObject);
        }
    }
}
