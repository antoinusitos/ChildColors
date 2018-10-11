using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLevel : MonoBehaviour 
{
    #region Public Fields
    public int nextLevel = 0;
    #endregion

    #region Private Fields
    #endregion

    #region Unity Methods
    private void OnTriggerEnter(Collider other)
    {
        Player p = other.GetComponent<Player>();
        if(p != null)
        {
            SceneManager.LoadScene(nextLevel);
        }
    }
    #endregion

    #region Public Methods
    #endregion

    #region Private Methods
    #endregion
}