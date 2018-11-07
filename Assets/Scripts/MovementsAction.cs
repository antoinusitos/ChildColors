﻿using System.Collections;
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
    private Vector3 _localBasePos;
    #endregion

    #region Unity Methods
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _localBasePos = transform.localPosition;
    }
    #endregion

    #region Public Methods
    public void ExecuteMovements()
    {
        if (_moving) return;

        _moving = true;

        StartCoroutine("Move");
    }

    public void ExecuteReverMovements()
    {
        if (_moving) return;

        _moving = true;

        StartCoroutine("InvertMove");
    }
    #endregion

    #region Private Methods
    private IEnumerator InvertMove()
    {
        Debug.Log("InvertMove");

        for (int i = infos.Length - 1; i >= 0; i--)
        {
            if (playSound)
            {
                _audioSource.clip = infos[i].audio;
                _audioSource.Play();
            }
            float timer = 0;
            Vector3 basePos = transform.localPosition;
            Debug.Log("base:" + basePos);
            Debug.Log("_localBasePos:" + _localBasePos);

            while (timer < infos[i].time)
            {
                if(i == 0)
                {
                    transform.localPosition = Vector3.Lerp(basePos, _localBasePos, timer / infos[i].time);
                }
                else
                {
                    transform.localPosition = Vector3.Lerp(basePos, infos[i].pos, timer / infos[i].time);
                }
                timer += Time.deltaTime;
                yield return null;
            }
            if (i == 0)
            {
                transform.localPosition = _localBasePos;
            }
            else
            {
                transform.localPosition = infos[i].pos;
            }
        }

        _moving = false;
    }

    private IEnumerator Move()
    {
        Debug.Log("move");
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
        _moving = false;
    }
    #endregion
}