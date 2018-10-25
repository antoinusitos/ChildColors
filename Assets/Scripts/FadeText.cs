using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeText : MonoBehaviour 
{
    #region Public Fields
    public Text[] texts = null;
    #endregion

    #region Private Fields
    private const float _speed = 1;
    #endregion

    #region Unity Methods
    #endregion

    #region Public Methods
    public void Fade()
    {
        StartCoroutine(Fade(1));
    }
    #endregion

    #region Private Methods
    private IEnumerator Fade(int direction)
    {
        float timer = 0;
        Color c = Color.white;
        c.a = 0;
        while (timer < 1)
        {
            for(int i = 0; i < texts.Length; i++)
            {
                texts[i].color = Color.Lerp(Color.white, c, direction == 1 ? timer : 1 - timer);
            }
            timer += Time.deltaTime * _speed;
            yield return null;
        }
    }
    #endregion
}
