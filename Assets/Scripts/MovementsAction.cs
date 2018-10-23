using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementsAction : MonoBehaviour 
{
    #region Public Fields
    public MovementsInfo[] infos = null;
    #endregion

    #region Private Fields
    private bool _moving = false;
    #endregion

    #region Unity Methods
    #endregion

    #region Public Methods
    public void ExecuteMovements()
    {
        if (_moving) return;

        _moving = false;

        StartCoroutine("Move");
    }
    #endregion

    #region Private Methods
    private IEnumerator Move()
    {
        for(int i = 0; i < infos.Length; i++)
        {
            float timer = 0;
            Vector3 basePos = transform.position;
            while (timer < infos[i].time)
            {
                transform.localPosition = Vector3.Lerp(basePos, infos[i].pos, timer / infos[i].time);
                timer += Time.deltaTime;
                yield return null;
            }
            transform.localPosition = infos[i].pos;
        }
    }
    #endregion
}