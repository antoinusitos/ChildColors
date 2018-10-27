using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour 
{
    #region Public Fields
    public ChangeCubesColor changeCubesColor = null;
    public ChangeCubesToColor changeCubesToColor = null;
    public ChangeCubesColorRetarget changeCubesColorRetarget = null;
    public MoveObjectsWithDelay moveObjectsWithDelay = null;

    public float timeWaitForChangeCubeColor = 5;
    public float timeWaitForCubeMovement = 5;
    #endregion

    #region Private Fields
    #endregion

    #region Unity Methods
    #endregion

    #region Public Methods
    public void ExecuteOpenDoor(bool normal)
    {
        StartCoroutine(OpenDoor(normal));
    }
    #endregion

    #region Private Methods
    private IEnumerator OpenDoor(bool normal)
    {
        if(normal)
        {
            changeCubesColorRetarget.newColor = 1;
            changeCubesColorRetarget.Execute();
            yield return new WaitForSeconds(timeWaitForChangeCubeColor);
            moveObjectsWithDelay.normalDirection = true;
            moveObjectsWithDelay.Execute();
        }
        else
        {
            moveObjectsWithDelay.normalDirection = false;
            moveObjectsWithDelay.Execute();
            yield return new WaitForSeconds(timeWaitForCubeMovement);
            changeCubesColorRetarget.newColor = 0;
            changeCubesColorRetarget.Execute();
        }
    }
    #endregion
}