using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiScene : MonoBehaviour 
{
    #region Public Fields
    public Scene[] scenes = null;
    #endregion

    #region Private Fields
    #endregion

    #region Unity Methods
    #endregion

    #region Public Methods
    public void LoadScene(int sceneToLoad)
    {
        scenes[sceneToLoad].gameObject.SetActive(true);
    }

    public void ActiveGameManager(int sceneToLoad)
    {
        scenes[sceneToLoad].localGameManager.gameObject.SetActive(true);
    }

    public void UnloadScene(int sceneToLoad)
    {
        scenes[sceneToLoad].gameObject.SetActive(false);
    }

    public void UnactiveGameManager(int sceneToLoad)
    {
        scenes[sceneToLoad].localGameManager.gameObject.SetActive(false);
    }
    #endregion

    #region Private Methods
    #endregion

    //---------------------------------------------------------------------

    private static MultiScene _instance = null;
    public static MultiScene GetInstance()
    {
        return _instance;
    }
    private void Awake()
    {
        _instance = this;
    }
}
