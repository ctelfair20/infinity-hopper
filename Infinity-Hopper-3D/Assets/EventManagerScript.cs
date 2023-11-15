using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class EventManagerScript : MonoBehaviour
{
    // Singleton pattern
    // create a eventmanager variable
    public static EventManagerScript current;

    private void Awake()
    {
        // equate the eventmanager variable to "this"
        current = this;
    }

    private void Start()
    {
        EventManagerScript.current.gameLoad();
    }

    // create an action
    public event Action onGameLoad;

    // create a function to invoke the action
    public void gameLoad()
    {
        Debug.Log("did you work??");
        Debug.Log(onGameLoad);
        //TODO: some how my action has a NO value
        if (onGameLoad != null)
        {
            Debug.Log("if did you work??");
            onGameLoad();
        }
        // OR
        //onGameLoad?.Invoke();
    }
}
