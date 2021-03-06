using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class Bar : MonoBehaviour
{
    [SerializeField] protected PlayerSpawner PlayerSpawner;
    [SerializeField] protected TMP_Text _ValueText;

    protected PlayerParametersEnhancer ParametersEnhancer;
    protected Player Player;
    protected Slider Slider;
    protected int StartMaxValue;

    private void Awake()
    {
        Player = PlayerSpawner.GetPlayer();
        Slider = GetComponent<Slider>();
        ParametersEnhancer = Player.GetComponent<PlayerParametersEnhancer>();
        StartMaxValue = GetMaxStartValue();
    }

    protected abstract int GetMaxStartValue();

    protected void SetValue(int value, int maxValue)
    {
        float normalizeHealth = GetNormalizeValue(value, maxValue);
        Slider.value = normalizeHealth;
    }

    protected float GetNormalizeValue(int value, int maxValue)
    {
        float normalizeHealth = (float)value / maxValue;
        return normalizeHealth;
    }
    protected void SetValueText(int value, int maxValue)
    {
        _ValueText.text = value + "/" + maxValue;
    }
}
