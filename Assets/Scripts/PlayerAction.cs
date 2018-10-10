using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour 
{
    #region Public Fields
    public Transform cameraPlayer = null;
	#endregion
	
	#region Private Fields
	#endregion
	
	#region Unity Methods
	private void Start () 
	{
		
	}
	
	private void Update () 
	{
		if(Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit hit;
            if (Physics.Raycast(cameraPlayer.position, cameraPlayer.forward, out hit, 100))
            {
                Movable m = hit.transform.GetComponent<Movable>();
                if(m != null)
                {
                    m.Move();
                }
            }
        }
	}
	#endregion
	
	#region Public Methods
    #endregion
	
	#region Private Methods
    #endregion
}