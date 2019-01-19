using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conveyor : MonoBehaviour 
{
    #region Public Fields
    public Conveyor nextConveyor = null;
    #endregion

    #region Private Fields
    private Movable _lastMovable = null;
	private bool _centered = false;
    private bool _waiting = false;
    private float _timeWait = 0;
    #endregion
 
    #region Unity Methods
	private void OnTriggerEnter(Collider other)
    {
        Movable m = other.GetComponent<Movable>();
        if (m != null && m.conveyor == null)
        {
            _lastMovable = m;
            m.conveyor = this;
            m.SetCanMove(false);
        }
    }
	
	private void OnTriggerExit(Collider other)
    {
        Movable m = other.GetComponent<Movable>();
        if (m != null)
        {
            _lastMovable = null;
			_centered = false;
            if(m.conveyor == this)
            {
                m.conveyor = null;
                m.SetCanMove(true);
            }
        }
    }
	
	private void Update()
    {
        if(_waiting)
        {
            _timeWait += Time.deltaTime;
            if(_timeWait >= 0.5f)
            {
                _timeWait = 0;
                _waiting = false;
                _lastMovable.SetCanMove(false);
            }
            return;
        }

        if(_lastMovable != null && !_lastMovable.GetIsMoving())
        {
			if(_centered)
			{
                nextConveyor._lastMovable = _lastMovable;
                _lastMovable.conveyor = nextConveyor;
                _lastMovable = null;
            }
			else
			{
                Vector3 dir = transform.position - _lastMovable.transform.position;
				_lastMovable.transform.position += dir.normalized * Time.deltaTime;
				if(Vector3.Distance(_lastMovable.transform.position, transform.position) <= 0.05f)
				{
					_lastMovable.transform.position = transform.position;
					_centered = true;
                    _waiting = true;
                    _lastMovable.SetCanMove(true);
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