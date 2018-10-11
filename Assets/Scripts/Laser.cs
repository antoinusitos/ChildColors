using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour 
{
    #region Public Fields
    public ColorizedCube receiver = null;
    #endregion

    #region Private Fields
    private ColorCube _colorCube = ColorCube.WHITE;
    private LineRenderer _lineRenderer = null;
    private Transform _transform = null;
    private bool _activated = false;
	#endregion
	
	#region Unity Methods
	private void Start () 
	{
        _transform = transform;
        _lineRenderer = GetComponent<LineRenderer>();
    }
	
	private void Update () 
	{
        if (!_activated) return;
        RaycastHit hit;
        if (Physics.Raycast(_transform.position, _transform.forward, out hit))
        {
            ColorizedCube cc = hit.transform.GetComponent<ColorizedCube>();
            if (cc != null)
            {
                _colorCube = cc.GetColorCube();
                _lineRenderer.material.color = cc.GetTargetColor();
                receiver.SetTargetColor((int)cc.GetColorCube());
                receiver.ChangeColor();
            }
        }
    }
	#endregion
	
	#region Public Methods
    public void ActiveLaser(bool newState)
    {
        _activated = newState;
        _lineRenderer.enabled = newState;
    }

    public ColorCube GetColorCube()
    {
        return _colorCube;
    }

    public void ChangeLaserColor(Color col)
    {
        _lineRenderer.material.color = col;
    }
    #endregion
	
	#region Private Methods
    #endregion
}