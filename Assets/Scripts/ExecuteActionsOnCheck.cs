using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ExecuteActionsOnCheck : MonoBehaviour 
{
    #region Public Fields
    public UnityEvent events = null;
    public bool executeMultipleTime = false;
    #endregion

    #region Private Fields
    protected bool _conditionCompleted = false;
    protected bool _triggered = false;
	#endregion
	
	#region Unity Methods	
	private void Update () 
	{
        LocalUpdate();

        if (_conditionCompleted && !_triggered)
        {
            if(!executeMultipleTime)
                _triggered = true;
            events.Invoke();
        }
	}
	#endregion
	
	#region Public Methods
    #endregion
	
	#region Private Methods
    protected virtual void LocalUpdate()
    {

    }
    #endregion
}
