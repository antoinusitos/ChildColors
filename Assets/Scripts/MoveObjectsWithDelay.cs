using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObjectsWithDelay : MonoBehaviour 
{
    #region Public Fields
    public MovementsAction[] movementsActions = null;
    public float delay = 0;
	#endregion
	
	#region Private Fields
	#endregion
	
	#region Unity Methods
	#endregion
	
	#region Public Methods
    public void Execute()
    {
        StartCoroutine("Move");
    }
    #endregion
	
	#region Private Methods
    private IEnumerator Move()
    {
        for(int i = 0; i < movementsActions.Length; i++)
        {
            movementsActions[i].ExecuteMovements();
            yield return new WaitForSeconds(delay);
        }
    }
    #endregion
}
