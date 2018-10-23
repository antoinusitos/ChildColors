using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowSubtiles : MonoBehaviour 
{
    #region Public Fields
    public SubtileInfo[] subtileInfos = null;
    #endregion

    #region Private Fields
    private Text text = null;
    private bool _isExecuting = false;
    private int _index = 0;
    private float _currentTime = 0;
    private Color basePanelColor;
    Color colPan = Color.grey;
    Color colTransp = Color.grey;
    private Image panel = null;
    #endregion

    #region Unity Methods
    private void Start()
    {
        text = GameObject.FindGameObjectWithTag("Subtitles").GetComponent<Text>();
        panel = text.transform.parent.GetComponent<Image>();
        basePanelColor = panel.color;
        colPan.a = 0.3f;
        colTransp.a = 0;
    }

    private void Update()
    {
        if(_isExecuting && _index < subtileInfos.Length)
        {
            _currentTime += Time.deltaTime;
            if(_currentTime >= subtileInfos[_index].time)
            {
                _currentTime = 0;
                _index++;
                if(_index >= subtileInfos.Length)
                {
                    StartCoroutine("Finished");
                }
                else
                {
                    StartCoroutine("FadeText");
                }
            }
        }
    }
    #endregion

    #region Public Methods
    public void Execute()
    {
        _isExecuting = true;
        StartCoroutine("FadeText");
    }
    #endregion

    #region Private Methods
    private void UpdateText()
    {
        text.text = subtileInfos[_index].text;
    }

    private IEnumerator FadeText()
    {
        float timer = 0;
        Color col = Color.white;
        while (timer < 1)
        {
            col.a = Mathf.Lerp(1, 0, timer);
            timer += Time.deltaTime;
            yield return null;
        }
        UpdateText();
        timer = 0;
        while (timer < 1)
        {
            col.a = Mathf.Lerp(0, 1, timer);
            text.color = col;
            panel.color = Color.Lerp(colTransp, colPan, timer);
            timer += Time.deltaTime;
            yield return null;
        }
    }

    private IEnumerator Finished()
    {
        float timer = 0;
        Color col = Color.white;
        while (timer < 1)
        {
            col.a = Mathf.Lerp(1, 0, timer);
            text.color = col;
            panel.color = Color.Lerp(colPan, colTransp, timer);
            timer += Time.deltaTime;
            yield return null;
        }
        text.text = "";
    }
    #endregion
}