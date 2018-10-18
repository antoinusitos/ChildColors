using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPlayer : MonoBehaviour 
{
    #region Public Fields
    public Transform transformToRotate = null;
    public float _speedHorizontal = 100.0f;
    public bool canMoveAtStart = true;
    #endregion

    #region Private Fields
    private Transform _transform = null;

    private float _mouseSensibility = 0.01f;
    private float _stickSensibility = 0;

    private bool _invertMouse = true;
    private bool _canMove = true;
    #endregion

    #region Unity Methods
    private void Start () 
	{
        _transform = transform;
        _canMove = canMoveAtStart;
    }
	
	private void Update () 
	{
        if (Input.GetKeyDown(KeyCode.I))
        {
            _invertMouse = !_invertMouse;
        }

        if (!_canMove) return;

        float axis = Input.GetAxis("Mouse X");

        if (axis > _mouseSensibility || axis < -_mouseSensibility)
        {
            float amount = axis * _speedHorizontal * Time.deltaTime;
            _transform.Rotate(Vector3.up, amount);
        }

        float axisTop = Input.GetAxis("Mouse Y");
        if (_invertMouse) axisTop *= -1;

        transformToRotate.Rotate(Vector3.right, axisTop);
    }
    #endregion

    #region Public Methods
    public void SetCanMove(bool newState)
    {
        _canMove = newState;
    }
    #endregion

    #region Private Methods
    #endregion
}