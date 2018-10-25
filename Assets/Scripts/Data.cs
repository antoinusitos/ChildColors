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
    public AudioClip audio;
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
    public static Color GetColor(ColorCube color)
    {
        switch (color)
        {
            case ColorCube.BLACK:
                return Color.black;
            case ColorCube.BLUE:
                return Color.blue;
            case ColorCube.GREEN:
                return Color.green;
            case ColorCube.RED:
                return Color.red;
            case ColorCube.WHITE:
                return Color.white;
            case ColorCube.GREY:
                return Color.grey;
            default:
                return Color.white;
        }
    }
    #endregion

    #region Private Methods
    #endregion
}