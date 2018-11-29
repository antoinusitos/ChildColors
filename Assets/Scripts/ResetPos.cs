using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPos : Reset 
{
    #region Public Fields
    public Vector3 pos = Vector3.zero;
	public bool resetRotation = false;
	public Vector3 rot = Vector3.zero;
    #endregion

    #region Private Fields
    #endregion

    #region Unity Methods
    #endregion

    #region Public Methods
    public override void ExecuteReset()
    {
        transform.localPosition = pos;
		if(resetRotation)
			transform.localRotation = Quaternion.Euler(rot);
    }
    #endregion

    #region Private Methods
    #endregion
}
