using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GoToPosition : MonoBehaviour 
{
    #region Public Fields
    public float speed = 1;
    public UnityEvent eventsArrived;
    public Transform target = null;
    #endregion

    #region Private Fields
    private bool _active = false;
    private bool _eventsCalled = false;
    private Transform _transform = null;
    #endregion

    #region Unity Methods
    private void Start()
    {
        _transform = transform;
    }

    private void Update()
    {
        _transform.LookAt(target.position);
        if (_active)
        {
            Vector3 finalPos = target.position;
            _transform.position = Vector3.Lerp(_transform.position, finalPos, Time.deltaTime * speed);
            if (!_eventsCalled && Vector3.Distance(_transform.position, finalPos) <= 0.1f)
            {
                _eventsCalled = true;
                eventsArrived.Invoke();
            }
        }
    }
    #endregion
 
    #region Public Methods
    public void SetActive(bool newState)
    {
        _active = newState;
    }
    #endregion

    #region Private Methods
    #endregion
}