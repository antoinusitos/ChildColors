using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DoActions : GameState
{
    #region Public Fields
    public UnityEvent events = null;
    #endregion

    #region Private Fields
    #endregion

    #region Unity Methods
    #endregion

    #region Public Methods
    public override void OnStateEnter()
    {
        events.Invoke();
    }

    public override bool OnStateUpdate() //true = exit state
    {
        return false;
    }

    public override void OnStateExit()
    {
    }
    #endregion

    #region Private Methods
    #endregion
}