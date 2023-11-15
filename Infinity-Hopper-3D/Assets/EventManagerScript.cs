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
        // depatch action
        EventManagerScript.current.gameLoad();
    }

    // create an action
    public event Action onGameLoad;

    // create a function to invoke the action
    public void gameLoad()
    {
        //TODO: some how my action has a NO value
        if (onGameLoad != null)
        {
            onGameLoad();
        }
        // OR
        //onGameLoad?.Invoke();
    }

    // create an action
    public event Action onFrogDeath;

    // create invoking function
    public void frogDeath()
    {
        Debug.Log("did you work??");
        Debug.Log(onGameLoad);
        if (onFrogDeath != null)
        {
            Debug.Log("if did you work??");
            onFrogDeath();
        }
    }
}
