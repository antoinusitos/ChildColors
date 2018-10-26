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
    private bool _hasMoved = false;
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
                cc.ChangeColor();
            }
            else if (cc.GetColorCube() == ColorCube.RED && pa.haveRed)
            {
                cc.ChangeColor();
            }
            else if (cc.GetColorCube() == ColorCube.GREEN && pa.haveGreen)
            {
                cc.ChangeColor();
            }
            else if (cc.GetColorCube() == ColorCube.BLUE && pa.haveBlue)
            {
                cc.ChangeColor();
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

        _hasMoved = true;

        StartCoroutine("MoveCube");
    }

    public bool GetIsMoving()
    {
        return _moving;
    }

    public bool GetCanMove()
    {
        return _canMove;
    }

    public bool GetHasMoved()
    {
        return _hasMoved;
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
            Transform lastHit = hit.transform;
            float timer = 0;
            Vector3 basePos = _transform.position;
            Vector3 finalPos = hit.point + hit.normal / 2;

            StoppingMovement sm = hit.transform.GetComponent<StoppingMovement>();
            if (sm != null)
                finalPos = hit.point - hit.normal / 2;

            float dist = Vector3.Distance(basePos, finalPos);
            while (timer < dist)
            {
                _transform.position = Vector3.Lerp(basePos, finalPos, timer / dist);
                timer += Time.deltaTime * speed;
                yield return null;
                if (Physics.Raycast(transform.position, transform.forward, out hit))
                {
                    if(lastHit != hit.transform)
                    {
                        finalPos = hit.point + hit.normal / 2;
                        dist = Vector3.Distance(basePos, finalPos);
                    }
                }
            }
            _transform.position = finalPos;
        }

        _moving = false;
    }
    #endregion
}