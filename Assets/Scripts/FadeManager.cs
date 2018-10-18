using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeManager : MonoBehaviour
{
    #region Public Fields
    #endregion

    #region Private Fields
    private const float _speed = 1;
    private Image _image = null;
    #endregion

    #region Unity Methods
    #endregion

    #region Public Methods
    public void FadeIn()
    {
        StopCoroutine("Fade");
        StartCoroutine(Fade(0));
    }

    public void FadeOut()
    {
        StopCoroutine("Fade");
        StartCoroutine(Fade(1));
    }
    #endregion

    #region Private Methods
    private IEnumerator Fade(int direction)
    {
        float timer = 0;
        Color c = Color.black;
        c.a = 0;
        while(timer < 1)
        {
            _image.color = Color.Lerp(Color.black, c, direction == 1 ? timer : 1 - timer);
            timer += Time.deltaTime * _speed;
            yield return null;
        }
    }

    private void Init()
    {
        _image = GetComponent<Image>();
    }
    #endregion

    //---------------------------------------------------------------------

    private static FadeManager _instance = null;
    public static FadeManager GetInstance()
    {
        return _instance;
    }
    private void Awake()
    {
        _instance = this;
        Init();
    }
}
