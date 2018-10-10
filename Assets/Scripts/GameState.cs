using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour 
{
    #region Public Fields
    public GameState nextGameState = null;
    #endregion

    #region Private Fields
    #endregion

    #region Unity Methods
    #endregion

    #region Public Methods
    public virtual void OnStateEnter()
    {

    }

    public virtual bool OnStateUpdate() //true = exit state
    {
        return false;
    }

    public virtual void OnStateExit()
    {

    }

    public GameState GetNextGameState()
    {
        return nextGameState;
    }
    #endregion

    #region Private Methods
    #endregion
}