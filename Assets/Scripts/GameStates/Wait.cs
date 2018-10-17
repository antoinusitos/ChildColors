using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wait : GameState
{
    #region Public Fields
    public float timeToWait = 0;
    #endregion

    #region Private Fields
    private float _currentTimeWaited = 0;
    #endregion

    #region Unity Methods
    #endregion

    #region Public Methods
    public override void OnStateEnter()
    {
        base.OnStateEnter();
    }

    public override bool OnStateUpdate() //true = exit state
    {
        base.OnStateUpdate();
        if (_currentTimeWaited >= timeToWait)
            return true;
        _currentTimeWaited += Time.deltaTime;
        return false;
    }

    public override void OnStateExit()
    {
        base.OnStateExit();
    }
    #endregion

    #region Private Methods
    #endregion
}