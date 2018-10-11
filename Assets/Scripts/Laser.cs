using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour 
{
    #region Public Fields
    #endregion

    #region Private Fields
    private LineRenderer _lineRenderer = null;
    private Transform _transform = null;
	#endregion
	
	#region Unity Methods
	private void Start () 
	{
        _transform = transform;
        _lineRenderer = GetComponent<LineRenderer>();
    }
	
	private void Update () 
	{
        RaycastHit hit;
        if (Physics.Raycast(_transform.position, _transform.forward, out hit))
        {
            ColorizedCube cc = hit.transform.GetComponent<ColorizedCube>();
            if (cc != null)
            {
                _lineRenderer.material.color = cc.GetTargetColor();
            }
        }
    }
	#endregion
	
	#region Public Methods
    #endregion
	
	#region Private Methods
    #endregion
}