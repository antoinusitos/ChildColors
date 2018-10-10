using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro : GameState 
{
    #region Public Fields
    public TriggerCheck triggerToCheck = null;
    #endregion

    #region Private Fields
    #endregion

    #region Unity Methods
    #endregion

    #region Public Methods
    public override void OnStateEnter()
    {

    }

    public override bool OnStateUpdate() //true = exit state
    {
        if(triggerToCheck.GetPlayerInside())
        {
            return true;
        }
        return false;
    }

    public override void OnStateExit()
    {
        StartCoroutine("ChangeColor");
    }
    #endregion

    #region Private Methods
    private IEnumerator ChangeColor()
    {
        Movable[] m = FindObjectsOfType<Movable>();
        for (int i = 0; i < m.Length; i++)
        {
            m[i].ChangeColor();
            yield return new WaitForSeconds(0.05f);
        }
    }
    #endregion
}