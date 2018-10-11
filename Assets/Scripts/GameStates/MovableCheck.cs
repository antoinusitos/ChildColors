using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableCheck : GameState
{
    #region Public Fields
    public TriggerCheckObject triggerCheckObject = null;
    public Movable movable = null;
    #endregion

    #region Private Fields
    #endregion

    #region Unity Methods
    #endregion

    #region Public Methods
    public override void OnStateEnter()
    {
        base.OnStateEnter();
        movable.SetCanMove(true);
    }

    public override bool OnStateUpdate() //true = exit state
    {
        base.OnStateUpdate();
        if (triggerCheckObject.GetObjectInside() && !movable.GetIsMoving())
            return true;
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