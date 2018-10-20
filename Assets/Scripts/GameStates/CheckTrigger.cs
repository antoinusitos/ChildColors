using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckTrigger : GameState 
{
    #region Public Fields
    public TriggerCheck triggerToCheck = null;
    public bool desactivateTriggerAfterUse = true;
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
        if(triggerToCheck.GetPlayerInside())
        {
            if(desactivateTriggerAfterUse)
                triggerToCheck.gameObject.SetActive(false);
            return true;
        }
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