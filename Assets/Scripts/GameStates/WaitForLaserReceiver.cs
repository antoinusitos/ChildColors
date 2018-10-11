using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitForLaserReceiver : GameState 
{
    #region Public Fields
    public LaserReceiver laserReceiver = null;
    #endregion

    #region Private Fields
    #endregion

    #region Unity Methods
    public override void OnStateEnter()
    {
    }

    public override bool OnStateUpdate() //true = exit state
    {
        if (laserReceiver.GetActivated())
            return true;
        return false;
    }

    public override void OnStateExit()
    {
        base.OnStateExit();
    }
    #endregion

    #region Public Methods
    #endregion

    #region Private Methods
    #endregion
}