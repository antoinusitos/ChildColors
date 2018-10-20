using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ColorCube
{
    BLACK,
    WHITE,
    RED,
    GREEN,
    BLUE,
    GREY
}

[System.Serializable]
public struct MovementsInfo
{
    public Vector3 pos;
    public float time;
}

[System.Serializable]
public struct SubtileInfo
{
    public string text;
    public float time;
}

public class Data : MonoBehaviour 
{
	#region Public Fields
	#endregion
	
	#region Private Fields
	#endregion
	
	#region Unity Methods
	private void Start () 
	{
		
	}
	
	private void Update () 
	{
		
	}
	#endregion
	
	#region Public Methods
    #endregion
	
	#region Private Methods
    #endregion
}