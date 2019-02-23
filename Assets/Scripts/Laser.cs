using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour 
{
    #region Public Fields
    public ColorizedCube receiver = null;
    public Color baseLaserColor;
    public ColorCube baseColor = ColorCube.WHITE;
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
        _colorCube = baseColor;
        ChangeLaserColor(baseLaserColor);
    }
	
	private void Update () 
	{
        if (!_activated) return;
        RaycastHit hit;
        int layerMask = 1 << 15;
        layerMask = ~layerMask;

        if (Physics.Raycast(_transform.position, _transform.forward, out hit, _lineRenderer.GetPosition(1).z, layerMask))
        {
            Movable m = hit.transform.GetComponent<Movable>();
            if (m != null)
            {
                ColorizedCube cc = m.GetComponent<ColorizedCube>();
                if (cc != null && _colorCube != cc.GetColorCube())
                {
                    _colorCube = cc.GetColorCube();
                    _lineRenderer.material.color = cc.GetTargetColor();
                    receiver.SetTargetColor((int)cc.GetColorCube());
                    receiver.ChangeColor();
                }
                return;
            }
            LaserReceiver lr = hit.transform.GetComponent<LaserReceiver>();
            if (lr != null)
            {
                _colorCube = ColorCube.BLACK;
                _lineRenderer.material.color = Data.GetColor(_colorCube);
                return;
            }
        }
    }
	#endregion
	
	#region Public Methods
    public void ActiveLaser(bool newState)
    {
        _activated = newState;

        if(_lineRenderer == null) _lineRenderer = GetComponent<LineRenderer>();

        _lineRenderer.enabled = newState;
    }

    public ColorCube GetColorCube()
    {
        return _colorCube;
    }

    public void ChangeLaserColor(Color col)
    {
        if (_lineRenderer == null) _lineRenderer = GetComponent<LineRenderer>();

        _lineRenderer.material.color = col;
    }
    #endregion
	
	#region Private Methods
    #endregion
}