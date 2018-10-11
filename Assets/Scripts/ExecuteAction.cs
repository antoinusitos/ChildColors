using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ExecuteAction : MonoBehaviour 
{
    #region Public Fields
    public UnityEvent events = null;
	#endregion
	
	#region Private Fields
	#endregion
	
	#region Unity Methods
	#endregion
	
	#region Public Methods
    public void ExecuteActions()
    {
        events.Invoke();
    }
    #endregion
	
	#region Private Methods
    #endregion
}