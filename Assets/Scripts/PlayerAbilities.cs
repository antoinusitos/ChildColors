using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilities : MonoBehaviour 
{
    #region Public Fields
    public bool haveWhite = false;
    public bool haveRed = false;
    public bool haveGreen = false;
    public bool haveBlue = false;
    #endregion

    #region Private Fields
    #endregion

    #region Unity Methods
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    #endregion
 
    #region Public Methods
    public void ActivateAbilities(int state)
    {
        if (state == 0)
            haveWhite = true;
        else if (state == 1)
            haveRed = true;
        else if (state == 2)
            haveGreen = true;
        else if (state == 3)
            haveBlue = true;
    }
    #endregion

    #region Private Methods
    #endregion

}
