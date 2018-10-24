using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOutSound : MonoBehaviour 
{
    #region Public Fields
    public AudioSource audioSource = null;
	#endregion
	
	#region Private Fields
	#endregion
	
	#region Unity Methods
	#endregion
	
	#region Public Methods
    public void FadeOut()
    {
        StartCoroutine("Fade");
    }
    #endregion
	
	#region Private Methods
    private IEnumerator Fade()
    {
        float timer = 0;
        float baseVolume = audioSource.volume;
        while (timer < 1)
        {
            audioSource.volume = Mathf.Lerp(baseVolume, 0, timer);
            timer += Time.deltaTime;
            yield return null;
        }
        audioSource.volume = 0;
    }
    #endregion
}
