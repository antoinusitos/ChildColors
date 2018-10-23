using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExecuteActionsOnCheckTrigger : ExecuteActionsOnCheck
{
    #region Public Fields
    public TriggerCheckObject trigger = null;
    #endregion

    #region Private Fields
    #endregion

    #region Unity Methods
    #endregion

    #region Public Methods
    #endregion

    #region Private Methods
    protected override void LocalUpdate()
    {
        _conditionCompleted = trigger.GetObjectInside();
    }
    #endregion
}
