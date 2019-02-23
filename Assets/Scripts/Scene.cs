using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene : MonoBehaviour 
{
    #region Public Fields
    public GameManager      localGameManager = null;
    public int[]            scenesToUnload = null;
    public int[]            scenesToLoad = null;
    #endregion

    #region Private Fields
    private MultiScene      _multiScene = null;
    #endregion

    #region Unity Methods
    private void Start()
    {
        _multiScene = FindObjectOfType<MultiScene>();
    }
    #endregion

    #region Public Methods
    public void LoadNextScene()
    {
        for (int i = 0; i < scenesToUnload.Length; i++)
        {
            _multiScene.UnloadScene(scenesToUnload[i]);
        }
        for (int i = 0; i < scenesToLoad.Length; i++)
        {
            _multiScene.LoadScene(scenesToLoad[i]);
        }
    }
    #endregion

    #region Private Methods
    #endregion
}
