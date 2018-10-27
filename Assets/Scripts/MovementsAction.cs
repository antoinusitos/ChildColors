using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementsAction : MonoBehaviour 
{
    #region Public Fields
    public MovementsInfo[] infos = null;
    public bool playSound = false;
    #endregion

    #region Private Fields
    private bool _moving = false;
    private AudioSource _audioSource = null;
    #endregion

    #region Unity Methods
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }
    #endregion

    #region Public Methods
    public void ExecuteMovements()
    {
        if (_moving) return;

        _moving = false;

        StartCoroutine("Move");
    }

    public void ExecuteReverMovements()
    {
        if (_moving) return;

        _moving = false;

        StartCoroutine("InvertMove");
    }
    #endregion

    #region Private Methods
    private IEnumerator InvertMove()
    {
        for (int i = infos.Length - 1; i > 0; i--)
        {
            if (playSound)
            {
                _audioSource.clip = infos[i].audio;
                _audioSource.Play();
            }
            float timer = 0;
            Vector3 basePos = transform.localPosition;
            while (timer < infos[i].time)
            {
                transform.localPosition = Vector3.Lerp(basePos, infos[i].pos, timer / infos[i].time);
                timer += Time.deltaTime;
                yield return null;
            }
            transform.localPosition = infos[i].pos;
        }
    }

    private IEnumerator Move()
    {
        for(int i = 0; i < infos.Length; i++)
        {
            if(playSound)
            {
                _audioSource.clip = infos[i].audio;
                _audioSource.Play();
            }
            float timer = 0;
            Vector3 basePos = transform.localPosition;
            while (timer < infos[i].time)
            {
                transform.localPosition = Vector3.Lerp(basePos, infos[i].pos, timer / infos[i].time);
                timer += Time.deltaTime;
                yield return null;
            }
            transform.localPosition = infos[i].pos;
        }
    }
    #endregion
}