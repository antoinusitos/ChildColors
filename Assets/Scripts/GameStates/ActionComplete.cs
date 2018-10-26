using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionComplete : GameState
{
    #region Public Fields
    public bool actionComplete = false;
    #endregion

    #region Private Fields
    #endregion

    #region Unity Methods
    #endregion

    #region Public Methods
    public override void OnStateEnter()
    {
    }

    public override bool OnStateUpdate() //true = exit state
    {
        if (actionComplete)
        {
            return true;
        }
        return false;
    }

    public override void OnStateExit()
    {
        base.OnStateExit();
    }

    public void SetActionComplete(bool newState)
    {
        actionComplete = newState;
    }
    #endregion

    #region Private Methods
    #endregion
}
