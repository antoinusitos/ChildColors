using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ResetButton : Action 
{
    #region Public Fields
    public Transform scene = null;
	public bool useScene = false;
	public Reset[] toResets = null;
    public UnityEvent postResetEvents;
    public bool canReset = true;
	#endregion
	
	#region Private Fields
	#endregion
	
	#region Unity Methods
	#endregion
	
	#region Public Methods
    public void Execute()
    {
        if (!canReset) return;

		if(useScene)
		{
			Reset[] resets = scene.GetComponentsInChildren<Reset>();
			for(int i = 0; i < resets.Length; i++)
			{
				resets[i].ExecuteReset();
			}
		}
		else
		{
			for(int i = 0; i < toResets.Length; i++)
			{
				toResets[i].ExecuteReset();
			}
		}
        postResetEvents.Invoke();
    }

    public void SetCanReset(bool newState)
    {
        canReset = newState;
    }
    #endregion
	
	#region Private Methods
    #endregion
}
