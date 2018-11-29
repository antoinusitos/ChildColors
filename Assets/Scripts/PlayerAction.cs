using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour 
{
    #region Public Fields
    public Transform cameraPlayer = null;
    public GameObject hand = null;
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
            if (Physics.Raycast(cameraPlayer.position, cameraPlayer.forward, out hit, 2))
            {
                TurnCube tc = hit.transform.GetComponent<TurnCube>();
                if (tc != null)
                {
                    tc.Turn();
                    return;
                }

                Movable m = hit.transform.GetComponent<Movable>();
                if(m != null)
                {
                    m.Move();
                }

                ResetButton rb = hit.transform.GetComponent<ResetButton>();
                if (rb != null)
                {
                    rb.Execute();
                }
				
				Rotator r = hit.transform.GetComponent<Rotator>();
                if (r != null)
                {
                    r.ChangeDirection();
                }
            }
        }

        RaycastHit hitTest;
        if (Physics.Raycast(cameraPlayer.position, cameraPlayer.forward, out hitTest, 2))
        {
			Action a = hitTest.transform.GetComponent<Action>();
			if (a != null)
			{
				Movable m = a.GetComponent<Movable>();
				hand.SetActive(true);
				if (m != null)
				{
					if(!m.GetCanMove())
					{	
						hand.SetActive(false);
						return;
					}
				}
				return;
			}
			
			hand.SetActive(false);
        }
        else
        {
            hand.SetActive(false);
        }
    }
	#endregion
	
	#region Public Methods
    #endregion
	
	#region Private Methods
    #endregion
}