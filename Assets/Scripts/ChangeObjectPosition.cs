using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeObjectPosition : MonoBehaviour 
{
    #region Public Fields
    public Vector3 pos = Vector3.zero;
	#endregion
	
	#region Private Fields
	#endregion
	
	#region Unity Methods
	#endregion
	
	#region Public Methods
    public void Execute()
    {
        transform.localPosition = pos;
    }
    #endregion
	
	#region Private Methods
    #endregion
}
