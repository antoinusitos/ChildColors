using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour 
{
    #region Public Fields
    #endregion

    #region Private Fields
    #endregion

    #region Unity Methods	
    private void OnTriggerEnter(Collider other)
    {
        Movable m = other.GetComponent<Movable>();
        if(m != null)
        {
            m.transform.SetParent(transform, true);
        }
    }
    #endregion

    #region Public Methods
    #endregion

    #region Private Methods
    #endregion
}
