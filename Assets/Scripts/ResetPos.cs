using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPos : Reset 
{
    #region Public Fields
    public Vector3 pos = Vector3.zero;
    #endregion

    #region Private Fields
    #endregion

    #region Unity Methods
    #endregion

    #region Public Methods
    public override void ExecuteReset()
    {
        transform.localPosition = pos;
    }
    #endregion

    #region Private Methods
    #endregion
}
