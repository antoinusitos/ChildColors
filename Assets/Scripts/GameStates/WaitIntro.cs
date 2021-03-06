﻿using System.Collections;
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
        base.OnStateEnter();
    }

    public override bool OnStateUpdate() //true = exit state
    {
        base.OnStateUpdate();
        if (redCube.GetColorChanged())
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