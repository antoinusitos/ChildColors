using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnCube : MonoBehaviour 
{
    #region Public Fields
    #endregion

    #region Private Fields
    private Transform _parent = null;
    private Movable _movable = null;
	#endregion
	
	#region Unity Methods
	private void Start () 
	{
        _parent = transform.parent;
        _movable = _parent.GetComponent<Movable>();
    }
	#endregion
	
	#region Public Methods
    public void Turn()
    {
        if (_movable.GetIsMoving()) return;
        _parent.Rotate(Vector3.up, 90);
    }
    #endregion
	
	#region Private Methods
    #endregion
}
