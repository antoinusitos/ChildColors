using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour 
{
    #region Public Fields
    public float _speed = 4.0f;
    public bool canMoveAtStart = true;
    #endregion

    #region Private Fields
    private Rigidbody _rigidBody = null;

    private Transform _transform = null;

    private bool _canMove = true;

    private float _stickSensibility = 0;
    #endregion

    #region Unity Methods
    private void Start () 
	{
        _rigidBody = GetComponent<Rigidbody>();
        _transform = transform;
        _canMove = canMoveAtStart;
    }
	
	private void FixedUpdate () 
	{
        Vector3 newPos = Vector3.zero;
        bool movement = false;
        if (Input.GetKey(KeyCode.Z))
        {
            movement = true;
            newPos += _transform.forward;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            movement = true;
            newPos -= _transform.forward;
        }

        if (Input.GetKey(KeyCode.D))
        {
            newPos += _transform.right;
            movement = true;
        }
        else if (Input.GetKey(KeyCode.Q))
        {
            newPos -= _transform.right;
            movement = true;
        }

        if (movement)
        {
            newPos.Normalize();
            _rigidBody.MovePosition(_rigidBody.position + newPos * Time.deltaTime * _speed);
        }
    }
	#endregion
	
	#region Public Methods
    #endregion
	
	#region Private Methods
    #endregion
}