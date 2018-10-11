using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitIntro : GameState
{
    #region Public Fields
    public ColorizedCube redCube = null;
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
        if (redCube.GetColorChanged())
            return true;
        return false;
    }

    public override void OnStateExit()
    {

    }
    #endregion

    #region Private Methods
    #endregion
}