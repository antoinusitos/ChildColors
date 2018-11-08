using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour 
{
    #region Public Fields
    public ColorCube colorToAttribute;
    #endregion

    #region Private Fields
    #endregion

    #region Unity Methods
    private void OnTriggerEnter(Collider other)
    {
        ColorizedCube colorizedCube = other.GetComponent<ColorizedCube>();
        if(colorizedCube != null && colorizedCube.GetComponent<Movable>() != null)
        {
            colorizedCube.SetTargetColor((int)colorToAttribute);
        }
    }
    #endregion

    #region Public Methods
    #endregion

    #region Private Methods
    #endregion
}
