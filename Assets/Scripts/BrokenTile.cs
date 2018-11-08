using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenTile : MonoBehaviour 
{
    #region Public Fields
    public float timeMaxToSwitch = 1;
    public float timeMinToSwitch = 0.1f;

    public ColorCube onColor;
    public ColorCube offColor;
    public bool startOn = true;
    #endregion

    #region Private Fields
    private float _currentTimeToSwitch = 0;
    private float _currentTime = 0;
    private ColorizedCube _colorizedCube = null;
    private bool _isOn = true;
    #endregion

    #region Unity Methods
    private void Start()
    {
        _colorizedCube = GetComponent<ColorizedCube>();
        _isOn = startOn;
        SelectTime();
    }

    private void Update()
    {
        _currentTime += Time.deltaTime;
        if(_currentTime >= _currentTimeToSwitch)
        {
            _isOn = !_isOn;
            if (_isOn)
            {
                _colorizedCube.ForceChangeColor((int)onColor);
            }
            else
            {
                _colorizedCube.ForceChangeColor((int)offColor);
            }
            SelectTime();
        }
    }
    #endregion

    #region Public Methods
    #endregion

    #region Private Methods
    private void SelectTime()
    {
        _currentTimeToSwitch = Random.Range(timeMinToSwitch, timeMaxToSwitch);
        _currentTime = 0;
    }
    #endregion
}
