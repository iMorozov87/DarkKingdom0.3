using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class VisibilityChanger : MonoBehaviour
{
    [SerializeField] protected SpriteRenderer _spriteRenderer;
    [SerializeField] protected float _duration;

    protected const int maxValueAlpha = 1;
    protected const int minValueAlpha = 0;
    protected Coroutine _reduceColorAlpha;
    protected bool _isReduces = false;

    protected void MakeInvisible()
    {
        VisibilityChange(minValueAlpha);
    }

    protected void MakeVisible()
    {
        VisibilityChange(maxValueAlpha);
    }

    protected void VisibilityChange(int targenValue)
    {
        if (_isReduces == true)
        {
            StopCoroutine(_reduceColorAlpha);
        }
        _isReduces = true;
        _reduceColorAlpha = StartCoroutine(ReduceColorAlpha(targenValue));

    }
    protected IEnumerator ReduceColorAlpha(int targetValue)
    {
        float elapsed = 0;
        float startAlphaValue = _spriteRenderer.color.a;
        float currentAlphaValue = startAlphaValue;
        Color currentColor = _spriteRenderer.color;

        while (_isReduces)
        {
            elapsed += Time.deltaTime;
            currentAlphaValue = Mathf.Lerp(startAlphaValue, targetValue, elapsed / _duration);
            currentColor.a = currentAlphaValue;
            _spriteRenderer.color = currentColor;
            yield return null;
            _isReduces = CheckReduceColor(startAlphaValue, targetValue, currentAlphaValue);
        }
    }

    protected bool CheckReduceColor(float startAlphaValue, int targetValue, float currentAlphaValue)
    {
        if ((startAlphaValue > targetValue && currentAlphaValue <= targetValue)
            || (startAlphaValue <= targetValue && currentAlphaValue >= targetValue))
            return false;
        else
            return true;
    }
}
