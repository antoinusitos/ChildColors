using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CinematicManager : MonoBehaviour 
{
    #region Public Fields
    public RectTransform        cinematicTop = null;
    public RectTransform        cinematicBottom = null;
    #endregion

    #region Private Fields
    private bool                _cinematicDirection = false;
    private const float         _cinematicSize = 100;
    private const float         _cinematicSpeed = 2;
    #endregion

    #region Unity Methods
    private void Update()
    {
        if (_cinematicDirection)
        {
            cinematicTop.sizeDelta = Vector2.Lerp(cinematicTop.sizeDelta, Vector2.up * _cinematicSize, Time.deltaTime * _cinematicSpeed);
            cinematicBottom.sizeDelta = Vector2.Lerp(cinematicBottom.sizeDelta, Vector2.up * _cinematicSize, Time.deltaTime * _cinematicSpeed);
        }
        else
        {
            cinematicTop.sizeDelta = Vector2.Lerp(cinematicTop.sizeDelta, Vector2.zero, Time.deltaTime * _cinematicSpeed);
            cinematicBottom.sizeDelta = Vector2.Lerp(cinematicBottom.sizeDelta, Vector2.zero, Time.deltaTime * _cinematicSpeed);
        }
    }
    #endregion

    #region Public Methods
    public void SetCinematicDirection(bool newState)
    {
        _cinematicDirection = newState;
    }
    #endregion

    #region Private Methods
    #endregion

    //---------------------------------------------------------------------

    private static CinematicManager _instance = null;
    public static CinematicManager GetInstance()
    {
        return _instance;
    }
    private void Awake()
    {
        _instance = this;
    }
}
