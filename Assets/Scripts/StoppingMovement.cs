using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoppingMovement : MonoBehaviour 
{
    #region Public Fields
    public Movable[] movables = null;
    #endregion

    #region Private Fields
    private int _movementsDone = 0;
    #endregion

    #region Unity Methods
    private void Update()
    {
        for(int i = 0; i < movables.Length; i++)
        {
            if(!movables[i].GetIsMoving() && movables[i].GetHasMoved() && movables[i].GetCanMove())
            {
                _movementsDone++;
                movables[i].GetComponent<MovementsAction>().ExecuteMovements();
                movables[i].SetCanMove(false);
                if(_movementsDone >= movables.Length)
                {
                    gameObject.SetActive(false);
                }
            }
        }
    }
    #endregion

    #region Public Methods
    #endregion

    #region Private Methods
    #endregion
}
