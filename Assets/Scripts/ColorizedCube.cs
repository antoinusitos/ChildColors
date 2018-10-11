using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorizedCube : MonoBehaviour 
{
    #region Public Fields
    public ColorCube colorCube;
    public bool blackDefault = false;
    #endregion

    #region Private Fields
    private Renderer _renderer = null;
    private bool _colorChanged = false;
    #endregion

    #region Unity Methods
    private void Start()
    {
        _renderer = GetComponent<Renderer>();
        if (blackDefault) _renderer.material.color = Color.black;
    }
    #endregion

    #region Public Methods
    public void ChangeColor()
    {
        StartCoroutine(ChangeColorOverTime(1));
    }

    public bool GetColorChanged()
    {
        return _colorChanged;
    }
    #endregion

    #region Private Methods
    private IEnumerator ChangeColorOverTime(float time)
    {
        float timer = 0;
        Color col = _renderer.material.color;
        Color target = GetTargetColor();
        while (timer < time)
        {
            _renderer.material.color = Color.Lerp(col, target, timer / time);
            timer += Time.deltaTime;
            yield return null;
        }
        _colorChanged = true;
    }

    private Color GetTargetColor()
    {
        switch (colorCube)
        {
            case ColorCube.BLACK:
                return Color.black;
            case ColorCube.BLUE:
                return Color.blue;
            case ColorCube.GREEN:
                return Color.green;
            case ColorCube.RED:
                return Color.red;
            case ColorCube.WHITE:
                return Color.white;
            default:
                return Color.white;

        }
    }
    #endregion
}