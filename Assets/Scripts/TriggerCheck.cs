using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCheck : MonoBehaviour 
{
    #region Public Fields
    #endregion

    #region Private Fields
    private bool _playerInside = false;
    private bool _active = true;
    #endregion

    #region Unity Methods
    private void OnTriggerEnter(Collider other)
    {
        if (!_active) return;

        Player p = other.GetComponent<Player>();
        if(p != null)
        {
            _playerInside = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!_active) return;

        Player p = other.GetComponent<Player>();
        if (p != null)
        {
            _playerInside = false;
        }
    }
    #endregion

    #region Public Methods
    public bool GetPlayerInside()
    {
        return _playerInside;
    }
    #endregion

    #region Private Methods
    #endregion
}