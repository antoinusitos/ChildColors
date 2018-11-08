using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveWhenOwnColor : MonoBehaviour 
{
    #region Public Fields
    public ColorCube neededColor;
	#endregion
	
	#region Private Fields
	#endregion
	
	#region Unity Methods
	private void Start () 
	{
        PlayerAbilities playerAbilities = FindObjectOfType<PlayerAbilities>();
        if(!playerAbilities.Havebilities(neededColor))
        {
            gameObject.SetActive(false);
        }
	}
	#endregion
	
	#region Public Methods
    #endregion
	
	#region Private Methods
    #endregion
}
