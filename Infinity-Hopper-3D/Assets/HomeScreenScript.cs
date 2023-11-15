using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeScreenScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void turnOffHomescreen()
    {
        // deactivate home
        gameObject.SetActive(true);
    }

}
