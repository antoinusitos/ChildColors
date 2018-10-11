using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCheckObject : MonoBehaviour 
{
    #region Public Fields
    public Transform objectToCheck = null;
    #endregion

    #region Private Fields
    private bool _objectInside = false;
    private bool _active = true;
    #endregion

    #region Unity Methods
    private void OnTriggerEnter(Collider other)
    {
        if (!_active) return;

        if (other.transform == objectToCheck)
            _objectInside = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (!_active) return;

        if (other.transform == objectToCheck)
            _objectInside = false;
    }
    #endregion

    #region Public Methods
    public bool GetObjectInside()
    {
        return _objectInside;
    }
    #endregion

    #region Private Methods
    #endregion
}