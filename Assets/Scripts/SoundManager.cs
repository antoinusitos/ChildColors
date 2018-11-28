using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour 
{
    #region Public Fields
	public float speedLerp = 1;
    #endregion

    #region Private Fields
	private AudioSource _audioSource = null;
    #endregion
 
    #region Unity Methods
    private void Start()
    {
		_audioSource = GetComponent<AudioSource>();
    }
    #endregion
 
    #region Public Methods
	public void PlaySound(AudioClip theSound)
	{
		_audioSource.clip = theSound;
		StartCoroutine("Play");
		_audioSource.Play();
	}
	
	public void StopSound(AudioClip theSound)
	{
		StartCoroutine("Stop");
	}
    #endregion

    #region Private Methods
	private IEnumerator Play()
	{
		float timer = 0;
		while(timer < 1)
		{
			timer += Time.deltaTime * speedLerp;
			_audioSource.volume = Mathf.Lerp(0, 1, timer);
			yield return null;
		}
	}
	
	private IEnumerator Stop()
	{
		float timer = 0;
		while(timer < 1)
		{
			timer += Time.deltaTime * speedLerp;
			_audioSource.volume = Mathf.Lerp(1, 0, timer);
			yield return null;
		}
		_audioSource.Stop();
	}
    #endregion
}