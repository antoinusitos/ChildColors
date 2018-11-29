using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rotator : Action 
{
    #region Public Fields
    public bool turnRight = false;
	public Image image = null;
	public Sprite turnRightImage = null;
	public Sprite turnLeftImage = null;
    #endregion

    #region Private Fields
    private bool _isTurning = false;
    private Movable _lastMovable = null;
    #endregion

    #region Unity Methods
	private void Start()
	{
		ChangeDirectionImage();
	}
	
    private void OnTriggerEnter(Collider other)
    {
        Movable m = other.GetComponent<Movable>();
        if(m != null)
        {
            _lastMovable = m;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Movable m = other.GetComponent<Movable>();
        if (m != null)
        {
            _lastMovable = null;
        }
    }

    private void Update()
    {
        if(_lastMovable != null && !_lastMovable.GetIsMoving() && !_isTurning)
        {
            _isTurning = true;
			Turn();
			MoveAgain();
        }
    }
    #endregion

    #region Public Methods
	public void ChangeDirection()
	{
		turnRight = !turnRight;
		ChangeDirectionImage();
	}
	#endregion

    #region Private Methods	
	private void ChangeDirectionImage()
	{
		if (turnRight)
        {
			image.sprite = turnRightImage;
        }
        else
        {
            image.sprite = turnLeftImage;
        }
	}
	
    private void Turn()
    {
        if (turnRight)
        {
            _lastMovable.transform.Rotate(Vector3.up, 90);
        }
        else
        {
            _lastMovable.transform.Rotate(Vector3.up, -90);
        }
    }

    private void MoveAgain()
    {
        _lastMovable.Move();
        _isTurning = false;
    }
    #endregion
}
