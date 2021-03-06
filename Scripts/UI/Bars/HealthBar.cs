using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthBar : Bar
{
    private void OnEnable()
    {
        Player.MaxHealthChanged += SetSize;
        Player.HealthChanged += SetValue;
        Player.HealthChanged += SetValueText;
    }

    private void OnDisable()
    {
        Player.MaxHealthChanged -= SetSize;
        Player.HealthChanged -= SetValue;
        Player.HealthChanged -= SetValueText;
    }

    private void SetSize(int maxValue)
    {
        float currentSize = (float)maxValue / StartMaxValue;
        transform.localScale = new Vector3(currentSize, transform.localScale.y, transform.localScale.z);
    }

    protected override int GetMaxStartValue()
    {
        return ParametersEnhancer.MaxHealth.StartValue;
    }
}

