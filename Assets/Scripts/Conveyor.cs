using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conveyor : MonoBehaviour 
{
    #region Public Fields
    #endregion

    #region Private Fields
    private Movable _lastMovable = null;
	private bool _centered = false;
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
			_centered = false;
        }
    }
	
	private void Update()
    {
        if(_lastMovable != null && !_lastMovable.GetIsMoving())
        {
			if(_centered)
				_lastMovable.transform.position += transform.forward * Time.deltaTime;
			else
			{
				_lastMovable.transform.position += _lastMovable.transform.forward * Time.deltaTime;
				if(Vector3.Distance(_lastMovable.transform.position, transform.position) <= 0.05f)
				{
					_lastMovable.transform.position = transform.position;
					_centered = true;
				}
			}
        }
    }
    #endregion
 
    #region Public Methods
    #endregion

    #region Private Methods
    #endregion
}