using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro : GameState 
{
    #region Public Fields
    public TriggerCheck triggerToCheck = null;
    public Transform[] transformsToLight = null;
    public Transform[] transformsSingleToLight = null;
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
        for(int i = 0; i < transformsToLight.Length; i++)
        {
            for(int c = 0; c < transformsToLight[i].childCount; c++)
            {
                transformsToLight[i].GetChild(c).GetComponent<ColorizedCube>().ChangeColor();
                yield return new WaitForSeconds(0.05f);
            }
        }

        for (int i = 0; i < transformsSingleToLight.Length; i++)
        {
            transformsSingleToLight[i].GetComponent<ColorizedCube>().ChangeColor();
            yield return new WaitForSeconds(0.05f);
        }
    }
    #endregion
}