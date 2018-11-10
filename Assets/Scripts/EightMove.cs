using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EightMove : MonoBehaviour 
{
    #region Public Fields
    public float speedRight = 0.5f;
    public float speedUp = 0.5f;
    public float magRight = 1;
    public float magdUp = 1;
    #endregion

    #region Private Fields
    private Transform _transform = null;
    #endregion
 
    #region Unity Methods
    private void Start()
    {
        _transform = transform;
    }

    private void Update()
    {
        float movement = (Mathf.Sin(Time.time * speedRight) + 1 / 2) * magRight;
        _transform.localPosition = Vector3.right * movement;
        float movement2 = (Mathf.Sin(Time.time * speedUp) + 1 / 2) * speedUp;
        _transform.localPosition += Vector3.up * movement2;
    }
    #endregion
 
    #region Public Methods
    #endregion

    #region Private Methods
    #endregion
}