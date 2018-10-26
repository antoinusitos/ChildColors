using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WaitAndExecute : MonoBehaviour 
{
    #region Public Fields
    public float timeToWait = 0;
    public UnityEvent events = null;
	#endregion
	
	#region Private Fields
	#endregion
	
	#region Unity Methods
	#endregion
	
	#region Public Methods
    public void Execute()
    {
        StartCoroutine("Wait");
    }
    #endregion
	
	#region Private Methods
    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(timeToWait);
        events.Invoke();
    }
    #endregion
}
