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
        Debug.Log("frogDeath was called");
        //Debug.Log(onGameLoad);
        if (onFrogDeath != null)
        {
            Debug.Log("onfrogDeath was called");
            onFrogDeath();
        }
    }

    // create an action
    public event Action onDoubleClick;
    // create invoking function
    public void doubleClick()
    {
        if (onDoubleClick != null)
        {
            onDoubleClick();
        }
    }
}
