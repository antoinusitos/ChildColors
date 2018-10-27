using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCubesColorRetarget : MonoBehaviour 
{
    #region Public Fields
    public Transform[] transformsToLight = null;
    public Transform[] transformsSingleToLight = null;

    public bool sameTime = true;
    public bool skipAnimation = false;

    public int newColor = 0;
    #endregion

    #region Private Fields
    #endregion

    #region Unity Methods
    #endregion

    #region Public Methods
    public void Execute()
    {
        if(sameTime)
        {
            for (int i = 0; i < transformsToLight.Length; i++)
            {
                StartCoroutine(ChangeColorForObject(transformsToLight[i]));
            }
            for (int i = 0; i < transformsSingleToLight.Length; i++)
            {
                StartCoroutine(ChangeColorForObject(transformsSingleToLight[i]));
            }
        }
        else
            StartCoroutine("ChangeColor");
    }
    #endregion

    #region Private Methods
    private IEnumerator ChangeColor()
    {
        if (skipAnimation)
        {
            for (int i = 0; i < transformsToLight.Length; i++)
            {
                for (int c = 0; c < transformsToLight[i].childCount; c++)
                {
                    transformsToLight[i].GetChild(c).GetComponent<ColorizedCube>().SetTargetColor(newColor);
                }
            }

            for (int i = 0; i < transformsSingleToLight.Length; i++)
            {
                transformsSingleToLight[i].GetComponent<ColorizedCube>().SetTargetColor(newColor);
            }
        }
        else
        {
            for (int i = 0; i < transformsToLight.Length; i++)
            {
                for (int c = 0; c < transformsToLight[i].childCount; c++)
                {
                    transformsToLight[i].GetChild(c).GetComponent<ColorizedCube>().SetTargetColor(newColor);
                    yield return new WaitForSeconds(0.05f);
                }
            }

            for (int i = 0; i < transformsSingleToLight.Length; i++)
            {
                transformsSingleToLight[i].GetComponent<ColorizedCube>().SetTargetColor(newColor);
                yield return new WaitForSeconds(0.05f);
            }
        }
    }

    private IEnumerator ChangeColorForObject(Transform t)
    {
        if (skipAnimation)
        {
            if(t.childCount > 0)
            {
                for (int c = 0; c < t.childCount; c++)
                {
                    t.GetChild(c).GetComponent<ColorizedCube>().SetTargetColor(newColor);
                }
            }
            else
                t.GetComponent<ColorizedCube>().SetTargetColor(newColor);
        }
        else
        {
            if (t.childCount > 0)
            {
                for (int c = 0; c < t.childCount; c++)
                {
                    t.GetChild(c).GetComponent<ColorizedCube>().SetTargetColor(newColor);
                    yield return new WaitForSeconds(0.05f);
                }
            }
            else
                t.GetComponent<ColorizedCube>().SetTargetColor(newColor);
                
        }
    }
    #endregion
}