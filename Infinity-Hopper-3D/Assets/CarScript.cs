using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarScript : MonoBehaviour
{
    public int speed = 1;

    // Start is called before the first frame update
    void Start()
    {
        
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
        transform.Translate(Vector3.right * (Time.deltaTime * speed));
    }

    private void destroyCar()
    {
        if (gameObject != null && transform.position.x  >= 3)
        {
            Destroy(gameObject);
        }
    }
}
