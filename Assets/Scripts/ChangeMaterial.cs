using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterial : MonoBehaviour
{
    #region Public Fields
    public Material mat = null;
    #endregion

    #region Private Fields
    #endregion

    #region Unity Methods
    #endregion

    #region Public Methods
    public void Execute()
    {
        GetComponent<Renderer>().material = mat;
        Debug.Log("lol");
    }
    #endregion

    #region Private Methods
    #endregion
}
