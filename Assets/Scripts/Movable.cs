using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movable : MonoBehaviour 
{
    #region Public Fields
    #endregion

    #region Private Fields
    private bool _moving = false;
    private Transform _transform = null;
    #endregion

    #region Unity Methods
    private void Start()
    {
        _transform = transform;
    }
    #endregion

    #region Public Methods
    public void Move()
    {
        Debug.Log("move");

        if (_moving) return;

        _moving = true;

        StartCoroutine("MoveCube");
    }
    #endregion

    #region Private Methods
    private IEnumerator MoveCube()
    {
        float timer = 0;
        Vector3 basePos = _transform.position;
        while (timer < 1)
        {
            _transform.position = Vector3.Lerp(basePos, basePos + Vector3.forward, timer);
            timer += Time.deltaTime;
            yield return null;
        }
        _transform.position = basePos + Vector3.forward;
        _moving = false;
    }
    #endregion
}