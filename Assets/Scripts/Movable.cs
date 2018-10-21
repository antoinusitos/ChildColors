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
    private bool _canMove = false;
    private Transform _transform = null;
    #endregion

    #region Unity Methods
    private void Start()
    {
        _transform = transform;
        PlayerAbilities pa = FindObjectOfType<PlayerAbilities>();
        ColorizedCube cc = GetComponent<ColorizedCube>();
        if(pa != null && cc != null)
        {
            if (cc.GetColorCube() == ColorCube.WHITE && pa.haveWhite)
            {
                _canMove = true;
                cc.ChangeColor();
                Debug.Log("lol");
            }
            else if (cc.GetColorCube() == ColorCube.RED && pa.haveRed)
            {
                _canMove = true;
                cc.ChangeColor();
                Debug.Log("lol1");
            }
            else if (cc.GetColorCube() == ColorCube.GREEN && pa.haveGreen)
            {
                _canMove = true;
                cc.ChangeColor();
                Debug.Log("lol2");
            }
            else if (cc.GetColorCube() == ColorCube.BLUE && pa.haveBlue)
            {
                _canMove = true;
                cc.ChangeColor();
                Debug.Log("lol3");
            }
        }
    }
    #endregion

    #region Public Methods
    public void Move()
    {
        if (!_canMove) return;

        if (_moving) return;

        _moving = true;

        StartCoroutine("MoveCube");
    }

    public bool GetIsMoving()
    {
        return _moving;
    }

    public void SetCanMove(bool newState)
    {
        _canMove = newState;
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