using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GoToPlayerForward : MonoBehaviour 
{
    #region Public Fields
    public float speed = 1;
    public UnityEvent eventsArrived;
    #endregion

    #region Private Fields
    private bool _active = false;
    private bool _eventsCalled = false;
    private Transform _transform = null;
    private Transform _player = null;
    #endregion

    #region Unity Methods
    private void Start()
    {
        _transform = transform;
        _player = FindObjectOfType<Player>().transform;
    }

    private void Update()
    {
        _transform.LookAt(_player.position);
        if(_active)
        {
            Vector3 finalPos = _player.position + _player.forward * 4;
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
    public void GoToPlayer(bool newState)
    {
        _active = newState;
    }
    #endregion

    #region Private Methods
    #endregion
}