using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour 
{
    #region Public Fields
    public bool turnRight = false;
    #endregion

    #region Private Fields
    private bool _isTurning = false;
    private Movable _lastMovable = null;
    #endregion

    #region Unity Methods
    private void OnTriggerEnter(Collider other)
    {
        Movable m = other.GetComponent<Movable>();
        if(m != null)
        {
            _lastMovable = m;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Movable m = other.GetComponent<Movable>();
        if (m != null)
        {
            _lastMovable = null;
        }
    }

    private void Update()
    {
        if(_lastMovable != null && !_lastMovable.GetIsMoving() && !_isTurning)
        {
            _isTurning = true;
            Invoke("Turn", 0.5f);
            Invoke("MoveAgain", 1f);
        }
    }
    #endregion

    #region Public Methods
    #endregion

    #region Private Methods
    private void Turn()
    {
        if (turnRight)
        {
            _lastMovable.transform.Rotate(Vector3.up, 90);
        }
        else
        {
            _lastMovable.transform.Rotate(Vector3.up, -90);
        }
    }

    private void MoveAgain()
    {
        _lastMovable.Move();
        _isTurning = false;
    }
    #endregion
}
