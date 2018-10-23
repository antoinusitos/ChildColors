using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLevel : MonoBehaviour 
{
    #region Public Fields
    public int nextLevel = 0;
    public int currentLevel = 0;
    #endregion

    #region Private Fields
    #endregion

    #region Unity Methods
    private void OnTriggerEnter(Collider other)
    {
        Player p = other.GetComponent<Player>();
        if(p != null)
        {
            LoadNextLevel();
        }
    }
    #endregion

    #region Public Methods
    public void LoadNextLevel()
    {
        MultiScene.GetInstance().LoadScene(nextLevel);
        MultiScene.GetInstance().ActiveGameManager(nextLevel);
    }

    public void UnloadLevel()
    {
        MultiScene.GetInstance().UnloadScene(currentLevel);
        MultiScene.GetInstance().UnactiveGameManager(currentLevel);
    }
    #endregion

    #region Private Methods
    #endregion
}