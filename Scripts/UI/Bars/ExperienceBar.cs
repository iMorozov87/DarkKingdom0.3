using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ExperienceBar : Bar
{
    private void OnEnable()
    {
        Player.ExperienceChanged += SetValue;
        Player.ExperienceChanged += SetValueText;
    }

    private void OnDisable()
    {
        Player.ExperienceChanged -= SetValue;
        Player.ExperienceChanged -= SetValueText;
    }

    protected override int GetMaxStartValue()
    {
        return ParametersEnhancer.MaxExperience.StartValue;
    }
}
