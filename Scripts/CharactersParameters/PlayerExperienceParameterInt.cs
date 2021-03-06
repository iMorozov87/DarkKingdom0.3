using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class PlayerExperienceParameterInt : PlayerParameterInt
{
    protected override void SetCurrentValue()
    {
        int magnificationFactor = 2;
        CurrentValue = StartValue;
         if (Level > 1)
        {
            for (int i = 1; i < Level; i++)
            {
                CurrentValue *= magnificationFactor;
            }
        }
    }
}
