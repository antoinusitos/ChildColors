﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LaserReceiver : MonoBehaviour 
{
    #region Public Fields
    public Laser laser = null;
    public ColorCube targetColor;
    public UnityEvent events = null;
    public UnityEvent RevertEvents = null;
    #endregion

    #region Private Fields
    private bool _activated = false;
    private bool _EventsThrown = false;
    private bool _throwEventsOnce = false;
    private bool _reverted = false;
    private ColorCube _receivedColor;
    #endregion

    #region Unity Methods
    private void Update()
    {
        _receivedColor = laser.GetColorCube();
        if (!_activated && _receivedColor == targetColor)
        {
            _reverted = false;
            _activated = true;
            if((_throwEventsOnce && !_EventsThrown) || 
                !_throwEventsOnce)
                events.Invoke();
        }
        else if(_activated && _receivedColor != targetColor)
        {
            if (!_reverted)
            {
                _reverted = true;
                RevertEvents.Invoke();
                _activated = false;
            }
        }
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