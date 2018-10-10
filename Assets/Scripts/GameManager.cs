using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour 
{
    #region Public Fields
    public GameState startingGameState = null;
    #endregion

    #region Private Fields
    private GameState _currentGameState = null;
    #endregion

    #region Unity Methods
    private void Start()
    {
        _currentGameState = startingGameState;
        _currentGameState.OnStateEnter();
    }

    private void Update () 
	{
        if(_currentGameState.OnStateUpdate())
        {
            _currentGameState.OnStateExit();
            _currentGameState = _currentGameState.GetNextGameState();
            _currentGameState.OnStateEnter();
        }
    }
	#endregion
	
	#region Public Methods
    #endregion
	
	#region Private Methods
    #endregion
}