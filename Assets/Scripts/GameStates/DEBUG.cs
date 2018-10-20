﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DEBUG : GameState
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
        Debug.Log("DEBUG");
        base.OnStateEnter();
    }

    public override bool OnStateUpdate() //true = exit state
    {
        base.OnStateUpdate();
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