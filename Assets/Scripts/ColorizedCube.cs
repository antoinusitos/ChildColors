using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorizedCube : MonoBehaviour 
{
    #region Public Fields
    public ColorCube colorCube;
    public bool blackDefault = false;
    public bool setColorAtStart = false;
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
        else if(setColorAtStart) _renderer.material.color = GetTargetColor();
    }
    #endregion

    #region Public Methods
    public void ChangeColor()
    {
        StopCoroutine("ChangeColorOverTime");
        StartCoroutine(ChangeColorOverTime(1));
    }

    public ColorCube GetColorCube()
    {
        return colorCube;
    }

    public void SetTargetColor(int newColor)
    {
        colorCube = (ColorCube)newColor;
        ChangeColor();
    }

    public bool GetColorChanged()
    {
        return _colorChanged;
    }

    public Color GetTargetColor()
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
            case ColorCube.GREY:
                return Color.grey;
            default:
                return Color.white;
        }
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
    #endregion
}