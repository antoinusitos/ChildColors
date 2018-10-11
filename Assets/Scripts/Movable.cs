using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movable : MonoBehaviour 
{
    #region Public Fields
    public float speed = 2.0f;
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
        RaycastHit hit; 
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            float timer = 0;
            Vector3 basePos = _transform.position;
            Vector3 finalPos = hit.point + hit.normal / 2;
            float dist = Vector3.Distance(basePos, finalPos);
            while (timer < dist)
            {
                _transform.position = Vector3.Lerp(basePos, finalPos, timer / dist);
                timer += Time.deltaTime * speed;
                yield return null;
            }
            _transform.position = finalPos;
        }

        _moving = false;
    }
    #endregion
}