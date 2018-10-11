using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LaserReceiver : MonoBehaviour 
{
    #region Public Fields
    public Laser laser = null;
    public ColorCube targetColor;
    public UnityEvent events = null;
    #endregion

    #region Private Fields
    private bool _activated = false;
    private bool _EventsThrown = false;
    private bool _throwEventsOnce = false;
    #endregion

    #region Unity Methods
    private void Update()
    {
        if (laser.GetColorCube() == targetColor)
        {
            _activated = true;
            if((_throwEventsOnce && !_EventsThrown) || 
                !_throwEventsOnce)
                events.Invoke();
        }
        else
            _activated = false;
    }
    #endregion

    #region Public Methods
    public bool GetActivated()
    {
        return _activated;
    }
    #endregion

    #region Private Methods
    #endregion
}