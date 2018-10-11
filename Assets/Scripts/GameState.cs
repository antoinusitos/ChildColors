using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour 
{
    #region Public Fields
    public GameState nextGameState = null;

    public ExecuteAction enterActions = null;
    public ExecuteAction updateActions = null;
    public ExecuteAction exitActions = null;
    #endregion

    #region Private Fields
    #endregion

    #region Unity Methods
    #endregion

    #region Public Methods
    public virtual void OnStateEnter()
    {
        enterActions.ExecuteActions();
    }

    public virtual bool OnStateUpdate() //true = exit state
    {
        updateActions.ExecuteActions();
        return false;
    }

    public virtual void OnStateExit()
    {
        exitActions.ExecuteActions();
    }

    public GameState GetNextGameState()
    {
        return nextGameState;
    }
    #endregion

    #region Private Methods
    #endregion
}